using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;

namespace EnhancementMonkey.Api.Enhancements.Ability
{
    internal class GrandSabotage : ModEnhancement
    {
        public override string Icon => VanillaSprites.BloonSabotageUpgradeIcon;

        public override int BaseCost => 23100;

        public override EnhancementType EnhancementGroup => EnhancementType.Ability;

        public override ModifyType Modifies => ModifyType.Tower;

        protected override void ModifyTower(TowerModel towerModel)
        {
            towerModel.AddBehavior(Game.instance.model.GetTowerFromId("NinjaMonkey-050").GetAbility().Duplicate());
        }
    }
}
