namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class ClusterBomb : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.ClusterBombsUpgradeIcon;

        public override int BaseCost => 1550;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Good;

        protected override string TowerID => "BombShooter-003";
    }
}
