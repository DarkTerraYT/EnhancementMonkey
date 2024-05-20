namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class ReallyBigBomb : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.ReallyBigBombsUpgradeIcon;

        public override int BaseCost => 1950;

        public override EnhancementLevel NewEnhancementLevel => EnhancementLevel.Good;

        protected override string TowerID => "BombShooter-300";
    }
}
