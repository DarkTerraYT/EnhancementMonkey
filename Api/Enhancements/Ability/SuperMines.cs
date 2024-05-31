using EnhancementMonkey.Api.Enhancements.Weapon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Ability
{
    internal class SuperMines : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.SuperMinesUpgradeIcon;

        public override int BaseCost => 140000;

        protected override string TowerID => "SpikeFactory-520";
    }
}
