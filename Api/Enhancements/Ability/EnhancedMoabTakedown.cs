using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;

namespace EnhancementMonkey.Api.Enhancements.Ability
{
    internal class EnhancedMoabTakedown : ModEnhancement
    {
        public override string Icon => VanillaSprites.PirateLordUpgradeIconAA;

        public override string EnhancementName => "MOAB-Takedown 2";

        public override int BaseCost => 18000;

        public override EnhancementType EnhancementGroup => EnhancementType.Ability;

        public override ModifyType Modifies => ModifyType.Tower;

        protected override void ModifyTower(TowerModel towerModel)
        {
            var ability = Game.instance.model.GetTowerFromId("MonkeyBuccaneer-050").GetAbility().Duplicate();

            towerModel.AddBehavior(ability);
        }
    }
}
