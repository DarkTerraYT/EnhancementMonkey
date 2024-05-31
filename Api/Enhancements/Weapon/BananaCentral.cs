using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class BananaCentral : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.BananaCentralUpgradeIcon;

        public override int BaseCost => 139235;

        protected override string TowerID => "BananaFarm-520";
    }
}
