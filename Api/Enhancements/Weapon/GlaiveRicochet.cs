namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class GlaiveRicochet : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.GlaiveRicochetUpgradeIcon;

        public override int BaseCost => 1165;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Good;

        protected override string TowerID => "BoomerangMonkey-320";
    }
}
