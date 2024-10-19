namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class BloonDissolver : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.BloonDissolverUpgradeIcon;

        public override int BaseCost => 3100;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Great;

        protected override string TowerID => "GlueGunner-300";
    }
}
