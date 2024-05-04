using EnhancementMonkey.Api.Enhancements.Templates;
using EnhancementMonkey.Api.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Ui.Submenues
{
    public class WeaponEnhancements : ModSubmenu
    {
        public override EnhancementSubmenuInfo Info => new("Weapons", 1, EnhancementGroup.Weapon, this);
    }
}
