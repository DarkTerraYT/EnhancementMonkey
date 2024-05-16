
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using System.Linq;

namespace EnhancementMonkey.Api.Enhancements.Normal
{
    public class Pierce1 : ProgressionModEnhancement<Pierce2>
    {
        public override string Icon => VanillaSprites.SharperDartsUpgradeIcon;

        public override string Description => "Increases the pierce by 1";

        public override int BaseCost => 550;

        public override int Priority => 0;

        public override uint Max => 8;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Basic;

        public override ModifyType Modifies => ModifyType.Projectile;

        public override void ModifyTower(Il2CppAssets.Scripts.Simulation.Towers.Tower tower)
        {
            var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();

            foreach (var projectile in towerModel.GetDescendants<ProjectileModel>().ToList())
            {
                if (projectile.GetDamageModel() != null)
                {
                    projectile.pierce += 1;
                }
            }

            tower.UpdateRootModel(towerModel);
        }

        public override void ModifyProjectile(ProjectileModel projectileModel)
        {
            projectileModel.pierce = 1;
        }

        public override EnhancementType EnhancementGroup => EnhancementType.Normal;
    }
}
