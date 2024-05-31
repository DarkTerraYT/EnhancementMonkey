using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class LeadToGold : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.LeadtoGoldUpgradeIcon;

        public override int BaseCost => 930 + 850;

        protected override string TowerID => "Alchemist-003";
    }
}
