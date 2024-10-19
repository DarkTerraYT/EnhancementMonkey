namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class IcicleImpale : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.IcicleImpaleUpgradeIcon;

        public override int BaseCost => 35415;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Awesome;

        protected override string TowerID => "IceMonkey-025";
    }
}
