using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class Archmage : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.ArchmageUpgradeIcon;

        public override int BaseCost => 33975;

        protected override string TowerID => "WizardMonkey-520";

        protected override bool AddAll => true;
    }
}
