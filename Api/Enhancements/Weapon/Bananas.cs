using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class Bananas : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.IncreasedProductionUpgradeIcon;

        public override int BaseCost => 1225;

        protected override string TowerID => "BananaFarm";
    }
}
