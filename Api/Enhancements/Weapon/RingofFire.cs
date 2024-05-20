namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class RingofFire : WeaponEnhancement
    {
        public override string EnhancementName => "Ring of Fire";

        public override string Icon => VanillaSprites.RingOfFireUpgradeIcon;

        public override int BaseCost => 3910;

        public override EnhancementLevel NewEnhancementLevel => EnhancementLevel.Great;

        protected override string TowerID => "TackShooter-402";
    }
}
