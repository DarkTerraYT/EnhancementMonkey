using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;

namespace EnhancementMonkey.Api.Enhancements.Ability
{
    internal class EliteSupplyDrop : ModEnhancement
    {
        public override string Icon => VanillaSprites.CashDropUpgradeIcon;

        public override int BaseCost => 13800;

        public override EnhancementType EnhancementGroup => EnhancementType.Ability;

        public override ModifyType Modifies => ModifyType.Tower;

        public override bool AutoEnhancementLevel => false;

        public override EnhancementLevel NewEnhancementLevel => EnhancementLevel.Awesome;

        public override uint Max => 3;

        protected override void ModifyTower(TowerModel towerModel)
        {
            var ability = Game.instance.model.GetTowerFromId("SniperMonkey-050").GetAbility(0).Duplicate();

            ability.displayName += "2";
            ability.name += "2";
            ability.description += "2";


            towerModel.AddBehavior(ability);
        }
    }
}
