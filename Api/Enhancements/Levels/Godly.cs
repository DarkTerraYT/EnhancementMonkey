using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EnhancementMonkey.Api.Enhancements.Levels
{
    internal class Godly : EnhancementLevel
    {
        public override void Register()
        {
           Godly = this;
        }

        public override int Cost => 35000;

        public override string Background => GetTextureGUID<EnhancementMonkey>(Name);

        public override int Level => 5;
    }
}
