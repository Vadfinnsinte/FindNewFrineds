using Application.Common;
using MediatR;

public class DeleteMatchCommand
    : IRequest<OperationResult<string>>
{
    public Guid UserId { get; set; }
    public Guid TargetUserId { get; set; }
}