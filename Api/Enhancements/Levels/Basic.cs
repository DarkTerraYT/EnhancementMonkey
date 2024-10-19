using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EnhancementMonkey.Api.Enhancements.Levels
{
    internal class Basic : EnhancementLevel
    {
        public override void Register()
        {
           Basic = this;
        }

        public override string Background => GetTextureGUID<EnhancementMonkey>(Name);

        public override int Cost => 0;

        public override Color BackgroundOverlayColor => Color.white;

        public override int Level => 1;
    }
}
