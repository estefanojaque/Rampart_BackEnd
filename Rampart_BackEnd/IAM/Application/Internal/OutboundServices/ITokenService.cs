using Rampart_BackEnd.IAM.Domain.Model.Aggregates;

namespace Rampart_BackEnd.IAM.Application.Internal.OutboundServices;

/**
 * <summary>
 *     The token service interface
 * </summary>
 * <remarks>
 *     This interface is used to generate and validate JWT tokens
 * </remarks>
 */
public interface ITokenService
{
    string GenerateToken(User user);
    Task<int?> ValidateToken(string token);
}