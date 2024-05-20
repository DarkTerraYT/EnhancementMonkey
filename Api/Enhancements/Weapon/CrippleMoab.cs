namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class CrippleMoab : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.CrippleMoabUpgradeIcon;

        public override int BaseCost => 42625;

        public override string EnhancementName => "Cripple MOAB";

        protected override string TowerID => "SniperMonkey-520";
    }
}
