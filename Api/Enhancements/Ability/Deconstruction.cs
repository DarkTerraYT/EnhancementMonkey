using EnhancementMonkey.Api.Enhancements.Weapon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Ability
{
    internal class Deconstruction : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.DeconstructionUpgradeIcon;

        public override int BaseCost => 950;

        protected override string TowerID => "EngineerMonkey-020";
    }
}
