namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class MoabGlue : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.MoabGlueUpgradeIcon;

        public override int BaseCost => 4090;

        public override EnhancementLevel NewEnhancementLevel => EnhancementLevel.Great;

        protected override string TowerID => "GlueGunner-003";
    }
}
