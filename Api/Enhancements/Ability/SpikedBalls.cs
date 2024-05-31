using EnhancementMonkey.Api.Enhancements.Weapon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Ability
{
    internal class SpikedBalls : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.SpikedBallsUpgradeIcon;

        public override int BaseCost => 5500;

        protected override string TowerID => "SpikeFactory-300";
    }
}
