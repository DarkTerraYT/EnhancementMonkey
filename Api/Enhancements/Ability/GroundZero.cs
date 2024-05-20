using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;

namespace EnhancementMonkey.Api.Enhancements.Ability
{
    internal class GroundZero : ModEnhancement
    {
        public override string Icon => VanillaSprites.GroundZeroUpgradeIconAA;

        public override int BaseCost => 16000;

        public override EnhancementType EnhancementGroup => EnhancementType.Ability;

        public override ModifyType Modifies => ModifyType.Tower;

        protected override void ModifyTower(TowerModel towerModel)
        {
            var ability = Game.instance.model.GetTowerFromId("MonkeyAce-040").GetAbility();

            towerModel.AddBehavior(ability);
        }
    }
}
