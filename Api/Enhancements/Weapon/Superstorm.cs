using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class Superstorm : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.SuperStormUpgradeIcon;

        public override int BaseCost => 60000;

        protected override string TowerID => "Druid-520";

        protected override bool AddAll => true;
    }
}
