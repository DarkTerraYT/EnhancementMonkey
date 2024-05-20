namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class Juggernaut : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.JuggernautUpgradeIcon;

        public override int BaseCost => 2655;

        public override EnhancementLevel NewEnhancementLevel => EnhancementLevel.Great;

        protected override string TowerID => "DartMonkey-420";
    }
}
