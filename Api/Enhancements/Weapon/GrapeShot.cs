namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class GrapeShot : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.GrapeShotUpgradeIcon;

        public override int BaseCost => 510;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Basic;

        protected override string TowerID => "MonkeyBuccaneer";

        protected override int Index => 1;
    }
}
