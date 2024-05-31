using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class Caltrops : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.CaltropsUpgradeIcon;

        public override int BaseCost => 545;

        protected override string TowerID => "NinjaMonkey-002";

        protected override int Index => 1;
    }
}
