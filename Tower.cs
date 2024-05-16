using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Unity.Display;
using System.Linq;

namespace EnhancementMonkey
{
    public class Tower : ModTower
    {
        public override TowerSet TowerSet => TowerSet.Primary;

        public override string BaseTower => TowerType.DartMonkey;

        public override string DisplayName => "Enhancement Monkey";

        public override string Icon => "EnhancementMonkey-Icon";

        public override string Portrait => Icon;

        public override int Cost => 0;

        public override string Description => "Use enhancements to level up this monkey. STARTS WITH NO ATTACKS!";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.range = 35;
            towerModel.RemoveBehavior<AttackModel>();
        }

        public override int ShopTowerCount => 1;
    }

    public class Display : ModTowerDisplay<Tower>
    {
        public override string BaseDisplay => GetDisplay(TowerType.DartMonkey);

        public override bool UseForTower(params int[] tiers) => tiers.Sum() >= 0;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            for (int i = 0; i < node.GetMeshRenderers().Count; i++)
            {
                SetMeshTexture(node, Name + i, i);
                SetMeshOutlineColor(node, new(0, 0.7f, 0), i);
            }
        }
    }

}
