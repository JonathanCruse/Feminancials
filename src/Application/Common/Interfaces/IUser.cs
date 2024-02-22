using System.Security.Claims;

namespace Feminancials.Application.Common.Interfaces;

public interface IUser
{
    string? Id { get; }
    ClaimsPrincipal? ClaimsPrincipal { get; }
}
