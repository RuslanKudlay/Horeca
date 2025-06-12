using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Application.Eceptions;
using Application.Supporting.Auth.Interfaces;
using Domain.Supporting.Auth.Entities;
using Domain.Supporting.Auth.Exceptions;
using Horeca.Constants;
using Horeca.DTOs.Supporting.Auth;
using Infrastrucutre.Repositories.Supporting.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace Application.Supporting.Auth.Services;

public class AuthService : IAuthService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IAuthRepository _authRepository;
    private readonly IPasswordHasher _passwordHasher;

    public AuthService(IAuthRepository authRepository, IPasswordHasher passwordHasher, IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
        _authRepository = authRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<string> GetTokenAsync(LoginDto loginDto)
    {
        var hash = _passwordHasher.GetHash(loginDto.Password);
        var user = await _authRepository.GetUserForLoginAsync(loginDto.Email, hash);

        if (user is null)
        {
            throw new CustomException("Не вірні логін або пароль!");
        }

        var claim = GetByUser(user);

        if (claim is null)
        {
            throw new CustomException("Помилка авторизації!");
        }
        
        var now = DateTime.Now;
        var jwt = new JwtSecurityToken(
            issuer: Options.AuthOptions.ISSUER,
            audience: Options.AuthOptions.AUDIENCE,
            notBefore: now,
            claims: claim.Claims,
            expires: now.Add(TimeSpan.FromMinutes(Options.AuthOptions.LIFETIME)),
            signingCredentials: new SigningCredentials(Options.AuthOptions.GetSymmetricSecurityKey(),
                SecurityAlgorithms.HmacSha256));
        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        return encodedJwt;
    }

    public async Task<bool> CreateUserAsync(CreateUserRequestDto createUserRequest)
    {
        if (await _authRepository.VerifyExistingUser(createUserRequest.Email))
        {
            throw new UserAlredyExistsException(createUserRequest.Email);
        }

        var hash = _passwordHasher.GetHash(createUserRequest.Password);

        var user = new User(
            createUserRequest.Name,
            createUserRequest.Email,
            hash,
            createUserRequest.Phone);
        return await _authRepository.AddAsync(user);
    }

    public async Task<bool> ChangePasswordAsync(ChangePasswordDto changePassworDto)
    {
        var user = await _authRepository.GetByIdAsync(changePassworDto.UserId);

        if (user is null)
        {
            throw new UserNotFoudException(changePassworDto.UserId);
        }
        
        user.ChangePassword(changePassworDto.OldPassword, changePassworDto.NewPassword, _passwordHasher);
        return await _authRepository.ChangePasswordAsync(user);
    }
    
    private ClaimsIdentity GetByUser(User user)
    {
        string ip = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
        var claims = new List<Claim>
        {
            new Claim("id", user.Id.ToString()),
            new Claim("email", user.Email),
            new Claim("address", ip),
            new Claim("session", Guid.NewGuid().ToString())
        };
        var claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
            ClaimsIdentity.DefaultRoleClaimType);
        return claimsIdentity;
    }
}