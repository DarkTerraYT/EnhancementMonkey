namespace EnhancementMonkey.Api.Ui.Submenues
{
    /// <summary>
    /// Weapons submenu class
    /// </summary>
    public class WeaponEnhancements : ModSubmenu
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        protected override int Order => 1;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override void Register()
        {
            Weapon = this;
        }
    }
}
