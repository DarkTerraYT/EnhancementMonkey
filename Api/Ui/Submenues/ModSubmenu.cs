using BTD_Mod_Helper.Api;

namespace EnhancementMonkey.Api.Ui.Submenues
{
    public abstract class ModSubmenu : ModContent
    {
        public override void Register()
        {
        
        }

        public abstract EnhancementSubmenuInfo Info { get; }
    }
}
