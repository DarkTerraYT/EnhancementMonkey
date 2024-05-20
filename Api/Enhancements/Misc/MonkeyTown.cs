namespace EnhancementMonkey.Api.Enhancements.Misc
{
    internal class MonkeyTown : ModEnhancement
    {
        public override string Icon => VanillaSprites.MonkeyTownUpgradeIcon;

        public override string Description => "Extra cash per pop from THIS monkey (stacks with regular monkey town)";

        public override int BaseCost => 10000;

        public override EnhancementType EnhancementGroup => EnhancementType.Misc;

        public override ModifyType Modifies => ModifyType.Other;

        public override bool LockAfterBuy => true;

        public override void ModifyOther()
        {
            EnhancementMonkey.MonkeyTown = true;
        }
    }
}
