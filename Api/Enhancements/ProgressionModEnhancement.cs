using BTD_Mod_Helper.Api.Bloons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements
{
    /// <summary>
    /// <inheritdoc/>
    /// <see cref="ProgressionModEnhancement{T}"/> without generics
    /// </summary>
    public abstract class ProgressionModEnhancement : ModEnhancement
    {
        /// <summary>
        /// Mod Enhancement to unlock
        /// </summary>
        protected abstract ModEnhancement EnhancementToUnlock { get; }

        public override uint Max => 5;

        public sealed override void OnLock()
        {
            EnhancementToUnlock.Locked = false;
        }
    }
    /// <summary>
    /// Unlocks a mod enhancement after this one is maxed out. Sets Max to 5 by default. Cannot unlock multiple enhancements at once. Override <see cref="ModEnhancement.OnLock"/> for that instead.
    /// </summary>
    /// <typeparam name="T">Mod Enhancement to unlock</typeparam>
    public abstract class ProgressionModEnhancement<T> : ProgressionModEnhancement where T : ModEnhancement
    {
        protected sealed override ModEnhancement EnhancementToUnlock => GetInstance<T>();
    }
}
