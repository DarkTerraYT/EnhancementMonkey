using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enum
{
    /// <summary>
    /// Use AddedByMod for any custom enhancement classes (if they aren't ModEnhancements)
    /// </summary>
    public enum EnhancementGroup
    {
        Normal,
        Weapon,
        Ability,
        Misc,
        AddedByMod
    }
}
