using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class DarkChampion : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.DarkChampionUpgradeIcon;

        public override int BaseCost => 61855;

        protected override string TowerID => "SuperMonkey-204";
    }
}
