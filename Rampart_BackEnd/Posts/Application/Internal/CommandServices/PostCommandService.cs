﻿using Rampart_BackEnd.Posts.Domain.Model.Aggregates;
using Rampart_BackEnd.Posts.Domain.Model.Command;
using Rampart_BackEnd.Posts.Domain.Repositories;
using Rampart_BackEnd.Posts.Domain.Services;
using Rampart_BackEnd.Shared.Domain.Repositories;

namespace Rampart_BackEnd.Posts.Application.Internal.CommandServices;

public class PostCommandService(IPostRepository postRepository, IUnitOfWork unitOfWork) : IPostCommandService
{
    public async Task<Post?> Handle(CreatePostCommand command)
    {
        var post = new Post(command);
        try
        {
            await postRepository.AddSync(post);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return post;
    }

    public async Task<Post?> Handle(UpdatePostCommand command)
    {
        var post = await postRepository.FindByIdAsync(command.PostId);
        if (post == null)
        {
            throw new Exception("Post not found");
        }

        if (command.dishId != null)
        {
            post.dishId = (int)command.dishId;
        }

        if (command.publishDate != null)
        {
            post.publishDate = (DateTime)command.publishDate;
        }

        if (command.stock != null)
        {
            post.stock = (int)command.stock;
        }

        try
        {
            await postRepository.UpdateAsync(post);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        return post;
    }

    public async Task<bool> DeletePostAsync(int id)
    {
        var post = await postRepository.FindByIdAsync(id);
        if (post == null)
        {
            return false;
        }

        try
        {
            await postRepository.RemoveAsync(post);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return true;
    }
}