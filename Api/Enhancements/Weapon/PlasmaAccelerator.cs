using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class PlasmaAccelerator : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.PlasmaAcceleratorUpgradeIcon;

        public override int BaseCost => 16800;

        protected override string TowerID => "DartlingGunner-420";
    }
}
