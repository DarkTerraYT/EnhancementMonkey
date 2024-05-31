using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class SpiritOfTheForest : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.SpiritoftheForestUpgradeIcon;

        public override int BaseCost => 38000;

        protected override string TowerID => "Druid-150";

        protected override bool AddAll => true;
    }
}
