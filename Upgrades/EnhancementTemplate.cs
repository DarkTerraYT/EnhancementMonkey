using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Towers;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Upgrades
{
    public abstract class EnhancementTemplate : ModContent
    {
        // Methods
        public abstract override void Register();
        public abstract void Apply(TowerModel towerModel);

        //UI Details
        public abstract string Icon { get; }
        public abstract string Description { get; }
        public abstract string EnhcanmentName { get; }

        //Pricing
        public abstract int Cost { get; }
        public abstract float CostMultiplier { get; }


        //Sorting
        /// <summary>
        /// The larger priority, changes the enhancement's color. Also makes it locked behind certain upgrades if the setting is turned on.
        /// </summary>
        public enum EnhancementType
        {
            Basic,
            Good,
            Great,
            Awesome,
            Godly,
            Pure,
            Sandbox, // Only appears in sandbox
            Hidden // Doesn't appear at all.
        }

        /// <summary>
        /// Where to be placed in the menu. Higher priority = further down in the menu.
        /// The priority is compared with the other enhancements in the enhancement level.
        /// Enchanments with the same priority will be organized by whatever's loaded first.
        /// </summary>
        public abstract int Priority { get; }
        public abstract EnhancementType EnhancementLevel { get;}
    }


}
