using System.Collections.Generic;

namespace BlazorFluentCMS.Core
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public Menu Parent { get; set; }
        public List<Menu> SubMenus { get; set; } = new List<Menu>();
    }
}
