namespace EnhancementMonkey.Api.Enum
{
    /// <summary>
    /// Enum containing the different modification types
    /// </summary>
    public enum ModifyType
    {
        /// <summary>
        /// Unlocks something
        /// </summary>
        Unlock = -1,
        /// <summary>
        /// Doesn't change something directly connected to the tower
        /// </summary>
        Other,
        /// <summary>
        /// Chnages the tower
        /// </summary>
        Tower,
        /// <summary>
        /// Changes only the tower's weapons
        /// </summary>
        Weapon,
        /// <summary>
        /// Changes only the tower's projectiles
        /// </summary>
        Projectile,
        /// <summary>
        /// Changes both the tower's weapons and projectiles.
        /// </summary>
        WeaponAndProjectile,
    }
}
