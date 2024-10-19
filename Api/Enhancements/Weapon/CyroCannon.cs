namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class CyroCannon : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.CryoCannonUpgradeIcon;

        public override int BaseCost => 3125;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Great;

        protected override string TowerID => "IceMonkey-003";
    }
}
