using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class Magic : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.IntenseMagicUpgradeIcon;

        public override string Description => "Gives the Enhancement Monkey a 000 bolt";

        public override int BaseCost => 250;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Basic;

        protected override string towerID => "WizardMonkey";
    }
}
