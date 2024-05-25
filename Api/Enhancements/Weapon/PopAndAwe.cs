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
    internal class PopAndAwe : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.PopandAweUpgradeIcon;

        public override int BaseCost => 39700;

        protected override string TowerID => "DartMonkey";

        protected override void ModifyAddedAttackModel(AttackModel attackModel)
        {
            attackModel.RemoveWeapon(attackModel.weapons[0]);

            var newWpn = Game.instance.model.GetTowerFromId("MortarMonkey-250").GetWeapon();
            attackModel.AddWeapon(newWpn);
        }
    }
}
