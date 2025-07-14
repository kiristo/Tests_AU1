using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorFluentCMS.Core
{
    public interface IMenuService
    {
        Task<IEnumerable<Menu>> GetMenusAsync();
        Task<Menu> GetMenuByIdAsync(int id);
        Task CreateMenuAsync(Menu menu);
        Task UpdateMenuAsync(Menu menu);
        Task DeleteMenuAsync(int id);
    }
}
