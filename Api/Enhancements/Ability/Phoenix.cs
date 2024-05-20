using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;

namespace EnhancementMonkey.Api.Enhancements.Ability
{
    internal class Phoenix : ModEnhancement
    {
        public override string Icon => VanillaSprites.SummonPhoenixUpgradeIcon;

        public override int BaseCost => 5750;

        public override EnhancementType EnhancementGroup => EnhancementType.Ability;

        public override ModifyType Modifies => ModifyType.Tower;

        protected override void ModifyTower(TowerModel towerModel)
        {
            var ability = Game.instance.model.GetTowerFromId("WizardMonkey-040").GetAbility();

            towerModel.AddBehavior(ability);
        }
    }
}
