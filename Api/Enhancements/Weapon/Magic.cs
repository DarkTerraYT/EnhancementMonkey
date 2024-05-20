namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class Magic : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.IntenseMagicUpgradeIcon;

        public override string Description => "Gives the Enhancement Monkey magic bolts";

        public override int BaseCost => 250;

        public override EnhancementLevel NewEnhancementLevel => EnhancementLevel.Basic;

        protected override string TowerID => "WizardMonkey";
    }
}
