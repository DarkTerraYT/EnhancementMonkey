using BTD_Mod_Helper.Api;
using System.Collections.Generic;

namespace EnhancementMonkey.Api.Ui.Submenues
{
    public abstract class ModSubmenu : ModContent
    {
        public override void Register()
        {

        }

        public abstract EnhancementSubmenuInfo Info { get; }

        public static Dictionary<string, bool> Filters = new()
        {
            ["Unlocks"] = true,
            ["Basic"] = true,
            ["Good"] = true,
            ["Great"] = true,
            ["Awesome"] = true,
            ["Godly"] = true,
            ["Pure"] = true,
            ["Hidden"] = false
        };
    }
}
