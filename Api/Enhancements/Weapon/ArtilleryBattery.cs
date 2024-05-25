using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class ArtilleryBattery : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.ArtilleryBatteryUpgradeIcon;

        public override int BaseCost => 7700;

        protected override string TowerID => "DartMonkey";

        protected override void ModifyAddedAttackModel(AttackModel attackModel)
        {
            attackModel.RemoveWeapon(attackModel.weapons[0]);

            var newWpn = Game.instance.model.GetTowerFromId("MortarMonkey-240").GetWeapon();
            attackModel.AddWeapon(newWpn);
        }
    }
}
