namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class MoabAssassinWeapon : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.MoabAssassinUpgradeIcon;

        public override string EnhancementName => "Moab Assassin";

        public override int BaseCost => 5010;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Great;

        protected override string TowerID => "BombShooter-240";
    }
}
