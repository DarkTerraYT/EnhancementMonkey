using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class DoubleShot : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.DoubleShotUpgradeIcon;

        public override int BaseCost => 1900;

        protected override string TowerID => "NinjaMonkey-300";
    }
}
