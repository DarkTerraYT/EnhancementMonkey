namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class Mortar : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.BiggerBlastUpgradeIcon;

        public override int BaseCost => 400;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Basic;

        protected override string TowerID => "MortarMonkey";
    }
}
