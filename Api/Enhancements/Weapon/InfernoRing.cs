namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class InfernoRing : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.InfernoRingUpgradeIcon;

        public override int BaseCost => 43585;

        public override EnhancementLevel NewEnhancementLevel => EnhancementLevel.Godly;

        protected override string TowerID => "TackShooter-502";
    }
}
