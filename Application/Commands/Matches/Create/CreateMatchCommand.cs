using Application.Common;
using MediatR;

namespace Application.Commands.Matches.Create
{
    public class CreateMatchCommand
        : IRequest<OperationResult<string>>
    {
        public Guid UserId { get; set; }
        public Guid TargetUserId { get; set; }
    }
}