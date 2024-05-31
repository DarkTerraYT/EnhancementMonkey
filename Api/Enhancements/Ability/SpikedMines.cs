using EnhancementMonkey.Api.Enhancements.Weapon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Ability
{
    internal class SpikedMines : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.SpikedMinesUpgradeIcon;

        public override int BaseCost => 15000;

        protected override string TowerID => "SpikeFactory-420";
    }
}
