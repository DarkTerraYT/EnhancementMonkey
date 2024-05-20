namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class Glaives : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.GlaivesUpgradeIcon;

        public override int BaseCost => 565;

        public override EnhancementLevel NewEnhancementLevel => EnhancementLevel.Basic;

        protected override string TowerID => "DartMonkey-220";
    }
}
