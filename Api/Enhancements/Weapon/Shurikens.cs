namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class Shurikens : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.SharpShurikensUpgradeIcon;

        public override int BaseCost => 400;

        public override EnhancementLevel NewEnhancementLevel => EnhancementLevel.Basic;

        protected override string TowerID => "NinjaMonkey";
    }
}
