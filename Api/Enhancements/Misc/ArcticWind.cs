using BTD_Mod_Helper.Extensions;
using EnhancementMonkey.Api.Ui.Submenues;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;

namespace EnhancementMonkey.Api.Enhancements.Misc
{
    internal class ArcticWind : ModEnhancement
    {
        public override string Icon => VanillaSprites.ArcticWindUpgradeIcon;

        public override int BaseCost => 3500;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Great;

        public override ModSubmenu Submenu => ModSubmenu.Misc;

        public override ModifyType Modifies => ModifyType.Tower;

        public override bool LockAfterBuy => true;

        protected override void ModifyTower(TowerModel towerModel)
        {
            var model = Game.instance.model.GetTowerFromId("IceMonkey-030").GetBehavior<SlowBloonsZoneModel>();

            towerModel.AddBehavior(model);
        }
    }
}
