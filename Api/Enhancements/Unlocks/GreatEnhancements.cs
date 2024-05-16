namespace EnhancementMonkey.Api.Enhancements.Unlocks
{
    public class GreatEnhancements : ModEnhancement
    {
        public override string Icon => VanillaSprites.UpgradeIcon;

        public override string Description => "Unlocks all Great Enhancements (Level 3)";

        public override int BaseCost => 3500;

        public override int Priority => -3;

        public override bool LockAfterBuy => true;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Good;

        public override EnhancementType EnhancementGroup => EnhancementType.Misc;

        public override EnhancementLevel Background => EnhancementLevel.Great;

        public override ModifyType Modifies => ModifyType.Unlock;

        public override void ModifyOther()
        {
            UnlockedLevels.Add(EnhancementLevel.Great);
        }
    }
}
