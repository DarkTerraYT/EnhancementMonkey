using BTD_Mod_Helper.Api.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class Tack : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.FasterShootingUpgradeIcon;

        public override string Description => "Enhancement Monkey now shoots a tack";

        public override int BaseCost => 315;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Basic;

        protected override string towerID => "TackShooter";
    }
}
