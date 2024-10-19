namespace EnhancementMonkey.Api.Ui.Submenues
{
    /// <summary>
    /// Stats submenu class
    /// </summary>
    public class NormalEnhancements : ModSubmenu
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        protected override int Order => 0;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override void Register()
        {
            Normal = this;
        }
    }
}
