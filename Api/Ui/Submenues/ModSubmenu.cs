using BTD_Mod_Helper.Api;
using BTD_Mod_Helper;
using EnhancementMonkey.Api.Enhancements.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EnhancementMonkey.Main;

namespace EnhancementMonkey.Api.Ui.Submenues
{
    /// <summary>
    /// USE ModSubmenu INSTEAD! (Intended for creating extra groups)
    /// </summary>
    public abstract class ModSubmenu : ModContent
    {
        public override void Register()
        {
            List<ModEnhancement> enhancements_ = GetContent<ModEnhancement>();

            List<ModEnhancement> enhancements = [];

            int currPriority = 0;

            while (currPriority < enhancements.Count)
            {
                foreach (var enhancement in enhancements_)
                {
                    if (enhancement.Priority == currPriority)
                    {
                        enhancements.Add(enhancement);

                        currPriority++;

                        if (Main.DebugMode)
                        {
                            ModHelper.Log<Main>("Added " + enhancement.EnhancementName + " Enhancement to the Enhancement Group Type " + enhancement.EnhancementGroup);
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }

            EnhancementsInGroup = enhancements;
        }
        public abstract EnhancementSubmenuInfo Info { get; }
        /// <summary>
        /// Empty until this submenu has been registered.
        /// </summary>
        public List<ModEnhancement> EnhancementsInGroup = [];
    }
}
