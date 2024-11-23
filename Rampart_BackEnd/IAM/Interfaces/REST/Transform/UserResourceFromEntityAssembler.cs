using Rampart_BackEnd.IAM.Domain.Model.Aggregates;
using Rampart_BackEnd.IAM.Interfaces.REST.Resources;

namespace Rampart_BackEnd.IAM.Interfaces.REST.Transform;

public class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User user)
    {
        return new UserResource(user.Id, user.Username);
    }
}