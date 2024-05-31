using EnhancementMonkey.Api.Enhancements.Weapon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Ability
{
    internal class DoubleGun : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.DoubleGunUpgradeIcon;

        public override int BaseCost => 1470;

        protected override string TowerID => "EngineerMonkey-003";
    }
}
