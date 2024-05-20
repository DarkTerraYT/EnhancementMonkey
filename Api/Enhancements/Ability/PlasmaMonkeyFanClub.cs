using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;

namespace EnhancementMonkey.Api.Enhancements.Ability
{
    internal class PlasmaMonkeyFanClub : ModEnhancement
    {
        public override string Icon => VanillaSprites.PlasmaMonkeyFanClubUpgradeIcon;

        public override int BaseCost => 38000;

        public override EnhancementLevel NewEnhancementLevel => EnhancementLevel.Godly;

        public override EnhancementType EnhancementGroup => EnhancementType.Ability;

        public override ModifyType Modifies => ModifyType.Tower;

        protected override void ModifyTower(TowerModel towerModel)
        {
            var ability = Game.instance.model.GetTowerFromId("DartMonkey-050").GetAbility().Duplicate();

            towerModel.AddBehavior(ability);
        }
    }
}
