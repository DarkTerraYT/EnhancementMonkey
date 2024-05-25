using BananaFarmParagon.bananafarmfake;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using weapondisplays;

namespace EnhancementMonkey.Api.Enhancements.Paragon
{
    internal class ThePinicleOfBananaProduction : ParagonEnhancement
    {
        public override List<ModEnhancement> RequiredEnhancements => [];

        public override string Icon => GetTextureGUID<BananaFarmParagon.Main>("BananaFarmParagon-Portrait");

        public override string? ModID => "BananaFarmParagon";

        public override string Description => base.Description + ". Made by JonyBoyLovesPie";

        public override int BaseCost => 10000000;

        public override ModifyType Modifies => ModifyType.Tower;

        protected override void ModifyTower(TowerModel towerModel)
        {
            var attackModel = Game.instance.model.GetTowerFromId("BananaFarm-500").GetAttackModel();
            attackModel.range += 99999999999999;
            var projectile = attackModel.weapons[0].projectile;
            var weapon = attackModel.weapons[0];
            towerModel.RemoveBehavior<BananaCentralBuffModel>();
            projectile.GetBehavior<CashModel>().minimum = 100000;
            projectile.GetBehavior<CashModel>().maximum = 100000;
            projectile.GetBehavior<CashModel>().salvage = 1;
            weapon.GetBehavior<EmissionsPerRoundFilterModel>().count = 10;
            towerModel.AddBehavior(Game.instance.model.GetTowerFromId("MonkeyVillage-004").GetBehavior<MonkeyCityIncomeSupportModel>().Duplicate());
            towerModel.GetBehavior<MonkeyCityIncomeSupportModel>().incomeModifier = 10;
            towerModel.GetBehavior<MonkeyCityIncomeSupportModel>().buffIconName = "";
            towerModel.GetBehavior<MonkeyCityIncomeSupportModel>().onlyShowBuffIfMutated = false;
            towerModel.GetBehavior<MonkeyCityIncomeSupportModel>().showBuffIcon = true;
            towerModel.GetBehavior<MonkeyCityIncomeSupportModel>().isGlobal = true;
            projectile.GetBehavior<AgeModel>().Lifespan = 0;
            projectile.GetBehavior<AgeModel>().rounds = 9999999;
            var farm = Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModel().Duplicate();
            farm.range = towerModel.range;
            farm.name = "Farm_Weapon";
            farm.weapons[0].Rate = 100f;
            farm.weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
            farm.weapons[0].projectile.ApplyDisplay<BananaDisplay>();
            farm.weapons[0].projectile.AddBehavior(new CreateTowerModel("BananaFarm000place", GetTowerModel<BananaFarmer>().Duplicate(), 0f, true, true, false, true, true));
            Apply(farm);
            Apply(attackModel);
            towerModel.AddBehavior(farm);
            towerModel.AddBehavior(attackModel);
            farm.RemoveBehavior<RotateToTargetModel>();
        }
    }
}
