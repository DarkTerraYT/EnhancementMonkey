using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Ui.Submenues
{
    internal class MiscEnhancements : ModSubmenu
    {
        public override EnhancementSubmenuInfo Info => new("Misc", 3, Enum.EnhancementGroup.Misc, this);
    }
}
