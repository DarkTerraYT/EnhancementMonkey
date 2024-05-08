using BTD_Mod_Helper.Api.Enums;
using EnhancementMonkey.Api.Enum;
using EnhancementMonkey.Api.Ui;

namespace EnhancementMonkey.Api.Enhancements.Misc
{
    public class GodlyEnhancements : ModEnhancement
    {
        public override string Icon => VanillaSprites.UpgradeIcon;

        public override string Description => "Unlocks all Godly Enhancements (Level 5)";

        public override int BaseCost => 55000;

        public override int Priority => 0;

        public override bool LockAfterBuy => true;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Awesome;

        public override EnhancementType EnhancementGroup => EnhancementType.Misc;

        public override EnhancementLevel Background => EnhancementLevel.Godly;

        public override ModifyType Modifies => ModifyType.Unlock;

        public override void ModifyOther()
        {
             UnlockedLevels.Add(EnhancementLevel.Godly);
            MainUi.instance?.Close();
        }
    }
}
