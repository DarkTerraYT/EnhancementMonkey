namespace EnhancementMonkey.Api.Enhancements.Unlocks
{
    public class PureEnhancements : UpgradeEnhancement
    {
        public override string Icon => VanillaSprites.UpgradeIcon;

        public override string Description => "Unlocks all Pure Enhancements (Max Level)";

        public override int BaseCost => 76000;

        public override int Priority => 0;

        public override bool LockAfterBuy => true;

        public override EnhancementLevel NewEnhancementLevel => EnhancementLevel.Godly;

        public override EnhancementType EnhancementGroup => EnhancementType.Hide;

        public override bool AutoEnhancementLevel => false;

        public override EnhancementLevel Background => EnhancementLevel.Pure;

        public override ModifyType Modifies => ModifyType.Unlock;

        public override void ModifyOther()
        {
            UnlockedLevels.Add(EnhancementLevel.Pure);
        }
    }
}
