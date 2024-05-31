using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class Tornados : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.DruidoftheStormUpgradeIcon;

        public override int BaseCost => 1445;

        protected override string TowerID => "Druid-300";

        protected override int Index => 2;
    }
}
