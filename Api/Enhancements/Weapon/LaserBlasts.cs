using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class LaserBlasts : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.LaserBlastUpgradeIcon;

        public override int BaseCost => 3875;

        protected override string TowerID => "SuperMonkey-100";

        protected override bool AddAll => true;
    }
}
