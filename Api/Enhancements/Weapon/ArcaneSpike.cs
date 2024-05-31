using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class ArcaneSpike : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.ArcaneSpikeUpgradeIcon;

        public override int BaseCost => 11975;

        protected override string TowerID => "WizardMonkey-420";
    }
}
