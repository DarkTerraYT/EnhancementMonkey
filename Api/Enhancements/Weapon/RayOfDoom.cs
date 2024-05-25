using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class RayOfDoom : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.RayOfDoomUpgradeIcon;

        public override int BaseCost => 96800;

        protected override string TowerID => "DartlingGunner-520";
    }
}
