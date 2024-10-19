namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class GlaiveLord : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.GlaiveLordUpgradeIcon;

        public override int BaseCost => 33165;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Godly;

        protected override string TowerID => "BoomerangMonkey-520";
    }
}
