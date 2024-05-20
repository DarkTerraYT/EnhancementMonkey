namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class GlueHose : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.GlueHoseUpgradeIcon;

        public override int BaseCost => 3125;

        public override EnhancementLevel NewEnhancementLevel => EnhancementLevel.Great;

        protected override string TowerID => "GlueGunner-030";
    }
}
