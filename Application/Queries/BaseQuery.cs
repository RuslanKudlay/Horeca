using MediatR;

namespace Application.Queries;

public record BaseQuery<TD>: IRequest<TD>{}