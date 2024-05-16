namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class UltraJuggernaut : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.UltraJuggernautUpgradeIcon;

        public override int BaseCost => 17800;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Awesome;

        protected override string TowerID => "DartMonkey-520";
    }
}
