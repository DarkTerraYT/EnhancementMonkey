namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class MaimMoab : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.MaimMoabUpgradeIcon;

        public override int BaseCost => 10625;

        public override string EnhancementName => "Miam MOAB";

        protected override string TowerID => "SniperMonkey-420";
    }
}
