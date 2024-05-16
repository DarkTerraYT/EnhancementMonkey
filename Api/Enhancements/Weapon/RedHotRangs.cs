namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class RedHotRangs : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.RedHotRangsUpgradeIcon;

        public override int BaseCost => 510;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Basic;

        protected override string TowerID => "BoomerangMonkey-002";
    }
}
