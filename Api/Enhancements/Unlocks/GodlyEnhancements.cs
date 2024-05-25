namespace EnhancementMonkey.Api.Enhancements.Unlocks
{
    public class GodlyEnhancements : UpgradeEnhancement
    {
        public override string Icon => VanillaSprites.UpgradeIcon;

        public override string Description => "Unlocks all Godly Enhancements (Level 5)";

        public override int BaseCost => 35000;

        public override int Priority => -1;

        public override bool LockAfterBuy => true;

        public override EnhancementLevel NewEnhancementLevel => EnhancementLevel.Awesome;

        public override EnhancementType EnhancementGroup => EnhancementType.Misc;

        public override EnhancementLevel Background => EnhancementLevel.Godly;

        public override bool AutoEnhancementLevel => false;

        public override ModifyType Modifies => ModifyType.Unlock;

        public override void ModifyOther()
        {
            UnlockedLevels.Add(EnhancementLevel.Godly);
        }
    }
}
