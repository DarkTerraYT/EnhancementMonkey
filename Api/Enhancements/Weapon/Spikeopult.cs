namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class Spikeopult : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.SpikeopultUpgradeIcon;

        public override int BaseCost => 555;

        public override EnhancementLevel NewEnhancementLevel => EnhancementLevel.Basic;

        protected override string TowerID => "DartMonkey-320";

        public override string EnhancementName => "Spike-o-pult";
    }
}
