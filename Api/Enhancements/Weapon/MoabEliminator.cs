namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class MoabEliminator : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.MoabEliminatorUpgradeIcon;

        public override int BaseCost => 31500;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Awesome;

        protected override string TowerID => "BombShooter-250";
    }
}
