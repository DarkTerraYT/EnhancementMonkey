using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class BloonAreaDenialSystem : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.BloonAreaDenialSystemUpgradeIcon;

        public override int BaseCost => 15600;

        protected override string TowerID => "DartlingGunner-024";

        protected override bool AddAll => true;
    }
}
