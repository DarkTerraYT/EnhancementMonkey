namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class DartlingGunner : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.FocusedFiringUpgradeIcon;

        public override int BaseCost => 500;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Basic;

        protected override string TowerID => "DartlingGunner";
    }
}
