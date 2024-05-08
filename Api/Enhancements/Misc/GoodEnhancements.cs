﻿using BTD_Mod_Helper.Api.Enums;
using EnhancementMonkey.Api.Enum;
using EnhancementMonkey.Api.Ui;

namespace EnhancementMonkey.Api.Enhancements.Misc
{
    public class GoodEnhancements : ModEnhancement
    {
        public override string Icon => VanillaSprites.UpgradeIcon;

        public override string Description => "Unlocks all Good Enhancements (Level 2)";

        public override int BaseCost => 3000;

        public override int Priority => 0;

        public override bool LockAfterBuy => true;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Basic;

        public override EnhancementType EnhancementGroup => EnhancementType.Misc;

        public override EnhancementLevel Background => EnhancementLevel.Good;

        public override ModifyType Modifies => ModifyType.Unlock;

        public override void ModifyOther()
        {
             UnlockedLevels.Add(EnhancementLevel.Good);
            MainUi.instance?.Close();
        }
    }
}