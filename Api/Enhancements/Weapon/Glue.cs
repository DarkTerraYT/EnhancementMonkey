using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class Glue : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.StrongerGlueUpgradeIcon;

        public override string Description => "Enhancement Monkey now shoots glue";

        public override int BaseCost => 155;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Basic;

        protected override string towerID => "GlueGunner";
    }
}
