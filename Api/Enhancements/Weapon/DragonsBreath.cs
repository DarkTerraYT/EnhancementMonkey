using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class DragonsBreath : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.DragonsBreathUpgradeIcon;

        public override string EnhancementName => "Dragon's Breath";

        public override int BaseCost => 3500;

        protected override string TowerID => "WizardMonkey-030";

        protected override int Index => 3;
    }
}
