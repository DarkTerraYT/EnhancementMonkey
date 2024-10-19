namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class SuperBrittle : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.SuperBrittleUpgradeIcon;

        public override int BaseCost => 27800;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Awesome;

        protected override string TowerID => "IceMonkey-502";
    }
}
