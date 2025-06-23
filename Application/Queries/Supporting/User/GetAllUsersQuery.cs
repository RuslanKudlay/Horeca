using MediatR;

namespace Application.Queries.Supporting.User;

public record GetAllUsersQuery : IRequest<IReadOnlyList<Domain.Supporting.Auth.Entities.User>>;