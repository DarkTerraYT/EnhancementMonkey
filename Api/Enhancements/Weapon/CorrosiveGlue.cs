namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class CorrosiveGlue : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.CorrosiveGlueUpgradeIcon;

        public override int BaseCost => 710;

        public override EnhancementLevel NewEnhancementLevel => EnhancementLevel.Basic;

        protected override string TowerID => "GlueGunner-200";
    }
}
