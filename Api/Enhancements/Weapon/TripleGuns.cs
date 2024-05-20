namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class TripleGuns : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.AirburstDartsUpgradeIcon;

        public override int BaseCost => 2815;

        protected override string TowerID => "MonkeySub-003";
    }
}
