using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.SimulationBehaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Normal
{
    internal class CashMultiplier : ModEnhancement
    {
        public override string Icon => VanillaSprites.ValuableBananasUpgradeIcon;

        public override int BaseCost => 6700;

        public override string Description => "10% Higher Cash Generation";

        public override uint Max => 10;

        public override EnhancementType EnhancementGroup => EnhancementType.Misc;

        public override ModifyType Modifies => ModifyType.Weapon;

        public override void ModifyWeapon(WeaponModel weaponModel)
        {
            foreach (var cashModel in weaponModel.GetDescendants<CashModel>().ToList())
            {
                cashModel.bonusMultiplier += 0.1f;
            }
        }

        public override void ModifyTowerOnNewEnhancement(TowerModel towerModel) // You can replace ModifyTower with this sometimes
        {
            foreach (var cashModel in towerModel.GetDescendants<CashModel>().ToList())
            {
                cashModel.bonusMultiplier += 0.1f;
            }
            foreach (var cashPerRound in towerModel.GetDescendants<BonusCashPerRoundModel>().ToList())
            {
                cashPerRound.baseCash *= 1.1f;
            }
            foreach (var loanModel in towerModel.GetDescendants<ImfLoanModel>().ToList())
            {
                loanModel.amount *= 1.1f;
            }
        }
    }
}
