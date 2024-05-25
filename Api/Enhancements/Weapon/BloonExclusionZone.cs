using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class BloonExclusionZone : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.BloonExclusionZoneUpgradeIcon;

        public override int BaseCost => 73600;

        protected override string TowerID => "DartlingGunner-025";

        protected override bool AddAll => true;
    }
}
