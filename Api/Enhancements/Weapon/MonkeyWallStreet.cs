using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class MonkeyWallStreet : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.CentralMarketUpgradeIcon;

        public override int BaseCost => 90575;

        protected override string TowerID => "BananaFarm-025";
    }
}
