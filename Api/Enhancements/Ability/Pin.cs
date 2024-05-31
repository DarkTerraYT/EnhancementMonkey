using EnhancementMonkey.Api.Enhancements.Weapon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Ability
{
    internal class Pin : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.PinUpgradeIcon;

        public override int BaseCost => 1020;

        protected override string TowerID => "EngineerMonkey-002";
    }
}
