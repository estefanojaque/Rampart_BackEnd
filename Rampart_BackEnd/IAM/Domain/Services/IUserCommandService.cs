using Rampart_BackEnd.IAM.Domain.Model.Aggregates;
using Rampart_BackEnd.IAM.Domain.Model.Commands;

namespace Rampart_BackEnd.IAM.Domain.Services;

public interface IUserCommandService
{
    Task<(User user, string token)> Handle(SignInCommand command);

    Task Handle(SignUpCommand command);
}