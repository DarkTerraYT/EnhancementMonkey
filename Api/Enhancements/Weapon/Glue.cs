namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class Glue : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.StrongerGlueUpgradeIcon;

        public override string Description => "Enhancement Monkey now shoots glue";

        public override int BaseCost => 155;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Basic;

        protected override string TowerID => "GlueGunner";
    }
}
