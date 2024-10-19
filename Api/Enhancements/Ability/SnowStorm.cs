using BTD_Mod_Helper.Extensions;
using EnhancementMonkey.Api.Ui.Submenues;using Il2CppAssets.Scripts.Models.Towers;

namespace EnhancementMonkey.Api.Enhancements.Ability
{
    internal class Snowstorm : ModEnhancement
    {
        public override string Icon => VanillaSprites.SnowstormUpgradeIcon;

        public override int BaseCost => 3000;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Great;

        public override ModSubmenu Submenu => ModSubmenu.Ability;

        public override ModifyType Modifies => ModifyType.Tower;

        public override uint Max => 2;

        protected override void ModifyTower(TowerModel towerModel)
        {
            var ability = Game.instance.model.GetTowerFromId("IceMonkey-040").GetAbility().Duplicate();

            towerModel.AddBehavior(ability);
        }
    }
}
