using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class RoboMonkey : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.RoboMonkeyUpgradeIcon;

        public override int BaseCost => 9500;

        protected override string TowerID => "SuperMonkey-030";

        protected override bool AddAll => true;
    }
}
