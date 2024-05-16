namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class BionicBoomerang : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.BionicBoomerangUpgradeIcon;

        public override int BaseCost => 2000;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Great;

        protected override string TowerID => "BoomerangMonkey-030";
    }
}
