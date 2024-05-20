using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;

namespace EnhancementMonkey.Api.Enhancements.Ability
{
    internal class Annihilation : ModEnhancement
    {
        public override string Icon => VanillaSprites.TechTerrorUpgradeIconAA;

        public override int BaseCost => 18000;

        public override EnhancementType EnhancementGroup => EnhancementType.Ability;

        public override ModifyType Modifies => ModifyType.Tower;

        protected override void ModifyTower(TowerModel towerModel)
        {
            towerModel.AddBehavior(Game.instance.model.GetTowerFromId("SuperMonkey-040").GetAbility().Duplicate());
        }
    }
}
