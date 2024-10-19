using EnhancementMonkey.Api.Ui.Submenues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Unlocks
{
    internal class UpgradeEnhancement(string name, string dName, int cost, EnhancementLevel background, EnhancementLevel level, string description = null) : ModEnhancement
    {
        public override bool LockedByDefault => LevelsUnlocked;

        public override int BaseCost => cost;

        public override string Name => name;

        public override EnhancementLevel Background => background;

        public override string EnhancementName => dName;

        public override string Description => description ??= base.Description;

        public override string Icon => VanillaSprites.UpgradeIcon;

        public override ModifyType Modifies => ModifyType.Unlock;

        public override bool AutoEnhancementLevel => false;

        public override EnhancementLevel EnhancementLevel { get; internal set; } = level;

        public override ModSubmenu Submenu => ModSubmenu.Hidden;
    }
}
