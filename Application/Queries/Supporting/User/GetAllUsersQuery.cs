using MediatR;

namespace Application.Queries.Supporting.User;

public record GetAllUsersQuery : BaseQuery<IReadOnlyList<Domain.Supporting.Auth.Entities.User>>;