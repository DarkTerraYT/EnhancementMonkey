using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;

namespace EnhancementMonkey.Api.Enhancements.Misc
{
    internal class ArcticWind : ModEnhancement
    {
        public override string Icon => VanillaSprites.ArcticWindUpgradeIcon;

        public override int BaseCost => 3500;

        public override EnhancementLevel NewEnhancementLevel => EnhancementLevel.Great;

        public override EnhancementType EnhancementGroup => EnhancementType.Misc;

        public override ModifyType Modifies => ModifyType.Tower;

        public override bool LockAfterBuy => true;

        protected override void ModifyTower(TowerModel towerModel)
        {
            var model = Game.instance.model.GetTowerFromId("IceMonkey-030").GetBehavior<SlowBloonsZoneModel>();

            towerModel.AddBehavior(model);
        }
    }
}
