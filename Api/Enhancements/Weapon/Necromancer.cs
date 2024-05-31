using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class Necromancer : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.NecromancerUnpoppedArmyUpgradeIcon;

        public override int BaseCost => 4750;

        protected override string TowerID => "WizardMonkey-204";

        protected override bool AddAll => true;
    }
}
