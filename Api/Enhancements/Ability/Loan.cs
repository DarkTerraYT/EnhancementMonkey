using BTD_Mod_Helper.Extensions;
using EnhancementMonkey.Api.Ui.Submenues;using Il2CppAssets.Scripts.Models.Towers;

namespace EnhancementMonkey.Api.Enhancements.Ability
{
    internal class Loan : ModEnhancement
    {
        public override string Icon => VanillaSprites.IMFLoanUpgradeIcon;

        public override int BaseCost => 6120;

        public override ModSubmenu Submenu => ModSubmenu.Ability;

        public override ModifyType Modifies => ModifyType.Tower;

        public override uint Max => 1;

        public override string Description => base.Description + " (IMF Loan)";

        protected override void ModifyTower(TowerModel towerModel)
        {
            towerModel.AddBehavior(Game.instance.model.GetTowerFromId("BananaFarm-040").GetAbility().Duplicate());
        }
    }
}
