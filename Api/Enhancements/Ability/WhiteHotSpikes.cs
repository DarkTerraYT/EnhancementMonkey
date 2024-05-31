using EnhancementMonkey.Api.Enhancements.Weapon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Ability
{
    internal class WhiteHotSpikes : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.WhiteHotSpikesUpgradeIcon;

        public override int BaseCost => 2250;

        protected override string TowerID => "SpikeFactory-200";
    }
}
