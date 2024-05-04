using BTD_Mod_Helper.Api;
using EnhancementMonkey.Api.Enum;
using Il2CppAssets.Scripts.Models.Towers;

namespace EnhancementMonkey.Api.Enhancements.Templates
{
    public abstract class ModEnhancement : ModContent
    {
        // Methods
        public override void Register()
        {
            ActualCost = BaseCost;
        }

        /// <summary>
        /// Modifies the tower model on buy and changes the actual cost. 
        /// 
        /// Also does stuff related to locking.
        /// </summary>
        /// <param name="towerModel">The TowerModel that the enhancement's being applied to.</param>
        public void ApplyEnhancement(TowerModel towerModel)
        {
            ModifyTowerModel(towerModel);
            ActualCost = (int)(ActualCost * CostMultiplier);

            if (LockAfterBuy)
            {
                Locked = true;
            }
            if (TimesBought >= Max && Max > -1)
            {
                Locked = true;
            }
        }
        /// <summary>
        /// How this enhancement modifies the tower
        /// </summary>
        /// <param name="towerModel">The TowerModel that the enhancement's being applied to.</param>
        public abstract void ModifyTowerModel(TowerModel towerModel);

        //UI
        /// <summary>
        /// Icon GUID
        /// </summary>
        public abstract string Icon { get; }
        /// <summary>
        /// What's shown in the menu.
        /// </summary>
        public abstract string Description { get; }
        /// <summary>
        /// Name of the enhancement showed in the menu, by default the name of this mod content.
        /// </summary>
        public virtual string EnhancementName => Name;
        /// <summary>
        /// Prevent this enhancement from being bought after the first time it's bought
        /// </summary>
        public virtual bool LockAfterBuy => false;
        /// <summary>
        /// How many times this can be bought, -1 = unlimited
        /// </summary>
        public virtual int Max => -1;
        /// <summary>
        /// Used in the mod for locking
        /// </summary>
        public int TimesBought = 0;
        /// <summary>
        /// Can be bought
        /// </summary>
        public bool Locked = false;

        //Pricing
        /// <summary>
        /// Base Cost
        /// </summary>
        public abstract int BaseCost { get; }
        /// <summary>
        /// How much it currently costs
        /// </summary>
        public int ActualCost = 0;
        /// <summary>
        /// How much more it costs every upgrade (by default 1.5f)
        /// </summary>
        public virtual float CostMultiplier => 1.5f;

        //Sorting
        /// <summary>
        /// Where to be placed in the menu. Higher priority = further down in the menu.
        /// The priority is compared with the other enhancements in the enhancement level.
        /// Enchanments with the same priority will be organized by whatever's loaded first.
        /// </summary>
        public abstract int Priority { get; }
        /// <summary>
        /// The larger priority, changes the enhancement's color. Also makes it locked behind certain upgrades if the setting is turned on.
        /// </summary>
        public abstract EnhancementLevel EnhancementLevel { get; }
        /// <summary>
        /// Which submenu to put it in (normal is stat)
        /// </summary>
        public virtual EnhancementGroup EnhancementGroup { get; }
    }
}
