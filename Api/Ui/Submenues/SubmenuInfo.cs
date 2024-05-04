using EnhancementMonkey.Api.Enhancements.Templates;
using EnhancementMonkey.Api.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Ui.Submenues
{
    public struct EnhancementSubmenuInfo(string name, int priority, EnhancementGroup group, ModSubmenu menu)
    {
        public string Name = name;
        public int Priority = priority;
        public EnhancementGroup Group = group;
        public ModSubmenu Menu = menu;
        public bool ModSubmenu = false;
    }
}
