using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class Shimmer : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.ShimmerUpgradeIcon;

        public override int BaseCost => 1950;

        protected override string TowerID => "WizardMonkey-003";

        protected override int Index => 1;
    }
}
