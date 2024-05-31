using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class AvatarOfWrath : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.AvatarofWrathUpgradeIcon;

        public override int BaseCost => 41500;

        protected override string TowerID => "Druid-025";
    }
}
