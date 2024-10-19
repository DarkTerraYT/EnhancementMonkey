namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class Ice : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.PermafrostUpgradeIcon;

        public override int BaseCost => 400;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Basic;

        protected override string TowerID => "IceMonkey-001";
    }
}
