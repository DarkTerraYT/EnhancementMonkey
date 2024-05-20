using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;

namespace EnhancementMonkey.Api.Enhancements.Ability
{
    internal class SupplyDrop : ModEnhancement
    {
        public override string Icon => VanillaSprites.CashDropUpgradeIcon;

        public override int BaseCost => 5800;

        public override EnhancementType EnhancementGroup => EnhancementType.Ability;

        public override ModifyType Modifies => ModifyType.Tower;

        public override uint Max => 3;

        protected override void ModifyTower(TowerModel towerModel)
        {
            var ability = Game.instance.model.GetTowerFromId("SniperMonkey-040").GetAbility().Duplicate();

            towerModel.AddBehavior(ability);
        }
    }
}
