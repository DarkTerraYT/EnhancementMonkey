using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class GrandmasterNinja : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.GrandmasterNinjaUpgradeIcon;

        public override int BaseCost => 4255 + 29750;

        protected override string TowerID => "NinjaMonkey-502";
    }
}
