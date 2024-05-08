using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using EnhancementMonkey.Api.Enum;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.AbilitiesMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Ability
{
    internal class TurboCharge : ModEnhancement
    {
        public override string Icon => VanillaSprites.TurbochargeUpgradeIcon;

        public override string Description => "Gives the Turbocharge Ability";

        public override int BaseCost => 5500;

        public override bool LockAfterBuy => true;

        public override int Priority => 0;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Basic;

        public override ModifyType Modifies => ModifyType.Tower;

        public override EnhancementType EnhancementGroup => EnhancementType.Ability;

        public override void ModifyTower(Tower tower)
        {
            var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();

            towerModel.AddBehavior(Game.instance.model.GetTowerFromId("BoomerangMonkey-040").GetAbility().Duplicate());

            tower.UpdateRootModel(towerModel);
            tower.UpdatedModel(towerModel);
        }
    }
}
