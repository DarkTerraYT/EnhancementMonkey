namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class FullAutoRifle : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.FullAutoRifleUpgradeIcon;

        public override int BaseCost => 8135;

        protected override string TowerID => "SniperMonkey-204"; protected override bool ChangeRange => false;
    }
}
