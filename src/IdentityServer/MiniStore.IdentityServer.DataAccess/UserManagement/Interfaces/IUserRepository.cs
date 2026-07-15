using MiniStore.IdentityServer.Contracts.UserManagement;
using MiniStore.IdentityServer.DataAccess.UserManagement.Models;

namespace MiniStore.IdentityServer.DataAccess.UserManagement.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<UserDTO>> GetListAsync(GetListRequest request);

    Task<int> CreateUserAsync(CreateUserRequest request);
}