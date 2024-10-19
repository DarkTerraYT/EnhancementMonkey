using BTD_Mod_Helper.Api;
using EnhancementMonkey.Api.Enhancements.Unlocks;
using Il2CppAssets.Scripts.Data.Behaviors.Abilities;
using System.Linq;
using UnityEngine;

namespace EnhancementMonkey.Api.Enhancements.Levels
{
    /// <summary>
    /// Class to create enhancement levels
    /// </summary>
    public abstract class EnhancementLevel : NamedModContent
    {
        /// <summary>
        /// rizzy
        /// </summary>
        protected override float RegistrationPriority => base.RegistrationPriority - 1;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override void Register() 
        {
            if (GenerateEnhancement)
            {
                ModEnhancement enhancement = new UpgradeEnhancement(Name, DisplayName, Cost, this, GetContent<EnhancementLevel>().First(level => level.Level == Level - 1) , Description);

                Enhancement = enhancement;
            }
            else
            {
                Enhancement = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsShown = true;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override string Name => base.Name + " Enhancements";

        /// <summary>
        /// Get the Hidden enhancement level
        /// </summary>
        public static EnhancementLevel Hidden { get; internal set; }
        /// <summary>
        /// Get the basic enhancement level
        /// </summary>
        public static EnhancementLevel Basic { get; internal set; }
        /// <summary>
        /// Get the good enhancement level
        /// </summary>
        public static EnhancementLevel Good { get; internal set; }
        /// <summary>
        /// Get the great enhancement level
        /// </summary>
        public static EnhancementLevel Great { get; internal set; }
        /// <summary>
        /// Get the awesome enhancement level
        /// </summary>
        public static EnhancementLevel Awesome { get; internal set; }
        /// <summary>
        /// Get the godly enhancement level
        /// </summary>
        public static EnhancementLevel Godly { get; internal set; }
        /// <summary>
        /// Get the pure enhancement level
        /// </summary>
        public static EnhancementLevel Pure { get; internal set; }
        /// <summary>
        /// Get the paragon enhancement level
        /// </summary>
        public static EnhancementLevel Paragon { get; internal set; }

        /// <summary>
        /// Gets an enhancement level with the provided id
        /// </summary>
        /// <param name="id">Id of the level</param>
        /// <returns></returns>
        public static EnhancementLevel GetLevel(string id)
        {
            return GetContent<EnhancementLevel>().First(x => x.Id == id);
        }

        /// <summary>
        /// The enhancement for this level. Only generated when registered
        /// </summary>
        public ModEnhancement Enhancement { get; internal set; }

        /// <summary>
        /// Create an enhancement for this level?
        /// </summary>
        public virtual bool GenerateEnhancement => true;

        /// <summary>
        /// The cost of this enhancement level
        /// </summary>
        public abstract int Cost { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        protected sealed override int Order => Level;

        internal virtual bool ShownInFiltersList => true;

        /// <summary>
        /// Description for the ModEnhancement
        /// </summary>
        public override string Description => $"Unlocks the {DisplayName} enhancements. (Level {Level})";

        /// <summary>
        /// Level of the enhancement level
        /// </summary>
        public abstract int Level { get; }

        /// <summary>
        /// Returns whether or not this level is unlocked or not
        /// </summary>
        public bool IsUnlocked()
        {
            return Level >= CurrentEnhancementLevel;
        }

        /// <summary>
        /// The background of the enhancement level. By default a colorless enhancement background, you can use <see cref="BackgroundOverlayColor"/> to change the color of it.
        /// </summary>
        public virtual string Background => GetTextureGUID<EnhancementMonkey>("EnhancementBackground");


        /// <summary>
        /// The overlay color of the background
        /// </summary>
        public virtual Color BackgroundOverlayColor { get => Color.white; }
    }
}
