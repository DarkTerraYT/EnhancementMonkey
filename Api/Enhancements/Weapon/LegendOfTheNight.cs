using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class LegendOfTheNight : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.LegendOfTheNightUpgradeIcon;

        public override int BaseCost => 261855;

        protected override string TowerID => "SuperMonkey-205";

        protected override bool AddAll => true;
    }
}
