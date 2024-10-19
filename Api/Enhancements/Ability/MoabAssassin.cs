
using BTD_Mod_Helper.Extensions;
using EnhancementMonkey.Api.Ui.Submenues;using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;


namespace EnhancementMonkey.Api.Enhancements.Ability
{
    internal class AssassinateMoab : ModEnhancement
    {
        public override string Icon => VanillaSprites.MoabAssassinUpgradeIcon;

        public override string EnhancementName => "Assissinate MOAB";

        public override string Description => "Gives the Moab Assassin Ability";

        public override int BaseCost => 2450;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Great;

        public override ModSubmenu Submenu => ModSubmenu.Ability;

        public override ModifyType Modifies => ModifyType.Tower;

        public override uint Max => 4;

        protected override void ModifyTower(TowerModel towerModel)
        {
            AbilityModel ability = Game.instance.model.GetTowerFromId("BombShooter-040").GetAbility().Duplicate();

            towerModel.AddBehavior(ability);
        }
    }
}
