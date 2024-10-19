using BTD_Mod_Helper.Extensions;
using EnhancementMonkey.Api.Ui.Submenues;using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Misc
{
    internal class BananaFarmer : ModEnhancement
    {
        public override string Icon => VanillaSprites.BananaFarmerPortrait;

        public override int BaseCost => 4550;

        public override ModSubmenu Submenu => ModSubmenu.Misc;

        public override ModifyType Modifies => ModifyType.Projectile;

        public override bool LockAfterBuy => true;

        protected override void ModifyTower(TowerModel towerModel)
        {
            foreach(var weapon in towerModel.GetWeapons()) 
            {
                foreach (var projectile in weapon.GetDescendants<ProjectileModel>().ToList())
                {
                    if (projectile.HasBehavior<CashModel>())
                    {
                        projectile.GetBehavior<CashModel>().salvage = 1;
                        if (projectile.HasBehavior<AgeModel>())
                        {
                            projectile.GetBehavior<AgeModel>().lifespan = 0;
                        }
                    }
                }
            }
        }

        public override void ModifyProjectile(ProjectileModel projectile)
        {
            if (projectile.HasBehavior<CashModel>())
            {
                projectile.GetBehavior<CashModel>().salvage = 1;
                if (projectile.HasBehavior<AgeModel>())
                {
                    projectile.GetBehavior<AgeModel>().lifespan = 0;
                }
            }
        }
    }
}
