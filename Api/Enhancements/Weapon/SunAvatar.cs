using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class SunAvatar : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.SunAvatarUpgradeIcon;

        public override int BaseCost => 26375;

        protected override string TowerID => "SuperMonkey-300";
    }
}
