using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class FlashBombs : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.FlashBombUpgradeIcon;

        public override int BaseCost => 2300;

        protected override string TowerID => "NinjaMonkey-003";

        protected override int Index => 2;
    }
}
