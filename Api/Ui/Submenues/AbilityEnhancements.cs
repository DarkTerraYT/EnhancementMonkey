namespace EnhancementMonkey.Api.Ui.Submenues
{
    internal class AbilityEnhancements : ModSubmenu
    {
        public override EnhancementSubmenuInfo Info => new("Abilities", 2, Enum.EnhancementType.Ability, this);
    }
}
