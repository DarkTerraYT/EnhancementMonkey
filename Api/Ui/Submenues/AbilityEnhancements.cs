namespace EnhancementMonkey.Api.Ui.Submenues
{
    internal class AbilityEnhancements : ModSubmenu
    {
        public override EnhancementSubmenuInfo Info => new("Abilities", 2, Enum.EnhancementType.Ability, this);

        protected override int Order => 2;

        public override string EmptyText => base.EmptyText + "\nThere are no basic abilities in the base mod.";
    }
}
