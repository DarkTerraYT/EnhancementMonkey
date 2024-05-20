namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class Crossbow : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.CrossBowUpgradeIcon;

        public override int BaseCost => 815;

        public override EnhancementLevel NewEnhancementLevel => EnhancementLevel.Good;

        protected override string TowerID => "DartMonkey-023";
    }
}
