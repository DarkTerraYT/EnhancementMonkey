using BTD_Mod_Helper.Api;
using System.Collections.Generic;

namespace EnhancementMonkey.Api.Enhancements.Paragon
{
    /// <summary>
    /// Mod Enhancement class for creating an enhancement that requires other enhancements to unlock.
    /// </summary>
    public abstract class ParagonEnhancement : ModEnhancement
    {
        public override bool AutoEnhancementLevel => false;

        public override EnhancementLevel NewEnhancementLevel => EnhancementLevel.Paragon;

        public override EnhancementType EnhancementGroup => EnhancementType.Paragon;

        /// <summary>
        /// <see cref="ModContent.Name"/>s of the required enhancements to unlock this enhancement
        /// </summary>
        public abstract List<ModEnhancement> RequiredEnhancements { get; }

        public bool HasRequirements = false;

        public virtual string UnlockText => "You've Unlocked the Paragon Enhancement " + EnhancementName + "!";
    }

    /// <summary>
    /// <inheritdoc/> With Generics. If you don't need all three just put one of the others multiple times
    /// </summary>
    /// <typeparam name="T">Enhancement 1</typeparam>
    /// <typeparam name="K">Enhancement 2</typeparam>
    /// <typeparam name="U">Enhancement 3</typeparam>
    public abstract class ParagonEnhancement<T, K, U> : ParagonEnhancement where T : ModEnhancement where K : ModEnhancement where U : ModEnhancement 
    {
        public override List<ModEnhancement> RequiredEnhancements => [GetInstance<T>(), GetInstance<K>(), GetInstance<U>()];
    }
}
