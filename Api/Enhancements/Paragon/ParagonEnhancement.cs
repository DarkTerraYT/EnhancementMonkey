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

        public override uint Max => 1;

        /// <summary>
        /// <see cref="ModContent.Name"/>s of the required enhancements to unlock this enhancement
        /// </summary>
        public abstract List<ModEnhancement> RequiredEnhancements { get; }

        public bool HasRequirements = false;

        public virtual string UnlockText => "You've Unlocked the Paragon Enhancement " + EnhancementName + "!";
    }
}
