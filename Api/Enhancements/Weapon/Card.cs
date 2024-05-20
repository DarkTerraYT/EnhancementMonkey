using BTD_Mod_Helper.Extensions;
using CardMonkey;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class Card : ModEnhancement
    {
        public override string Icon => GetSpriteReference<CardMonkeyMod>("CutTheDeck-Icon").GUID;

        public override string? ModID => "CardMonkey";

        public override int BaseCost => 210;

        public override EnhancementLevel NewEnhancementLevel => EnhancementLevel.Basic;

        public override EnhancementType EnhancementGroup => EnhancementType.Weapon;

        public override ModifyType Modifies => ModifyType.Tower;

        protected override void ModifyTower(TowerModel towerModel)
        {
            AttackModel atck = GetTowerModel<CardMonkey.CardMonkey>().GetAttackModel();
            atck.range = towerModel.range;

            towerModel.AddBehavior(atck);
        }
    }
}
