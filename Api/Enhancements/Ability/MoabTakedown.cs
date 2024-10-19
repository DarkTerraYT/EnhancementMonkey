using BTD_Mod_Helper.Extensions;
using EnhancementMonkey.Api.Ui.Submenues;using Il2CppAssets.Scripts.Models.Towers;

namespace EnhancementMonkey.Api.Enhancements.Ability
{
    internal class MoabTakedown : ModEnhancement
    {
        public override string Icon => VanillaSprites.TakedownIcon;

        public override string EnhancementName => "MOAB-Takedown";

        public override int BaseCost => 3000;

        public override ModSubmenu Submenu => ModSubmenu.Ability;

        public override ModifyType Modifies => ModifyType.Tower;

        protected override void ModifyTower(TowerModel towerModel)
        {
            var ability = Game.instance.model.GetTowerFromId("MonkeyBuccaneer-040").GetAbility().Duplicate();

            towerModel.AddBehavior(ability);
        }
    }
}
