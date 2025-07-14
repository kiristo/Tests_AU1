using BlazorFluentCMS.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorFluentCMS.Infrastructure
{
    public class MenuService : IMenuService
    {
        private readonly ApplicationDbContext _context;

        public MenuService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Menu>> GetMenusAsync()
        {
            return await _context.Menus.Include(m => m.SubMenus).Where(m => m.ParentId == null).ToListAsync();
        }

        public async Task<Menu> GetMenuByIdAsync(int id)
        {
            return await _context.Menus.FindAsync(id);
        }

        public async Task CreateMenuAsync(Menu menu)
        {
            _context.Menus.Add(menu);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMenuAsync(Menu menu)
        {
            _context.Entry(menu).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMenuAsync(int id)
        {
            var menu = await _context.Menus.FindAsync(id);
            if (menu != null)
            {
                _context.Menus.Remove(menu);
                await _context.SaveChangesAsync();
            }
        }
    }
}
