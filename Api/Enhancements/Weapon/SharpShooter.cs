namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class SharpShooter : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.SharpShooterUpgradeIcon;

        public override int BaseCost => 2815;

        public override EnhancementLevel NewEnhancementLevel => EnhancementLevel.Great;

        protected override string TowerID => "DartMonkey-024";
    }
}
