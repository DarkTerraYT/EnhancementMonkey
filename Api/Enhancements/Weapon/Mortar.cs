using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using EnhancementMonkey.Api.Ui.Submenues;using Il2CppAssets.Scripts.Models.Towers;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class Mortar : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.BiggerBlastUpgradeIcon;

        public override int BaseCost => 400;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Basic;

        protected override string TowerID => "MortarMonkey";

        public override ModSubmenu Submenu => ModSubmenu.Weapon;

        public override ModifyType Modifies => ModifyType.Tower;

        protected override void ModifyTower(TowerModel towerModel)
        {
            var atck = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel();
            atck.RemoveWeapon(atck.weapons[0]);

            var newWpn = Game.instance.model.GetTowerFromId("MortarMonkey").GetWeapon();
            atck.AddWeapon(newWpn);

            atck.range = towerModel.range;
            Apply(atck);

            if (!Game.instance.model.GetTowerFromId("MortarMonkey").GetDescendant<FilterInvisibleModel>().isActive)
            {
                hitCamo = true;
            }
            atck.GetDescendants<DamageModel>().ForEach(dmgModel =>
            {
                if (dmgModel.immuneBloonProperties != Il2Cpp.BloonProperties.Lead)
                {
                    hitLead = true;
                }
            });

            towerModel.AddBehavior(atck);
        }
    }
}
