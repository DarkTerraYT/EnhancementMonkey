using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class Bank : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.MonkeyBankUpgradeIcon;

        public override int BaseCost => 5975;

        protected override string TowerID => "BananaFarm-030";

        protected override void ModifyTower(TowerModel towerModel)
        {
            towerModel.AddBehavior(Game.instance.model.GetTowerFromId(TowerID).GetBehavior<BankModel>());
        }
    }
}
