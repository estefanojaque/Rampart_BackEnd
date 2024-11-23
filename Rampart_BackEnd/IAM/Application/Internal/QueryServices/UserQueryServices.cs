using Rampart_BackEnd.IAM.Domain.Model.Aggregates;
using Rampart_BackEnd.IAM.Domain.Model.Queries;
using Rampart_BackEnd.IAM.Domain.Repositories;
using Rampart_BackEnd.IAM.Domain.Services;

namespace Rampart_BackEnd.IAM.Application.Internal.QueryServices;

public class UserQueryServices(IUserRepository userRepository) : IUserQueryServices
{
    public async Task<User?> Handle(GetUserByIdQuery query)
    {
        return await userRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<User>> Handle(GetAllUsersQuery query)
    {
        return await userRepository.ListAsync();
    }

    public async Task<User?> Handle(GetUserByUsernameQuery query)
    {
        return await userRepository.FindByUsernameAsync(query.Username);
    }
}