using BTD_Mod_Helper.Extensions;
using EnhancementMonkey.Api.Enhancements.Paragon;
using EnhancementMonkey.Api.Enhancements.Weapon;
using Il2CppAssets.Scripts.Models.Towers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Ability
{
    internal class RocketStorm : ParagonEnhancement
    {
        public override List<ModEnhancement> RequiredEnhancements => [GetInstance<HydraRockets>()];

        public override string Icon => VanillaSprites.RocketStormUpgradeIconAA;

        public override int BaseCost => 5550;

        public override ModifyType Modifies => ModifyType.Tower;

        public override bool AutoEnhancementLevel => true;

        public override EnhancementType EnhancementGroup => EnhancementType.Ability;

        protected override void ModifyTower(TowerModel towerModel)
        {
            towerModel.AddBehavior(Game.instance.model.GetTowerFromId("DartlingGunner-040").GetAbility().Duplicate());
        }
    }
}
