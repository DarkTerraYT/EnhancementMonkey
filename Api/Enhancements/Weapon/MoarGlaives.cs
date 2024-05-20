namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class MoarGlaives : WeaponEnhancement
    {
        public override string EnhancementName => "M.O.A.R Glaives";

        public override string Icon => VanillaSprites.MoarGlaivesUpgradeIcon;

        public override int BaseCost => 4165;

        public override EnhancementLevel NewEnhancementLevel => EnhancementLevel.Great;

        protected override string TowerID => "BoomerangMonkey-420";
    }
}
