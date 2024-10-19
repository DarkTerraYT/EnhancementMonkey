using BTD_Mod_Helper.Extensions;
using EnhancementMonkey.Api.Ui.Submenues;using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using System.Linq;

namespace EnhancementMonkey.Api.Enhancements.Misc
{
    internal class Permabrew : ModEnhancement
    {
        public override string Icon => VanillaSprites.PermanentBrewUpgradeIcon;

        public override string Description => base.Description + " (Not including lead popping)";

        public override int BaseCost => 64000;

        public override ModSubmenu Submenu => ModSubmenu.Misc;

        public override ModifyType Modifies => ModifyType.Weapon;

        protected override void ModifyTower(TowerModel towerModel)
        {
            foreach (var proj in towerModel.GetDescendants<ProjectileModel>().ToList())
            {
                proj.pierce += 3;

                if (proj.GetDamageModel() != null)
                {
                    proj.GetDamageModel().damage += 1;
                    proj.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Ceramic", "Ceramic", 1, 1, false, false));
                    proj.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Moabs", "Moabs", 1, 1, false, false));
                    proj.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Fortified", "Fortified", 1, 1, false, false));
                }
            }
        }

        public override void ModifyWeapon(WeaponModel weaponModel)
        {
            foreach (var proj in weaponModel.GetDescendants<ProjectileModel>().ToList())
            {
                proj.pierce += 3;

                if (proj.GetDamageModel() != null)
                {
                    proj.GetDamageModel().damage += 1;
                    proj.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Ceramic", "Ceramic", 1, 1, false, false));
                    proj.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Moabs", "Moabs", 1, 1, false, false));
                    proj.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Fortified", "Fortified", 1, 1, false, false));
                }
            }
        }
    }
}
