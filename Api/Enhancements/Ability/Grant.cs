using BTD_Mod_Helper.Extensions;
using EnhancementMonkey.Api.Ui.Submenues;using Il2CppAssets.Scripts.Models.Towers;

namespace EnhancementMonkey.Api.Enhancements.Ability
{
    internal class Grant : ModEnhancement
    {
        public override string Icon => VanillaSprites.MonkeyNomicsUpgradeIcon;

        public override int BaseCost => 90000;

        public override ModSubmenu Submenu => ModSubmenu.Ability;

        public override ModifyType Modifies => ModifyType.Tower;

        public override uint Max => 2;

        public override string Description => base.Description + " (Monkey Nomics)";

        protected override void ModifyTower(TowerModel towerModel)
        {
            towerModel.AddBehavior(Game.instance.model.GetTowerFromId("BananaFarm-050").GetAbility().Duplicate());
        }
    }
}
