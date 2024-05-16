using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity;
using System;
using System.Linq;

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

        public override string Description => WeaponDescriptionBuilder();

        string WeaponDescriptionBuilder()
        {
            string description = "";

            string[] vowels = ["a", "e", "i", "o", "u"];

            if (EnhancementName.ToLower().Contains("the "))
            {
                description = "Gives the Enhancement Monkey " + EnhancementName;
            }
            else if (vowels.Contains(EnhancementName[1].ToString().ToLower()))
            {
                description = "Gives the Enhancement Monkey an " + EnhancementName;
            }
            else
            {
                description = "Gives the Enhancement Monkey a " + EnhancementName;
            }

            return description;
        }

        protected abstract string TowerID { get; }
        protected virtual int Index => 0;
        protected virtual AttackModel AttackModel => Game.instance.model.GetTowerFromId(TowerID).GetAttackModel(Index).Duplicate();

        protected override void ModifyTower(TowerModel towerModel)
        {
            var attackModel = Apply(AttackModel);
            attackModel.range = towerModel.range;

            if (!Game.instance.model.GetTowerFromId(TowerID).GetDescendant<FilterInvisibleModel>().isActive)
            {
                hitCamo = true;
            }
            attackModel.GetDescendants<DamageModel>().ForEach(dmgModel =>
            {
                if (dmgModel.immuneBloonProperties != Il2Cpp.BloonProperties.Lead)
                {
                    hitLead = true;
                }
            });

            towerModel.AddBehavior(attackModel);
        }
    }
}
