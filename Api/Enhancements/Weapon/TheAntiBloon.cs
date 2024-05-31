using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class TheAntiBloon : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.TheAntiBloonUpgradeIcon;

        public override int BaseCost => 109000;

        protected override string TowerID => "SuperMonkey-250";

        protected override bool AddAll => true;
    }
}
