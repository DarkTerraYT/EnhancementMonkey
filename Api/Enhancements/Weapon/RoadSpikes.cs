namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class RoadSpikes : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.BiggerStacksUpgradeIcon;

        public override int BaseCost => 700;

        public override EnhancementLevel NewEnhancementLevel => EnhancementLevel.Basic;

        protected override string TowerID => "SpikeFactory";
    }
}
