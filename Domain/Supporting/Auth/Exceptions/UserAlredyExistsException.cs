﻿namespace Domain.Supporting.Auth.Exceptions;

public class UserAlredyExistsException : Exception
{
    public int StatusCode { get; set; }

    public UserAlredyExistsException(string email, int statusCode = 400) : base(
        $"Користувач з email {email} вже існує!")
    {
        StatusCode = statusCode;
    }
}