using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EnhancementMonkey.Api.Enhancements.Levels
{
    internal class Good : EnhancementLevel
    {
        public override void Register()
        {
           Good = this;
        }

        public override int Cost => 1000;

        public override string Background => GetTextureGUID<EnhancementMonkey>(Name);

        public override int Level => 2;
    }
}
