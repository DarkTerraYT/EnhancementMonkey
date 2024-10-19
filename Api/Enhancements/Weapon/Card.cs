using BTD_Mod_Helper.Extensions;
using CardMonkey;
using EnhancementMonkey.Api.Ui.Submenues;using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class Card : ModEnhancement
    {
        public override string Icon => GetSpriteReference<CardMonkeyMod>("CutTheDeck-Icon").AssetGUID;

        public override string DependencyIds => "CardMonkey";

        public override int BaseCost => 210;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Basic;

        public override ModSubmenu Submenu => ModSubmenu.Weapon;

        public override ModifyType Modifies => ModifyType.Tower;

        protected override void ModifyTower(TowerModel towerModel)
        {
            AttackModel atck = GetTowerModel<CardMonkey.CardMonkey>().GetAttackModel();
            atck.range = towerModel.range;

            towerModel.AddBehavior(atck);
        }
    }
}
