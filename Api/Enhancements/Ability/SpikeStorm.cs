using BTD_Mod_Helper.Extensions;
using EnhancementMonkey.Api.Ui.Submenues;using Il2CppAssets.Scripts.Models.Towers;

namespace EnhancementMonkey.Api.Enhancements.Ability
{
    internal class SpikeStorm : ModEnhancement
    {
        public override string Icon => VanillaSprites.SpikeStormUpgradeIcon;

        public override int BaseCost => 6120;

        public override ModSubmenu Submenu => ModSubmenu.Ability;

        public override ModifyType Modifies => ModifyType.Tower;

        protected override void ModifyTower(TowerModel towerModel)
        {
            towerModel.AddBehavior(Game.instance.model.GetTowerFromId("SpikeFactory-240").GetAbility().Duplicate());
        }
    }
}
