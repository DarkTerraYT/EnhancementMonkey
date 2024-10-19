using BTD_Mod_Helper.Api;
using System.Collections.Generic;
using System.Linq;

namespace EnhancementMonkey.Api.Ui.Submenues
{
    /// <summary>
    /// Class to create submenus for enhancements, perfect to seperate your new enhancements from other ones.
    /// </summary>
    public abstract class ModSubmenu : NamedModContent
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override void Register()
        {

        }

        /// <summary>
        /// Returns the first submenu that has the same id or null.
        /// </summary>
        /// <param name="id">Submenu Id</param>
        /// <returns></returns>
        public static ModSubmenu GetSubmenu(string id)
        {
            return GetContent<ModSubmenu>().First(menu => menu.Id == id);
        }

        /// <summary>
        /// Misc submenu
        /// </summary>
        public static ModSubmenu Misc { get; internal set; }

        /// <summary>
        /// Stats submenu
        /// </summary>
        public static ModSubmenu Normal { get; internal set; }

        /// <summary>
        /// Weapon submenu
        /// </summary>
        public static ModSubmenu Weapon { get; internal set; }

        /// <summary>
        /// Ability submenu
        /// </summary>
        public static ModSubmenu Ability { get; internal set; }

        /// <summary>
        /// Paragon submenu
        /// </summary>
        public static ModSubmenu Paragon { get; internal set; }

        /// <summary>
        /// Hidden submenu
        /// </summary>
        public static ModSubmenu Hidden { get; internal set; }

        /// <summary>
        /// Hide this submenu?
        /// </summary>
        public virtual bool Hide { get; set; } = false;

        /// <summary>
        /// Toggle filters for enhancement levels.
        /// </summary>
        public static Dictionary<string, bool> LevelFilters = new()
        {

        };

        /// <summary>
        /// Minimum cost for enhancements to show.
        /// </summary>
        public static int MinShowCost = 0;

        /// <summary>
        /// Text to show when no enhancements are shown
        /// </summary>
        public virtual string EmptyText => "No Enhancements Found!\nTry Changing Filters?";
    }
}
