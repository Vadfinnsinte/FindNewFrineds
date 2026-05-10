using Application.Common;
using Application.Dtos.Events;
using MediatR;

namespace Application.Queries.Events
{
    public class GetMyEventsQuery
        : IRequest<OperationResult<List<ReadEventDTO>>>
    {
        public Guid UserId { get; set; }
    }
}
