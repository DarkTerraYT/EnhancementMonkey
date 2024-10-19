using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Ui.Submenues
{
    /// <summary>
    /// Paragon submenu class
    /// </summary>
    public class ParagonEnhancements : ModSubmenu
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override void Register()
        {
            Paragon = this;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override string EmptyText => "No Paragons found! Try getting some t5s with a paragon";
    }
}
