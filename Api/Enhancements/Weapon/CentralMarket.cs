using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class CentralMarket : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.CentralMarketUpgradeIcon;

        public override int BaseCost => 20575;

        protected override string TowerID => "BananaFarm-024";
    }
}
