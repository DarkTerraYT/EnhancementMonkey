using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class LaserCannon : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.LaserCannonUpgradeIcon;

        public override int BaseCost => 5700;

        protected override string TowerID => "DartlingGunner-300";
    }
}
