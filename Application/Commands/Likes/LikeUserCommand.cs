using Application.Common;
using MediatR;

namespace Application.Commands.Likes;
public class LikeUserCommand : IRequest<OperationResult<string>>
{
    public Guid FromUserId { get; set; }
    public Guid ToUserId { get; set; }
}