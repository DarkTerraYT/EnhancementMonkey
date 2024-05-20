namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class SupplyDropSniper : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.CashDropUpgradeIcon;

        public override int BaseCost => 9845;

        protected override string TowerID => "SniperMonkey-042";
    }
}
