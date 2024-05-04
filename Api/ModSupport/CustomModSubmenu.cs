using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.ModSupport
{
    /// <summary>
    /// Use this when creating your own submenus, not Submenu.
    /// </summary>
    public abstract class CustomModSubmenu 
    {
        public abstract CustomEnhancementGroup Group { get; }
        public abstract CustomModSubmenuInfo Info { get; }
    }

    public struct CustomModSubmenuInfo(string name, CustomEnhancementGroup group, CustomModSubmenu menu)
    {
        public string Name = name;
        public CustomEnhancementGroup Group = group;
        public CustomModSubmenu Menu = menu;
        public bool ModSubmenu = true;
    }
}
