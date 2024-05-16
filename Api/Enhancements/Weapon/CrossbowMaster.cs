namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class CrossbowMaster : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.CrossBowMasterUpgradeIcon;

        public override int BaseCost => 24500;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Awesome;

        protected override string TowerID => "DartMonkey-025";
    }
}
