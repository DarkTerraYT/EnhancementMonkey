using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class ArcaneMastery : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.ArcaneMasteryUpgradeIcon;

        public override int BaseCost => 1975;

        protected override string TowerID => "WizardMonkey-300";
    }
}
