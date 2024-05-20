using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;

namespace EnhancementMonkey.Api.Enhancements.Ability
{
    internal class Overclock : ModEnhancement
    {
        public override string Icon => VanillaSprites.OverclockUpgradeIcon;

        public override int BaseCost => 10500;

        public override EnhancementType EnhancementGroup => EnhancementType.Ability;

        public override ModifyType Modifies => ModifyType.Tower;

        public override uint Max => 6;

        protected override void ModifyTower(TowerModel towerModel)
        {
            towerModel.AddBehavior(Game.instance.model.GetTowerFromId("EngineerMonkey-040").GetAbility().Duplicate());
        }
    }
}
