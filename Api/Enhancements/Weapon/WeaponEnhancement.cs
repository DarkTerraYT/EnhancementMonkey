using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    /// <summary>
    /// Makes it quicker to add a <see cref="Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel"/> with a <see cref="ModEnhancement"/>. Cannot be both a <see cref="WeaponEnhancement"/> and a <see cref="ProgressionModEnhancement"/> at the same time.
    /// </summary>
    abstract class WeaponEnhancement : ModEnhancement
    {
        public override EnhancementType EnhancementGroup => EnhancementType.Weapon;

        public override ModifyType Modifies => ModifyType.Tower;
        /// <summary>
        /// <inheritdoc/>
        /// On <see cref="WeaponEnhancement"/>s, it defaults to 1.1f;
        /// </summary>
        public override float CostMultiplier => 1.1f;

        protected abstract string towerID { get; }
        protected virtual int index => 0;
        protected virtual AttackModel AttackModel => Game.instance.model.GetTowerFromId(towerID).GetAttackModel(index).Duplicate();

        protected override void ModifyTower(TowerModel towerModel)
        {
            var attackModel = Apply(AttackModel);
            attackModel.range = towerModel.range;

            towerModel.AddBehavior(attackModel);
        }
    }
}
