using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class Bloonjitsu : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.BloonjitsuUpgradeIcon;

        public override int BaseCost => 4255;

        protected override string TowerID => "NinjaMonkey-402";
    }
}
