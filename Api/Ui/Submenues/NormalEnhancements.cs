using EnhancementMonkey.Api.Enum;

namespace EnhancementMonkey.Api.Ui.Submenues
{
    public class NormalEnhancements : ModSubmenu
    {
        public override EnhancementSubmenuInfo Info => new("Stats", 0, EnhancementGroup.Normal, this);
    }
}
