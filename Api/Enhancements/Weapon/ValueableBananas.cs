using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class ValueableBananas : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.ValuableBananasUpgradeIcon;

        public override int BaseCost => 2325;

        protected override string TowerID => "BananaFarm-020";
    }
}
