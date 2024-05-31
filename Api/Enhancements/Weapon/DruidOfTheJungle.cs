using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class DruidOfTheJungle : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.DruidoftheJungleUpgradeIcon;

        public override int BaseCost => 890;

        protected override string TowerID => "Druid-030";

        protected override int Index => 1;
    }
}
