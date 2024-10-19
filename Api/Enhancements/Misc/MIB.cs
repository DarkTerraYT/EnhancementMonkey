
using BTD_Mod_Helper.Extensions;
using EnhancementMonkey.Api.Ui.Submenues;using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;

namespace EnhancementMonkey.Api.Enhancements.Misc
{
    internal class Mib : ModEnhancement
    {
        public override string Icon => VanillaSprites.MonkeyIntelligenceBureauUpgradeIcon;

        public override string Description => "Gives the tower MIB";

        public override int BaseCost => 8500;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Great;

        public override ModSubmenu Submenu => ModSubmenu.Misc;

        public override string EnhancementName => "MIB";

        public override ModifyType Modifies => ModifyType.Weapon;

        public override bool LockAfterBuy => true;

        public override void ModifyOther()
        {
            hitLead = true;

            MIB = true;
        }

        protected override void ModifyTower(TowerModel towerModel)
        {
            towerModel.GetDescendants<DamageModel>().ForEach(dmgModel => dmgModel.immuneBloonProperties = Il2Cpp.BloonProperties.None);
        }
    }
}
