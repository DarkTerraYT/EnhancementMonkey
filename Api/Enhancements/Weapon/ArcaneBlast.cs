using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class ArcaneBlast : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.ArcaneBlastUpgradeIcon;

        public override int BaseCost => 575;

        protected override string TowerID => "WizardMonkey-200";
    }
}
