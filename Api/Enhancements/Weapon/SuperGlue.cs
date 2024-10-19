namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class SuperGlue : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.SuperGlueUpgradeIcon;

        public override int BaseCost => 28750;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Awesome;

        protected override string TowerID => "GlueGunner-025";
    }
}
