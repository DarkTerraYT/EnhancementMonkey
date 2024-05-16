namespace EnhancementMonkey.Api.Ui.Submenues
{
    public struct EnhancementSubmenuInfo(string name, int priority, EnhancementType group, ModSubmenu menu)
    {
        public string Name = name;
        public int Priority = priority;
        public EnhancementType Group = group;
        public ModSubmenu Menu = menu;
    }
}
