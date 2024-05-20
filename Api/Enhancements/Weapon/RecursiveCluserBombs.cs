namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class RecursiveCluserBombs : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.RecursiveClusterUpgradeIcon;

        public override int BaseCost => 3815;

        public override EnhancementLevel NewEnhancementLevel => EnhancementLevel.Great;

        protected override string TowerID => "BombShooter-204";
    }
}
