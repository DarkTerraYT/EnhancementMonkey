using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class WOF : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.WallOfFireUpgradeIcon;

        public override string EnhancementName => "Wall of Fire";

        public override int BaseCost => 900;

        protected override string TowerID => "WizardMonkey-020";

        protected override int Index => 2;
    }
}
