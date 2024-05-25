using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class HydraRockets : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.HydraRocketsUpgradeIcon;

        public override int BaseCost => 6850;

        protected override string TowerID => "DartlingGunner-030";
    }
}
