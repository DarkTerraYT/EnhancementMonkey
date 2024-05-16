namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class PermaChargeWeapon : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.PermaChargeUpgradeIcon;

        public override int BaseCost => 41500;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Godly;

        protected override string TowerID => "BoomerangMonkey-052";
    }
}
