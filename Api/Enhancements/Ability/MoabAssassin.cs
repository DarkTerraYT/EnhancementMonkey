
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Unity;

namespace EnhancementMonkey.Api.Enhancements.Ability
{
    internal class AssassinateMoab : ModEnhancement
    {
        public override string Icon => VanillaSprites.MoabAssassinUpgradeIcon;

        public override string EnhancementName => "Assissinate MOAB";

        public override string Description => "Gives the Moab Assassin Ability";

        public override int BaseCost => 2450;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Basic;

        public override EnhancementType EnhancementGroup => EnhancementType.Ability;

        public override ModifyType Modifies => ModifyType.Tower;

        protected override void ModifyTower(TowerModel towerModel)
        {
            AbilityModel ability = Game.instance.model.GetTowerFromId("BombShooter-040").GetAbility();

            towerModel.AddBehavior(ability);
        }
    }
}
