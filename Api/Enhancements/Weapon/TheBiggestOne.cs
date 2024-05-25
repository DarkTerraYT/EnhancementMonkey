using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class TheBiggestOne : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.TheBIgOneUpgradeIcon;

        public override int BaseCost => 44900;

        protected override string TowerID => "DartMonkey";

        protected override void ModifyAddedAttackModel(AttackModel attackModel)
        {
            attackModel.RemoveWeapon(attackModel.weapons[0]);

            var newWpn = Game.instance.model.GetTowerFromId("MortarMonkey-502").GetWeapon().Duplicate();
            attackModel.AddWeapon(newWpn);
        }
    }
}
