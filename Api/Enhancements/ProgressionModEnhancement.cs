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

        public virtual bool SameEnhancementLevel => true;

        public sealed override void OnLock()
        {
            if (SameEnhancementLevel)
            {
                EnhancementToUnlock.EnhancementLevel = EnhancementLevel;
            }
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
