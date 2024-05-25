using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Ui.Submenues
{
    internal class ParagonEnhancements : ModSubmenu
    {
        public override EnhancementSubmenuInfo Info => new("Paragons", 4, EnhancementType.Hide, this);

        public override string EmptyText => "No Paragons found! Try getting some t5s with a paragon";
    }
}
