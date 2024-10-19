namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class Icicles : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.IciclesUpgradeIcon;

        public override int BaseCost => 5415;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Great;

        protected override string TowerID => "IceMonkey-024";
    }
}
