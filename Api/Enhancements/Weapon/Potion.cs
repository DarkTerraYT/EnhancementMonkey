namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class Potion : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.LargerPotionsUpgradeIcon;

        public override int BaseCost => 455;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Basic;

        protected override string TowerID => "Alchemist";
    }
}
