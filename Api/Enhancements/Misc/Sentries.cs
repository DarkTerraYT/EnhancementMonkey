
using BTD_Mod_Helper.Extensions;
using EnhancementMonkey.Api.Ui.Submenues;using Il2CppAssets.Scripts.Models.Towers;


namespace EnhancementMonkey.Api.Enhancements.Misc
{
    internal class Sentries : ModEnhancement
    {
        public override string Icon => VanillaSprites.SentryGunUpgradeIcon;

        public override int BaseCost => 315;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Basic;

        public override ModSubmenu Submenu => ModSubmenu.Misc;

        public override ModifyType Modifies => ModifyType.Tower;

        protected override void ModifyTower(TowerModel towerModel)
        {
            var atck = Game.instance.model.GetTowerFromId("EngineerMonkey-100").GetAttackModel(1).Duplicate();
            atck.name += Name + "Enhancement";

            Apply(atck);

            atck.range = towerModel.range;

            towerModel.AddBehavior(atck);
        }
    }
}
