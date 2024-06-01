
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using System.Linq;

namespace EnhancementMonkey.Api.Enhancements.Normal
{
    public class Pierce3 : ProgressionModEnhancement<Pierce4>
    {
        public override string Icon => VanillaSprites.SharperDartsUpgradeIcon;

        public override string Description => "Increases the pierce by 4";

        public override int BaseCost => 950;

        public override int Priority => 0;

        public override uint Max => 8;

        public override bool LockedByDefault => true;

        public override EnhancementLevel NewEnhancementLevel => EnhancementLevel.Basic;

        public override string EnhancementName => "Pierce 3";

        public override ModifyType Modifies => ModifyType.Projectile;

        public override void ModifyTower(Il2CppAssets.Scripts.Simulation.Towers.Tower tower)
        {
            var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();

            foreach (var projectile in towerModel.GetDescendants<ProjectileModel>().ToList())
            {
                if (projectile.GetDamageModel() != null)
                {
                    projectile.pierce += 4;
                }
            }

            tower.UpdateRootModel(towerModel);
        }

        public override void ModifyProjectile(ProjectileModel projectileModel)
        {
            projectileModel.pierce += 4;
        }

        public override EnhancementType EnhancementGroup => EnhancementType.Normal;
    }
}
