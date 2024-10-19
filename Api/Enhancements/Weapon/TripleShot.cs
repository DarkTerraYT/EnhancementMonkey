namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class TripleShot : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.TripleShotUpgradeIcon;

        public override int BaseCost => 720;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Good;

        protected override string TowerID => "DartMonkey-030";
    }
}
