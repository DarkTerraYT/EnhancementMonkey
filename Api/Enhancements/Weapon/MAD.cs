using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class MAD : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.MadUpgradeIcon;

        public override string EnhancementName => "MAD Rockets";

        public override int BaseCost => 66850;

        protected override string TowerID => "DartlingGunner-250";
    }
}
