

using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using System;

namespace EnhancementMonkey.Api.Enhancements.Normal
{
    internal class Rate1 : ProgressionModEnhancement<Rate2>
    {
        public override string Icon => VanillaSprites.FasterShootingUpgradeIcon2;

        public override string Description => "Makes each weapon shoot 10% faster";

        public override int BaseCost => 950;

        public override int Priority => 0;
        public override float CostMultiplier => 1;

        public override EnhancementLevel NewEnhancementLevel => EnhancementLevel.Good;

        public override EnhancementType EnhancementGroup => EnhancementType.Normal;

        public override ModifyType Modifies => ModifyType.Weapon;

        public override uint Max => 5;

        public override void ModifyTower(Il2CppAssets.Scripts.Simulation.Towers.Tower tower)
        {
            var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();

            foreach (var weapon in towerModel.GetWeapons())
            {
                weapon.rate /= 1.1f;
            }

            tower.UpdateRootModel(towerModel);
        }

        public override void ModifyWeapon(WeaponModel weaponModel)
        {
            try
            {
                weaponModel.rate /= 1.1f;
            }
            catch (Exception e)
            {
                Error<EnhancementMonkey>(e);
            }
        }
    }
}
