﻿
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;

namespace EnhancementMonkey.Api.Enhancements.Normal
{
    public class Range1 : ModEnhancement
    {
        public override string Icon => VanillaSprites.LongRangeDartsUpgradeIcon;

        public override string Description => "Increases the range by 10%";

        public override int BaseCost => 500;

        public override int Priority => 1;

        public override EnhancementLevel NewEnhancementLevel => EnhancementLevel.Basic;

        public override EnhancementType EnhancementGroup => EnhancementType.Normal;

        public override ModifyType Modifies => ModifyType.Tower;

        public override void ModifyTower(Il2CppAssets.Scripts.Simulation.Towers.Tower tower)
        {
            var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();

            towerModel.IncreaseRange(towerModel.range * .1f);

            tower.UpdateRootModel(towerModel);
        }
    }
}
