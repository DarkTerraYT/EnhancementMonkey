﻿namespace EnhancementMonkey.Api.Enhancements.Unlocks
{
    public class GoodEnhancements : UpgradeEnhancement
    {
        public override string Icon => VanillaSprites.UpgradeIcon;

        public override string Description => "Unlocks all Good Enhancements (Level 2)";

        public override int BaseCost => 1005;

        public override int Priority => -4;

        public override bool LockAfterBuy => true;

        public override EnhancementLevel NewEnhancementLevel => EnhancementLevel.Basic;

        public override bool AutoEnhancementLevel => false;

        public override EnhancementLevel Background => EnhancementLevel.Good;

        public override ModifyType Modifies => ModifyType.Unlock;

        public override void ModifyOther()
        {
            UnlockedLevels.Add(EnhancementLevel.Good);
        }
    }
}
