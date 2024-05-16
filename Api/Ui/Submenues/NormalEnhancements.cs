namespace EnhancementMonkey.Api.Ui.Submenues
{
    public class NormalEnhancements : ModSubmenu
    {
        public override EnhancementSubmenuInfo Info => new("Stats", 0, EnhancementType.Normal, this);
    }
}
