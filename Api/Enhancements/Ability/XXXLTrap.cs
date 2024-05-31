using EnhancementMonkey.Api.Enhancements.Weapon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Ability
{
    internal class XxxlTrap : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.XXXLUpgradeIcon;

        public override int BaseCost => 51600;

        protected override string TowerID => "EngineerMonkey-025";

        protected override int Index => 1;
    }
}
