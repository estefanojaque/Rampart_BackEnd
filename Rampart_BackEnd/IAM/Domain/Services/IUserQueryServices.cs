using Rampart_BackEnd.IAM.Domain.Model.Aggregates;
using Rampart_BackEnd.IAM.Domain.Model.Queries;

namespace Rampart_BackEnd.IAM.Domain.Services;

public interface IUserQueryServices
{
    Task<User?> Handle(GetUserByIdQuery query);
    Task<IEnumerable<User>> Handle(GetAllUsersQuery query);
    Task<User?> Handle(GetUserByUsernameQuery query);
}