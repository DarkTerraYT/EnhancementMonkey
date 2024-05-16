namespace EnhancementMonkey.Api.Ui.Submenues
{
    public class WeaponEnhancements : ModSubmenu
    {
        public override EnhancementSubmenuInfo Info => new("Weapons", 1, EnhancementType.Weapon, this);
    }
}
