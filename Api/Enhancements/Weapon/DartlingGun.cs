namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class DartlingGun : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.FocusedFiringUpgradeIcon;

        public override int BaseCost => 850;

        public override EnhancementLevel NewEnhancementLevel => EnhancementLevel.Basic;

        protected override string TowerID => "DartlingGunner";
    }
}
