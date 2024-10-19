namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class BloonSolver : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.TheBloonSolverUpgradeIcon;

        public override int BaseCost => 25455;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Awesome;

        protected override string TowerID => "GlueGunner-520";
    }
}
