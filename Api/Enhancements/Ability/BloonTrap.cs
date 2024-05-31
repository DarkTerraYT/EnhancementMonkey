using EnhancementMonkey.Api.Enhancements.Weapon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Ability
{
    internal class BloonTrap : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.BloonTrapUpgradeIcon;

        public override int BaseCost => 3600;

        protected override string TowerID => "EngineerMonkey-024";

        protected override int Index => 1;
    }
}
