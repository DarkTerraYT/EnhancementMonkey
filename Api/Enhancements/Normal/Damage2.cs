using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Models.Towers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTD_Mod_Helper.Extensions;

namespace EnhancementMonkey.Api.Enhancements.Normal
{
    internal class Damage2 : ModEnhancement
    {
        public override string Icon => VanillaSprites.LongCalibreUpgradeIcon;

        public override int BaseCost => 5500;

        public override string Description => "Increases damage by 2";

        public override float CostMultiplier => 1.5f;

        public override EnhancementType EnhancementGroup => EnhancementType.Normal;

        public override ModifyType Modifies => ModifyType.Weapon;

        protected override void ModifyTower(TowerModel towerModel)
        {
            foreach (var damageModel in towerModel.GetDescendants<DamageModel>().ToList())
            {
                damageModel.damage += 2;
            }
        }

        public override void ModifyWeapon(WeaponModel weaponModel)
        {
            foreach (var damageModel in weaponModel.GetDescendants<DamageModel>().ToList())
            {
                damageModel.damage += 2;
            }
        }
    }
}
