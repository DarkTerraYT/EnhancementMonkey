using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class BRF : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.BananaResearchFacilityUpgradeIcon;

        public override int BaseCost => 24235;

        protected override string TowerID => "BananaFarm-420";
    }
}
