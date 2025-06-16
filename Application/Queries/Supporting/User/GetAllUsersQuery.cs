using MediatR;

namespace Application.Queries.Supporting.User;

public record GetAllUsersQuery : BaseRequest<IReadOnlyList<Domain.Supporting.Auth.Entities.User>>;