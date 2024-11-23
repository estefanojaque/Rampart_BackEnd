using Rampart_BackEnd.IAM.Domain.Model.Commands;
using Rampart_BackEnd.IAM.Interfaces.REST.Resources;

namespace Rampart_BackEnd.IAM.Interfaces.REST.Transform;

public class SignUpCommandFromResourceAssembler
{
    public static SignUpCommand ToCommandFromResource(SignUpResource resource)
    {
        return new SignUpCommand(resource.Username, resource.Password);
    }
}