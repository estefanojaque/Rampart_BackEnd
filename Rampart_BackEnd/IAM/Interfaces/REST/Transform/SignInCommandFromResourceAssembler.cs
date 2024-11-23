using Rampart_BackEnd.IAM.Domain.Model.Commands;
using Rampart_BackEnd.IAM.Interfaces.REST.Resources;

namespace Rampart_BackEnd.IAM.Interfaces.REST.Transform;

public class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Username, resource.Password);
    }
}