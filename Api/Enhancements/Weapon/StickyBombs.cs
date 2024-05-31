using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class StickyBombs : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.StickyBombUpgradeIcon;

        public override int BaseCost => 4550;

        protected override string TowerID => "NinjaMonkey-104";

        protected override int Index => 3;
    }
}
