using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class DarkKnight : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.DarkKnightUpgradeIcon;

        public override int BaseCost => 11800;

        protected override string TowerID => "SuperMonkey-003";
    }
}
