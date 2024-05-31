using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class Marketplace : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.MarketplaceUpgradeIcon;

        public override int BaseCost => 4475;

        protected override string TowerID => "BananaFarm-003";
    }
}
