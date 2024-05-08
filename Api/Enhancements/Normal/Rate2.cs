using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Simulation.Towers;
using System;

namespace EnhancementMonkey.Api.Enhancements.Normal
{
    internal class Rate2 : ProgressionModEnhancement<Rate3>
    {
        public override string Icon => VanillaSprites.FasterShootingUpgradeIcon2;

        public override string Description => "Makes each weapon shoot 25% faster";

        public override int BaseCost => 2500;

        public override int Priority => 0;
        public override float CostMultiplier => 1;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Good;

        public override EnhancementType EnhancementGroup => EnhancementType.Normal;

        public override ModifyType Modifies => ModifyType.Weapon;

        public override uint Max => 5;

        public override void ModifyTower(Tower tower)
        {
            var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();

            foreach(var weapon in towerModel.GetWeapons())
            {
                weapon.rate /= 1.25f;
            }

            tower.UpdateRootModel(towerModel);
        }

        public override void ModifyWeapon(WeaponModel weaponModel)
        {
            try
            {
                weaponModel.rate /= 1.25f;
            }
            catch(Exception e)
            {
                ModHelper.Error<Main>(e);
            }
        }
    }
}
