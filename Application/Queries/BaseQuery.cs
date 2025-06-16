using MediatR;

namespace Application.Queries;

public record BaseRequest<TD>: IRequest<TD>{}