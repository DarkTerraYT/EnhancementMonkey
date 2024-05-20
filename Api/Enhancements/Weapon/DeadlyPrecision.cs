namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class DeadlyPrecision : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.DeadlyPrecisionUpgradeIcon;

        public override int BaseCost => 4975;

        protected override string TowerID => "SniperMonkey-300";
    }
}
