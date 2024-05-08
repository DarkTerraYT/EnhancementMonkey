using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Enums;
using EnhancementMonkey.Api.Enum;
using EnhancementMonkey.Api.Ui;

namespace EnhancementMonkey.Api.Enhancements.Misc
{
    public class GreatEnhancements : ModEnhancement
    {
        public override string Icon => VanillaSprites.UpgradeIcon;

        public override string Description => "Unlocks all Great Enhancements (Level 3)";

        public override int BaseCost => 7500;

        public override int Priority => 0;

        public override bool LockAfterBuy => true;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Good;

        public override EnhancementType EnhancementGroup => EnhancementType.Misc;

        public override EnhancementLevel Background => EnhancementLevel.Great;

        public override ModifyType Modifies => ModifyType.Unlock;

        public override void ModifyOther()
        {
             UnlockedLevels.Add(EnhancementLevel.Great);
            MainUi.instance?.Close();
        }
    }
}
