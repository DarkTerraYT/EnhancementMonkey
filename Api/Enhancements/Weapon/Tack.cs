namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class Tack : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.FasterShootingUpgradeIcon;

        public override string Description => "Enhancement Monkey now shoots a tack";

        public override int BaseCost => 315;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Basic;

        protected override string TowerID => "TackShooter-001";
    }
}
