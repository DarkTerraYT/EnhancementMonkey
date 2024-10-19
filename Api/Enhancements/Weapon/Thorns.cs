namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class Thorns : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.HardThornsUpgradeIcon;

        public override int BaseCost => 345;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Basic;

        protected override string TowerID => "Druid";
    }
}
