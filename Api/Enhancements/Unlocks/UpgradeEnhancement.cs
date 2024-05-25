using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Unlocks
{
    public abstract class UpgradeEnhancement : ModEnhancement
    {
        public override bool LockedByDefault => LevelsUnlocked;

        public override ModifyType Modifies => ModifyType.Unlock;

        public override bool AutoEnhancementLevel => false;

        public override EnhancementType EnhancementGroup => EnhancementType.Hide;
    }
}
