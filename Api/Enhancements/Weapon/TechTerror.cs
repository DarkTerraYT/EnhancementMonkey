using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class TechTerror : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.TechTerrorUpgradeIcon;

        public override int BaseCost => 39000;

        protected override string TowerID => "SuperMonkey-240";

        protected override bool AddAll => true;
    }
}
