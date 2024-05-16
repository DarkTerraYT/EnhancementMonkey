namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class TurboChargeWeapon : WeaponEnhancement
    {
        public override string EnhancementName => "Turbo Charge (Weapon)";

        public override string Icon => VanillaSprites.TurbochargeUpgradeIcon;

        public override int BaseCost => 6150;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Great;

        protected override string TowerID => "BoomerangMonkey-042";
    }
}
