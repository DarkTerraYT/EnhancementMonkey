using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;

namespace EnhancementMonkey.Api.Enhancements.Ability
{
    internal class GlueStrike : ModEnhancement
    {
        public override string Icon => VanillaSprites.GlueStrikeUpgradeIcon;

        public override int BaseCost => 3650;

        public override EnhancementLevel NewEnhancementLevel => EnhancementLevel.Great;

        public override EnhancementType EnhancementGroup => EnhancementType.Ability;

        public override ModifyType Modifies => ModifyType.Tower;

        public override uint Max => 2;

        protected override void ModifyTower(TowerModel towerModel)
        {
            var abilitizer = Game.instance.model.GetTowerFromId("GlueGunner-040").GetAbility().Duplicate();

            towerModel.AddBehavior(abilitizer);
        }
    }
}
