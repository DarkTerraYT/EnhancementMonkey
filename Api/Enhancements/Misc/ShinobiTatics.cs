using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Misc
{
    internal class ShinobiTatics : ModEnhancement
    {
        public override string Icon => VanillaSprites.ShinobiTacticsUpgradeIcon;

        public override int BaseCost => 1020;

        public override EnhancementType EnhancementGroup => EnhancementType.Misc;

        public override ModifyType Modifies => ModifyType.Tower;

        protected override void ModifyTower(TowerModel towerModel)
        {
            towerModel.AddBehavior(Game.instance.model.GetTowerFromId("NinjaMonkey-030").GetBehavior<SupportShinobiTacticsModel>().Duplicate());
        }
    }
}
