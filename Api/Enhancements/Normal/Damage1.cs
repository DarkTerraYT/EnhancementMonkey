using BTD_Mod_Helper.Extensions;
using EnhancementMonkey.Api.Ui.Submenues;using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Normal
{
    internal class Damage1 : ProgressionModEnhancement<Damage2>
    {
        public override string Icon => VanillaSprites.LongCalibreUpgradeIcon;

        public override int BaseCost => 2500;

        public override string Description => "Increases damage by 1";

        public override string EnhancementName => "Damage 1";

        public override float CostMultiplier => 1.5f;

        public override ModSubmenu Submenu => ModSubmenu.Normal;

        public override ModifyType Modifies => ModifyType.Weapon;

        protected override void ModifyTower(TowerModel towerModel)
        {
            foreach(var damageModel in towerModel.GetDescendants<DamageModel>().ToList()) 
            {
                damageModel.damage++;
            }
        }

        public override void ModifyWeapon(WeaponModel weaponModel)
        {
            foreach(var damageModel in weaponModel.GetDescendants<DamageModel>().ToList()) 
            {
                damageModel.damage++;
            }
        }
    }
}
