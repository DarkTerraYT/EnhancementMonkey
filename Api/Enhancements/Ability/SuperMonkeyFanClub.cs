using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;

namespace EnhancementMonkey.Api.Enhancements.Ability
{
    internal class SuperMonkeyFanClub : ModEnhancement
    {
        public override string Icon => VanillaSprites.SuperMonkeyFanClubUpgradeIcon;

        public override int BaseCost => 6800;

        public override EnhancementLevel NewEnhancementLevel => EnhancementLevel.Great;

        public override EnhancementType EnhancementGroup => EnhancementType.Ability;

        public override ModifyType Modifies => ModifyType.Tower;

        protected override void ModifyTower(TowerModel towerModel)
        {
            var ability = Game.instance.model.GetTowerFromId("DartMonkey-040").GetAbility().Duplicate();

            towerModel.AddBehavior(ability);
        }
    }
}
