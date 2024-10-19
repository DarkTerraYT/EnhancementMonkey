namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class MoabMauler : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.MoabMaulerUpgradeIcon;

        public override int BaseCost => 1950;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Good;

        protected override string TowerID => "BombShooter-030";
    }
}
