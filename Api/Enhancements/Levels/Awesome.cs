using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EnhancementMonkey.Api.Enhancements.Levels
{
    internal class Awesome : EnhancementLevel
    {
        public override void Register()
        {
           Awesome = this;
        }

        public override int Cost => 15500;

        public override string Background => GetTextureGUID<EnhancementMonkey>(Name);

        public override int Level => 4;
    }
}
