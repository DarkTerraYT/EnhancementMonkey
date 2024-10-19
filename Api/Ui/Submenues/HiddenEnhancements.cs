using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Ui.Submenues
{
    /// <summary>
    /// Hidden submenu class
    /// </summary>
    public class HiddenEnhancements : ModSubmenu
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override void Register()
        {
            Hidden = this;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override bool Hide { get; set; } = true;
    }
}
