namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class TwinGuns : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.TwinGunsUpgradeIcon;

        public override string Description => "Gives the enhancement Twin Guns";

        public override int BaseCost => 715;

        public override EnhancementLevel NewEnhancementLevel => EnhancementLevel.Good;

        protected override string TowerID => "MonkeySub-001";
    }
}
