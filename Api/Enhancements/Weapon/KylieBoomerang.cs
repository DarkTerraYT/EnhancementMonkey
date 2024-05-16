namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class KylieBoomerang : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.KylieBoomerangUpgradeIcon;

        public override int BaseCost => 1610;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Good;

        protected override string TowerID => "BoomerangMonkey-023";
    }
}
