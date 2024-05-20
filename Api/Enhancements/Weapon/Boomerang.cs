namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class Boomerang : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.Boomerang2;

        public override string Description => "Gives the Enhancement Monkey a Boomerang";

        public override int BaseCost => 225;

        public override int Priority => 1;

        public override EnhancementLevel NewEnhancementLevel => EnhancementLevel.Basic;

        protected override string TowerID => "BoomerangMonkey";
    }
}
