namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class EliteSniper : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.EliteSniperUpgradeIcon;

        public override int BaseCost => 20845;

        protected override string TowerID => "SniperMonkey-052";
    }
}
