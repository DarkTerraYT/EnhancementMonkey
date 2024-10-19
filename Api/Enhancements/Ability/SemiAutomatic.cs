using EnhancementMonkey.Api.Enhancements.Weapon;

namespace EnhancementMonkey.Api.Enhancements.Ability
{
    internal class SemiAutomatic : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.SemiAutomaticUpgradeIcon;

        public override string EnhancementName => "Semi-Automatic Sniper";

        public override int BaseCost => 4250;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Great;

        protected override string TowerID => "SniperMonkey-003";
    }
}
