using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class PrinceOfDarkness : WeaponEnhancement
    {
        public override string Icon =>VanillaSprites.SoulbindUpgradeIcon;

        public override int BaseCost => 31250;

        protected override string TowerID => "WizardMonkey-205";

        protected override bool AddAll => true;
    }
}
