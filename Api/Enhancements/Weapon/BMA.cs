using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class BMA : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.BloonMasterAlchemistUpgradeIcon;

        public override int BaseCost => 37000;

        protected override string TowerID => "Alchemist-105";

        protected override int Index => 2;
    }
}
