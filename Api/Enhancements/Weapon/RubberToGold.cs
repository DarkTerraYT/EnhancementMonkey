using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class RubberToGold : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.RubbertoGoldUpgradeIcon;

        public override int BaseCost => 930 + 850 + 2335;

        protected override string TowerID => "Alchemist-104";
    }
}
