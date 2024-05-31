using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;

using System;
using System.Collections.Generic;
using System.Linq;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    /// <summary>
    /// Makes it quicker to add a <see cref="Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel"/> with a <see cref="ModEnhancement"/>. Cannot be both a <see cref="WeaponEnhancement"/> and a <see cref="ProgressionModEnhancement"/> at the same time.
    /// </summary>
    public abstract class WeaponEnhancement : ModEnhancement
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

            if (EnhancementName.ToLower().Contains("the ") | EnhancementName[EnhancementName.Length - 1] == 's')
            {
                description = "Gives the Enhancement Monkey " + EnhancementName;
            }
            else if (vowels.Contains(EnhancementName[0].ToString().ToLower()))
            {
                description = "Gives the Enhancement Monkey an " + EnhancementName;
            }
            else
            {
                description = "Gives the Enhancement Monkey a " + EnhancementName;
            }

            return description;
        }
        /// <summary>
        /// Tower to get the attack model from
        /// </summary>
        protected abstract string TowerID { get; }
        /// <summary>
        /// Attack model index
        /// </summary>
        protected virtual int Index => 0;

        /// <summary>
        /// Does it add every attack model from that tower?
        /// </summary>
        protected virtual bool AddAll => false;

        protected virtual bool ChangeRange => true;

        private AttackModel AttackModel => Game.instance.model.GetTowerFromId(TowerID).GetAttackModel(Index).Duplicate();

        /// <summary>
        /// Ran before adding the attack model
        /// </summary>
        protected virtual void ModifyAddedAttackModel(AttackModel attackModel)
        {

        }

        /// <summary>
        /// Ran before adding the new attack models (only used if <see cref="AddAll"/> == true)
        /// </summary>
        protected virtual void ModifyAddedAttackModel(List<AttackModel> attackModels)
        {

        }

        protected override void ModifyTower(TowerModel towerModel)
        {
            if (!AddAll)
            {
                ModifyAddedAttackModel(AttackModel);

                var attackModel = Apply(AttackModel);
                if (ChangeRange)
                {
                    attackModel.range = towerModel.range;
                }

                towerModel.AddBehavior(attackModel);
            }
            else
            {
                List<AttackModel> attackModels = Game.instance.model.GetTowerFromId(TowerID).GetAttackModels().Duplicate();
                ModifyAddedAttackModel(attackModels);

                foreach(var attackModel in attackModels) 
                {
                    var attackModel_ = Apply(attackModel);
                    if (!towerModel.isGlobalRange)
                    {
                        attackModel_.range = towerModel.range;
                    }

                    if (!Game.instance.model.GetTowerFromId(TowerID).GetDescendant<FilterInvisibleModel>().isActive)
                    {
                        hitCamo = true;
                    }
                    attackModel_.GetDescendants<DamageModel>().ForEach(dmgModel =>
                    {
                        if (dmgModel.immuneBloonProperties != Il2Cpp.BloonProperties.Lead)
                        {
                            hitLead = true;
                        }
                    });

                    towerModel.AddBehavior(attackModel_);
                }
            }
        }
    }
}
