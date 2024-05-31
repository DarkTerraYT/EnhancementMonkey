using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class BallLightning : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.BallLightningUpgradeIcon;

        public override int BaseCost => 3825;

        protected override string TowerID => "Druid-420";

        protected override int Index => 3;
    }
}
