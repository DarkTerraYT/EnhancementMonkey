using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using EnhancementMonkey.Api.Enum;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Simulation.Towers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Normal
{
    public class Pierce4 : ModEnhancement
    {
        public override string Icon => VanillaSprites.SharperDartsUpgradeIcon;

        public override string Description => "Increases the pierce by 6";

        public override int BaseCost => 1150;

        public override int Priority => 0;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Basic;

        public override ModifyType Modifies => ModifyType.Projectile;

        public override bool LockedByDefault => true;

        public override void ModifyTower(Tower tower)
        {
            var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();

            foreach (var projectile in towerModel.GetDescendants<ProjectileModel>().ToList())
            {
                if(projectile.GetDamageModel() != null)
                {
                    projectile.pierce += 6;
                }
            }

            tower.UpdateRootModel(towerModel);
        }

        public override void ModifyProjectile(ProjectileModel projectileModel)
        {
            projectileModel.pierce += 6;
        }

        public override EnhancementType EnhancementGroup => EnhancementType.Normal;
    }
}
