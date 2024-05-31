using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class Fireball : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.FireballUpgradeIcon;

        public override int BaseCost => 400;

        protected override string TowerID => "WizardMonkey-010";

        protected override int Index => 1;
    }
}
