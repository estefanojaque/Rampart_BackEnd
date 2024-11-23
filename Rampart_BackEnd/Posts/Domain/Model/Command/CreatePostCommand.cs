namespace Rampart_BackEnd.Posts.Domain.Model.Command;

public record CreatePostCommand(
    int dishId,
    DateTime publishDate,
    int stock,
    float pricePerUnit);