using Rampart_BackEnd.IAM.Domain.Model.Aggregates;
using Rampart_BackEnd.Shared.Domain.Repositories;

namespace Rampart_BackEnd.IAM.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindByUsernameAsync(string username);

    bool ExistsByUsername(string username);
}