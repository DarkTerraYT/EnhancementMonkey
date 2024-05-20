using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;

namespace EnhancementMonkey.Api.Enhancements.Ability
{
    internal class FirstStrike : ModEnhancement
    {
        public override string Icon => VanillaSprites.FirstStrikeCapabilityUpgradeIconAA;

        public override int BaseCost => 11000;

        public override EnhancementType EnhancementGroup => EnhancementType.Ability;

        public override ModifyType Modifies => ModifyType.Tower;

        protected override void ModifyTower(TowerModel towerModel)
        {
            var ability = Game.instance.model.GetTowerFromId("MonkeySub-040").GetAbility().Duplicate();

            towerModel.AddBehavior(ability);
        }
    }
}
