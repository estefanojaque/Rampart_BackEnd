using Rampart_BackEnd.Posts.Domain.Model.Aggregates;
using Rampart_BackEnd.Posts.Domain.Model.Command;

namespace Rampart_BackEnd.Posts.Domain.Services;

public interface IPostCommandService
{
    Task<Post?> Handle(CreatePostCommand command);
    
    Task<Post?> Handle(UpdatePostCommand command);
    
    Task<bool> DeletePostAsync(int id);
}