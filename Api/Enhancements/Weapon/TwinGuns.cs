using BTD_Mod_Helper.Api.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class TwinGuns : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.TwinGunsUpgradeIcon;

        public override string Description => "Gives the enhancement Twin Guns";

        public override int BaseCost => 715;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Basic;

        protected override string towerID => "MonkeySub-001";
    }
}
