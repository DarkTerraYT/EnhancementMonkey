namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class IceShards : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.IceShardsUpgradeIcon;

        public override int BaseCost => 2130;

        public override EnhancementLevel NewEnhancementLevel => EnhancementLevel.Good;

        protected override string TowerID => "IceMonkey-300";
    }
}
