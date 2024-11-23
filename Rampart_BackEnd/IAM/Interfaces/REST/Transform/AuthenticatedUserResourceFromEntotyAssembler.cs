﻿using Rampart_BackEnd.IAM.Domain.Model.Aggregates;
using Rampart_BackEnd.IAM.Interfaces.REST.Resources;

namespace Rampart_BackEnd.IAM.Interfaces.REST.Transform;

public class AuthenticatedUserResourceFromEntotyAssembler
{
    public static AuthenticatedUserResource ToResourceFromEntity(
        User user, string token)
    {
        return new AuthenticatedUserResource(user.Id, user.Username, token);
    }
}