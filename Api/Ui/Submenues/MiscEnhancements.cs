namespace EnhancementMonkey.Api.Ui.Submenues
{
    internal class MiscEnhancements : ModSubmenu
    {
        public override EnhancementSubmenuInfo Info => new("Misc", 3, Enum.EnhancementType.Misc, this);
    }
}
