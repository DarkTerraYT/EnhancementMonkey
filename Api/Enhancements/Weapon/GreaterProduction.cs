using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class GreaterProduction : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.GreaterProductionUpgradeIcon;

        public override int BaseCost => 2325;

        protected override string TowerID => "BananaFarm-200";
    }
}
