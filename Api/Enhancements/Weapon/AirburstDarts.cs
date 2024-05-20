namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class AirburstDarts : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.AirburstDartsUpgradeIcon;

        public override int BaseCost => 1715;

        protected override string TowerID => "MonkeySub-002";
    }
}
