namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class Magic : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.IntenseMagicUpgradeIcon;

        public override string Description => "Gives the Enhancement Monkey a 000 bolt";

        public override int BaseCost => 250;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Basic;

        protected override string TowerID => "WizardMonkey";
    }
}
