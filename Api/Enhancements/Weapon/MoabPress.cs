namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class MoabPress : WeaponEnhancement
    {
        public override string EnhancementName => "MOAB Press";

        public override string Icon => VanillaSprites.MoabPressUpgradeIcon;

        public override int BaseCost => 4150;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Great;

        protected override string TowerID => "BoomerangMonkey-024";
    }
}
