using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class JunglesBountyThorns : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.JunglesBountyUpgradeIcon;

        public override int BaseCost => 5000;

        protected override string TowerID => "Druid-140";

        protected override int Index => 1;
    }
}
