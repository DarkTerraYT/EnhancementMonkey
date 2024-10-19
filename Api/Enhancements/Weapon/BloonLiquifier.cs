namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class BloonLiquifier : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.BloonLiquefierUpgradeIcon;

        public override int BaseCost => 6500;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Great;

        protected override string TowerID => "GlueGunner-420";
    }
}
