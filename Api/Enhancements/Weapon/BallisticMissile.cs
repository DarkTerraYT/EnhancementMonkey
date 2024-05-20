namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class BallisticMissile : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.BallisticMissileUpgradeIcon;

        public override int BaseCost => 2450;

        protected override string TowerID => "MonkeySub-030";
    }
}
