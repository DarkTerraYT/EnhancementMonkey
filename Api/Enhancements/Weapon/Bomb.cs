namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class Bomb : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.BiggerBombsUpgradeIcon;

        public override int BaseCost => 515;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Basic;

        protected override string TowerID => "BombShooter";
    }
}
