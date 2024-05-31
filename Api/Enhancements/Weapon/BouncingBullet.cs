namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class BouncingBullet : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.BouncingBulletUpgradeIcon;

        public override int BaseCost => 3245;

        protected override string TowerID => "SniperMonkey-030";

        protected override bool ChangeRange => false;
    }
}
