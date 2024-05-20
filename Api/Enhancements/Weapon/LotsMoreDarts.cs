namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class LotsMoreDarts : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.LotsMoreDartsUpgradeIcon;

        public override int BaseCost => 1835;

        protected override string TowerID => "MonkeyAce-200";
    }
}
