namespace EnhancementMonkey.Api.Ui.Submenues
{
    internal class AbilityEnhancements : ModSubmenu
    {
        public override void Register()
        {
            Ability = this;
        }

        protected override int Order => 2;

        public override string EmptyText => base.EmptyText + "\nThere are no basic abilities in the base mod.";
    }
}
