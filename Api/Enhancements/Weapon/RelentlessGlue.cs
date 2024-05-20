namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class RelentlessGlue : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.RelentlessGlueUpgradeIcon;

        public override int BaseCost => 6340;

        public override EnhancementLevel NewEnhancementLevel => EnhancementLevel.Great;

        protected override string TowerID => "GlueGunner-024";
    }
}
