using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class PlasmaBlasts : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.PlasmaBlastUpgradeIcon;

        public override int BaseCost => 6375;

        protected override string TowerID => "SuperMonkey-200";
    }
}
