using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;

namespace EnhancementMonkey.Api.Enhancements.Misc
{
    internal class PlasmaSentries : ModEnhancement
    {
        public override string Icon => VanillaSprites.SentryParagonUpgradeIcon;

        public override int BaseCost => 34015;

        public override EnhancementLevel NewEnhancementLevel => EnhancementLevel.Basic;

        public override EnhancementType EnhancementGroup => EnhancementType.Misc;

        public override ModifyType Modifies => ModifyType.Tower;

        protected override void ModifyTower(TowerModel towerModel)
        {
            var atck = Game.instance.model.GetTowerFromId("EngineerMonkey-500").GetAttackModel(1).Duplicate();

            atck.name += Name + "Enhancement";
            
            Apply(atck);

            atck.range = towerModel.range;

            towerModel.AddBehavior(atck);
        }
    }
}
