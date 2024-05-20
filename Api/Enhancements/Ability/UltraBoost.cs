using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;

namespace EnhancementMonkey.Api.Enhancements.Ability
{
    internal class UltraBoost : ModEnhancement
    {
        public override string Icon => VanillaSprites.UltraboostUpgradeIcon;

        public override int BaseCost => 10500;

        public override string EnhancementName => "Ultra-Boost";

        public override EnhancementType EnhancementGroup => EnhancementType.Ability;

        public override ModifyType Modifies => ModifyType.Tower;

        public override uint Max => 1;

        protected override void ModifyTower(TowerModel towerModel)
        {
            towerModel.AddBehavior(Game.instance.model.GetTowerFromId("EngineerMonkey-050").GetAbility().Duplicate());
        }
    }
}
