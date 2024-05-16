namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class Nail : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.PinUpgradeIcon;

        public override int BaseCost => 340;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Basic;

        protected override string TowerID => "EngineerMonkey";
    }
}
