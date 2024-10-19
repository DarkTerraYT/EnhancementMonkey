
using BTD_Mod_Helper.Extensions;
using EnhancementMonkey.Api.Ui.Submenues;using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Simulation.Towers;

namespace EnhancementMonkey.Api.Enhancements.Misc
{
    internal class Camo : ModEnhancement
    {
        public override string Icon => VanillaSprites.EnhancedEyesightUpgradeIcon;

        public override string Description => "Gives the tower camo vision";

        public override int BaseCost => 815;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Good;

        public override ModSubmenu Submenu => ModSubmenu.Misc;

        public override bool LockAfterBuy => true;

        public override ModifyType Modifies => ModifyType.Weapon;

        public override void ModifyTower(Tower tower)
        {
            hitCamo = true;

            var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();

            towerModel.GetDescendants<FilterInvisibleModel>().ForEach(mod => mod.isActive = false);
            towerModel.GetDescendants<ProjectileModel>().ForEach(proj => proj.SetHitCamo(true));

            tower.UpdateRootModel(towerModel);
        }

        public override void ModifyWeapon(WeaponModel weaponModel)
        {
            weaponModel.GetDescendants<ProjectileModel>().ForEach(proj => proj.SetHitCamo(true));
        }

        public override void ModifyTowerOnNewEnhancement(TowerModel towerModel)
        {
            towerModel.GetDescendants<FilterInvisibleModel>().ForEach(mod => mod.isActive = false);
        }
    }
}
