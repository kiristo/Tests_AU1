using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorFluentCMS.Core
{
    public interface IUserService
    {
        Task<IEnumerable<ApplicationUser>> GetUsersAsync();
        Task<ApplicationUser> GetUserByIdAsync(string id);
        Task CreateUserAsync(ApplicationUser user, string password);
        Task UpdateUserAsync(ApplicationUser user);
        Task DeleteUserAsync(string id);
    }
}
