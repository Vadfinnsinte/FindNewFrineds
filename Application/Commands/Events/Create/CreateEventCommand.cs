using Application.Common;
using Application.Dtos.Events;
using MediatR;


namespace Application.Commands.Events.Create
{
    public class CreateEventCommand : IRequest<OperationResult<string>>
    {
        public AddEventDTO Dto { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
