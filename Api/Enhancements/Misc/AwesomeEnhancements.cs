using BTD_Mod_Helper.Api.Enums;
using EnhancementMonkey.Api.Enum;
using EnhancementMonkey.Api.Ui;

namespace EnhancementMonkey.Api.Enhancements.Misc
{
    public class AwesomeEnhancements : ModEnhancement
    {
        public override string Icon => VanillaSprites.UpgradeIcon;

        public override string Description => "Unlocks all Awesome Enhancements (Level 4)";

        public override int BaseCost => 21000;

        public override int Priority => 0;

        public override bool LockAfterBuy => true;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Great;

        public override EnhancementType EnhancementGroup => EnhancementType.Misc;

        public override EnhancementLevel Background => EnhancementLevel.Awesome;

        public override ModifyType Modifies => ModifyType.Unlock;

        public override void ModifyOther()
        {
             UnlockedLevels.Add(EnhancementLevel.Awesome);
            MainUi.instance?.Close();
        }
    }
}
