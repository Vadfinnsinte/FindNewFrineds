using Application.Dtos.Events;
using Application.Common;
using MediatR;

public class EditEventCommand : IRequest<OperationResult<string>>
{
    public Guid EventId { get; set; }
    public EditEventDTO Dto { get; set; }
    public Guid UserId { get; set; }
    public bool IsAdmin { get; set; }
}