using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EnhancementMonkey.Api.Enhancements.Levels
{
    internal class Great : EnhancementLevel
    {
        public override void Register()
        {
           Great = this;
        }

        public override int Cost => 3500;

        public override string Background => GetTextureGUID<EnhancementMonkey>(Name);

        public override int Level => 3;
    }
}
