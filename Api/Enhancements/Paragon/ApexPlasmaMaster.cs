using BTD_Mod_Helper.Extensions;
using EnhancementMonkey.Api.Enhancements.Ability;
using EnhancementMonkey.Api.Enhancements.Weapon;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Paragon
{
    internal class ApexPlasmaMaster : ParagonEnhancement
    {
        public override List<ModEnhancement> RequiredEnhancements => [GetInstance<CrossbowMaster>(), GetInstance<UltraJuggernaut>(), GetInstance<PlasmaMonkeyFanClub>()];

        public override string Icon => VanillaSprites.ApexPlasmaMasterUpgradeIcon;

        public override int BaseCost => 150000;

        public override ModifyType Modifies => ModifyType.Tower;

        protected override void ModifyTower(TowerModel towerModel)
        {
            foreach(AttackModel attack in Game.instance.model.GetTowerFromId("DartMonkey-Paragon").GetAttackModels()) 
            {
                towerModel.AddBehavior(attack);
            }
        }
    }
}
