﻿using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class Blooncineration : ModEnhancement
    {
        public override string Icon => VanillaSprites.BurnyStuffUpgradeIcon;

        public override int BaseCost => 51400;

        public override EnhancementType EnhancementGroup => EnhancementType.Weapon;

        public override ModifyType Modifies => ModifyType.Tower;

        protected override void ModifyTower(TowerModel towerModel)
        {
            var atck = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel();
            atck.RemoveWeapon(atck.weapons[0]);

            var newWpn = Game.instance.model.GetTowerFromId("MortarMonkey-204").GetWeapon();
            atck.AddWeapon(newWpn);

            atck.range = towerModel.range;
            Apply(atck);

            if (!Game.instance.model.GetTowerFromId("MortarMonkey-204").GetDescendant<FilterInvisibleModel>().isActive)
            {
                hitCamo = true;
            }
            atck.GetDescendants<DamageModel>().ForEach(dmgModel =>
            {
                if (dmgModel.immuneBloonProperties != Il2Cpp.BloonProperties.Lead)
                {
                    hitLead = true;
                }
            });

            towerModel.AddBehavior(atck);
        }
    }
}
