namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class Embrittlement : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.EmbrittlementUpgradeIcon;

        public override int BaseCost => 4000;

        public override EnhancementLevel NewEnhancementLevel => EnhancementLevel.Great;

        protected override string TowerID => "IceMonkey-402";
    }
}
