using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using EnhancementMonkey.Api.Enhancements.Templates;
using EnhancementMonkey.Api.Enum;
using Il2CppAssets.Scripts.Models.Towers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements
{
    public class Pierce : ModEnhancement
    {
        public override string Icon => VanillaSprites.SharperDartsUpgradeIcon;

        public override string Description => "Increases the pierce";

        public override int BaseCost => 550;

        public override int Priority => 1;

        public override EnhancementLevel EnhancementLevel => EnhancementLevel.Basic;

        public override void ModifyTowerModel(TowerModel towerModel)
        {
            foreach (var weapon in towerModel.GetWeapons())
            {
                weapon.projectile.pierce += 1;
            }
        }

        public override EnhancementGroup EnhancementGroup => EnhancementGroup.Normal;
    }
}
