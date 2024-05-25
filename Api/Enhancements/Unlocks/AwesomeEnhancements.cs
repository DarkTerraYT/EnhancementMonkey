namespace EnhancementMonkey.Api.Enhancements.Unlocks
{
    public class AwesomeEnhancements : UpgradeEnhancement
    {
        public override string Icon => VanillaSprites.UpgradeIcon;

        public override string Description => "Unlocks all Awesome Enhancements (Level 4)";

        public override int BaseCost => 15500;

        public override int Priority => -2;

        public override bool LockAfterBuy => true;

        public override EnhancementLevel NewEnhancementLevel => EnhancementLevel.Great;

        public override EnhancementType EnhancementGroup => EnhancementType.Misc;

        public override EnhancementLevel Background => EnhancementLevel.Awesome;

        public override bool AutoEnhancementLevel => false;

        public override ModifyType Modifies => ModifyType.Unlock;

        public override void ModifyOther()
        {
            UnlockedLevels.Add(EnhancementLevel.Awesome);
        }
    }
}
