using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Rampart_BackEnd.Posts.Domain.Model.Aggregates;
using Rampart_BackEnd.Posts.Interfaces.REST.Resource;

namespace Rampart_BackEnd.Posts.Interfaces.REST.Transform;

public static class PostResourceFromEntityAssembler
{
    public static PostResource ToResourceFromEntity(Post entity)
    {
        return new PostResource(
            entity.id,
            entity.dishId,
            entity.publishDate,
            entity.stock,
            entity.pricePerUnit);
    }
}