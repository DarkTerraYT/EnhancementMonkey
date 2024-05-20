using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;

namespace EnhancementMonkey.Api.Enhancements.Ability
{
    internal class JunglesBounty : ModEnhancement
    {
        public override string Icon => VanillaSprites.JunglesBountyUpgradeIconAA;

        public override int BaseCost => 2650;

        public override EnhancementType EnhancementGroup => EnhancementType.Ability;

        public override uint Max => 3;

        public override ModifyType Modifies => ModifyType.Tower;

        protected override void ModifyTower(TowerModel towerModel)
        {
            towerModel.AddBehavior(Game.instance.model.GetTowerFromId("Druid-040").GetAbility().Duplicate());
        }
    }
}
