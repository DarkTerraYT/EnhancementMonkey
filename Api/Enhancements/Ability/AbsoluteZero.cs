using BTD_Mod_Helper.Extensions;
using EnhancementMonkey.Api.Ui.Submenues;
using Il2CppAssets.Scripts.Models.Towers;

namespace EnhancementMonkey.Api.Enhancements.Ability
{
    internal class AbsoluteZero : ModEnhancement
    {
        public override string Icon => VanillaSprites.AbsoluteZeroUpgradeIcon;

        public override int BaseCost => 18000;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Awesome;

        public override ModSubmenu Submenu => ModSubmenu.Ability;

        public override ModifyType Modifies => ModifyType.Tower;

        public override uint Max => 1;

        protected override void ModifyTower(TowerModel towerModel)
        {
            var ability = Game.instance.model.GetTowerFromId("IceMonkey-050").GetAbility().Duplicate();

            towerModel.AddBehavior(ability);
        }
    }
}
