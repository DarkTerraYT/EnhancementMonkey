namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class EliteDefender : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.EliteDefenderUpgradeIcon;

        public override int BaseCost => 1;
        protected override string TowerID => "SniperMonkey-025";
    }
}
