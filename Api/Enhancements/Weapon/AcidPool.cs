using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class AcidPool : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.AcidPoolUpgradeIcon;

        public override int BaseCost => 930;

        protected override string TowerID => "Alchemist-002";

        protected override int Index => 1;
    }
}
