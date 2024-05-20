namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class SuperhotTacks : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.HotShotsUpgradeIcon;

        public override int BaseCost => 985;

        public override EnhancementLevel NewEnhancementLevel => EnhancementLevel.Good;

        protected override string TowerID => "TackShooter-300";
    }
}
