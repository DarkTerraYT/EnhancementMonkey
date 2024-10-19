namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class BloonImpact : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.BloonImpactUpgradeIcon;

        public override int BaseCost => 4710;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Great;

        protected override string TowerID => "BombShooter-420";
    }
}
