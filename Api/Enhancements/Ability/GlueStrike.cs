using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;

namespace EnhancementMonkey.Api.Enhancements.Ability
{
    internal class GlueStorm : ModEnhancement
    {
        public override string Icon => VanillaSprites.GlueStrikeUpgradeIcon;

        public override int BaseCost => 16000;

        public override EnhancementLevel NewEnhancementLevel => EnhancementLevel.Awesome;

        public override EnhancementType EnhancementGroup => EnhancementType.Ability;

        public override ModifyType Modifies => ModifyType.Tower;

        public override uint Max => 3;

        protected override void ModifyTower(TowerModel towerModel)
        {
            var abilitizer = Game.instance.model.GetTowerFromId("GlueGunner-050").GetAbility().Duplicate();

            towerModel.AddBehavior(abilitizer);
        }
    }
}
