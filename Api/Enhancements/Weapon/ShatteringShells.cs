using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhancementMonkey.Api.Enhancements.Weapon
{
    internal class ShatteringShells : WeaponEnhancement
    {
        public override string Icon => VanillaSprites.ShatteringShellsUpgradeIcon;

        public override int BaseCost => 12400;

        protected override string TowerID => "MortarMonkey-204";

        public override EnhancementType EnhancementGroup => EnhancementType.Weapon;

        public override ModifyType Modifies => ModifyType.Tower;

        protected override void ModifyTower(TowerModel towerModel)
        {
            var atck = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel();
            atck.RemoveWeapon(atck.weapons[0]);

            var newWpn = Game.instance.model.GetTowerFromId("MortarMonkey-205").GetWeapon();
            atck.AddWeapon(newWpn);

            atck.range = towerModel.range;
            Apply(atck);

            if (!Game.instance.model.GetTowerFromId("MortarMonkey-205").GetDescendant<FilterInvisibleModel>().isActive)
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
