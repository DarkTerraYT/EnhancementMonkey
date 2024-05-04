using BTD_Mod_Helper.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.ModSupport
{
    /// <summary>
    /// EnhancementGroup, but for mods instead. Used for making custom groups within your mods. Struct instead of enum since you'll be making your own (name only)
    /// </summary>
    public struct CustomEnhancementGroup(string name) : IModContent
    {
        public string Name = name;
    }
}
