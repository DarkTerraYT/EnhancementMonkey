namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class EliteDefender : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.EliteDefenderUpgradeIcon;

        public override int BaseCost => 22735;
        protected override string TowerID => "SniperMonkey-025";

        protected override bool ChangeRange => false;
    }
}
