using BTD_Mod_Helper.Api.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class Sniper : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.FastFiringUpgradeIcon;

        public override string Description => "Enhancement Monkey is now a sniper";

        public override int BaseCost => 235;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Basic;

        protected override string towerID => "SniperMonkey";
    }
}
