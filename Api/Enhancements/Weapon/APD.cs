namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class APD : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.ArmorPiercingDartsUpgradeIcon;

        public override string EnhancementName => "Armor Piercing Darts";

        public override int BaseCost => 5815;

        protected override string TowerID => "MonkeySub-024";
    }
}
