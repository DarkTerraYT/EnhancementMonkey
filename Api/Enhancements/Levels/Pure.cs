using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EnhancementMonkey.Api.Enhancements.Levels
{
    internal class Pure : EnhancementLevel
    {
        public override void Register()
        {
           Pure = this;
        }

        public override int Cost => 76000;

        public override string Background => GetTextureGUID<EnhancementMonkey>(Name);

        public override int Level => 6;
    }
}
