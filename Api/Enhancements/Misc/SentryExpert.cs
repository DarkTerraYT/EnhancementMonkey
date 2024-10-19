
using BTD_Mod_Helper.Extensions;
using EnhancementMonkey.Api.Ui.Submenues;using Il2CppAssets.Scripts.Models.Towers;


namespace EnhancementMonkey.Api.Enhancements.Misc
{
    internal class SentryExpert : ModEnhancement
    {
        public override string Icon => VanillaSprites.SentryExpertUpgradeIcon;

        public override int BaseCost => 4000;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Basic;

        public override ModSubmenu Submenu => ModSubmenu.Misc;

        public override ModifyType Modifies => ModifyType.Tower;

        protected override void ModifyTower(TowerModel towerModel)
        {
            var atck = Game.instance.model.GetTowerFromId("EngineerMonkey-400").GetAttackModel(1).Duplicate();
            atck.name += Name + "Enhancement";

            Apply(atck);

            atck.range = towerModel.range;

            towerModel.AddBehavior(atck);
        }
    }
}
