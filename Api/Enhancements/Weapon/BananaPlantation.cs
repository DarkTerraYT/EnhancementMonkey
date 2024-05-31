using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class BananaPlantation : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.BananaPlantationUpgradeIcon;

        public override int BaseCost => 5235;

        protected override string TowerID => "BananaFarm-300";
    }
}
