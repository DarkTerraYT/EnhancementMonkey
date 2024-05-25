using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class Buckshot : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.BuckshotUpgradeIcon;

        public override int BaseCost => 5600;

        protected override string TowerID => "DartlingGunner-003";
    }
}
