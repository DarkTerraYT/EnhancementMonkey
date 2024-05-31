using Il2CppSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class Lightning : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.HeartofThunderUpgradeIcon;

        public override string Description => "Gives the enhancement monkey lightning.";

        public override int BaseCost => 720;

        protected override string TowerID => "Druid-200";

        protected override int Index => 1;
    }
}
