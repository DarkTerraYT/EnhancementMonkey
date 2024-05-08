using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Ui.Submenues
{
    internal class AbilityEnhancements : ModSubmenu
    {
        public override EnhancementSubmenuInfo Info => new("Abilities", 2, Enum.EnhancementType.Ability, this);
    }
}
