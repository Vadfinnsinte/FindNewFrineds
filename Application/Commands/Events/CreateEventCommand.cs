using Application.Common;
using Application.Dtos.Event;
using MediatR;


namespace Application.Commands.Event
{
    public class CreateEventCommand : IRequest<OperationResult<string>>
    {
        public AddEventDTO Dto { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
