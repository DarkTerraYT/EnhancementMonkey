namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class Missile : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.MissileLauncherUpgradeIcon;

        public override int BaseCost => 1050;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Good;

        protected override string TowerID => "BombShooter-020";
    }
}
