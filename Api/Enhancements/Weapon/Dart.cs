namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class Dart : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.FasterDartsUpgradeIcon;

        public override string Description => "Gives the Enhancement Monkey a Dart";

        public override int BaseCost => 175;

        public override int Priority => 0;

        public override EnhancementLevel NewEnhancementLevel => EnhancementLevel.Basic;

        protected override string TowerID => "DartMonkey";
    }
}
