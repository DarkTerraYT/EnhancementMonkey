using BTD_Mod_Helper.Extensions;
using EnhancementMonkey.Api.Ui.Submenues;using Il2CppAssets.Scripts.Models.Towers;

namespace EnhancementMonkey.Api.Enhancements.Ability
{
    internal class BloonSabotage : ModEnhancement
    {
        public override string Icon => VanillaSprites.BloonSabotageUpgradeIcon;

        public override int BaseCost => 4400;

        public override ModSubmenu Submenu => ModSubmenu.Ability;

        public override ModifyType Modifies => ModifyType.Tower;

        protected override void ModifyTower(TowerModel towerModel)
        {
            towerModel.AddBehavior(Game.instance.model.GetTowerFromId("NinjaMonkey-040").GetAbility().Duplicate());
        }
    }
}
