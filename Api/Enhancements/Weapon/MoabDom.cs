namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class MoabDom : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.MoabDominationUpgradeIcon;

        public override int BaseCost => 54100;

        public override EnhancementLevel NewEnhancementLevel => EnhancementLevel.Godly;

        protected override string TowerID => "BoomerangMonkey-025";
    }
}
