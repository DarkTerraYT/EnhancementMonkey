using BTD_Mod_Helper.Api.Enums;
using EnhancementMonkey.Api.Enum;
using EnhancementMonkey.Api.Ui;

namespace EnhancementMonkey.Api.Enhancements.Misc
{
    public class PureEnhancements : ModEnhancement
    {
        public override string Icon => VanillaSprites.UpgradeIcon;

        public override string Description => "Unlocks all Pure Enhancements (Max Level)";

        public override int BaseCost => 135000;

        public override int Priority => 0;

        public override bool LockAfterBuy => true;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Godly;

        public override EnhancementType EnhancementGroup => EnhancementType.Misc;

        public override EnhancementLevel Background => EnhancementLevel.Pure;

        public override ModifyType Modifies => ModifyType.Unlock;

        public override void ModifyOther()
        {
             UnlockedLevels.Add(EnhancementLevel.Pure);
            MainUi.instance?.Close();
        }
    }
}
