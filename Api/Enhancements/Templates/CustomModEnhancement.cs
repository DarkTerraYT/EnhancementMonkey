using EnhancementMonkey.Api.Enum;
using EnhancementMonkey.Api.ModSupport;
using Il2CppAssets.Scripts.Models.Towers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Templates
{
    /// <summary>
    /// Mod Enhancement that uses a custom enhancement group.
    /// </summary>
    public abstract class CustomModEnhancement : ModEnhancement
    {
        public override EnhancementGroup EnhancementGroup => EnhancementGroup.AddedByMod;
        public abstract CustomEnhancementGroup CustomEnhancementGroup { get; }

    }
}
