using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using EnhancementMonkey.Api.Enum;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Playables;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class Dart : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.FasterDartsUpgradeIcon;

        public override string Description => "Gives the Enhancement Monkey a Dart";

        public override int BaseCost => 175;

        public override int Priority => 0;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Basic;

        protected override string towerID => "DartMonkey";
    }
}
