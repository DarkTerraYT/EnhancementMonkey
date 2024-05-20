namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class BloonCrush : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.BloonCrushUpgradeIcon;

        public override int BaseCost => 51370;

        public override EnhancementLevel NewEnhancementLevel => EnhancementLevel.Godly;

        protected override string TowerID => "BombShooter-520";
    }
}
