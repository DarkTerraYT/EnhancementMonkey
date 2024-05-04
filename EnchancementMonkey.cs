using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Unity.Display;
using System.Linq;
using UnityEngine;

namespace EnhancementMonkey
{
    public class EnhancementMonkey: ModTower
    {
        public override TowerSet TowerSet => TowerSet.Primary;

        public override string BaseTower => TowerType.DartMonkey;

        public override string Icon => Portrait;

        public override int Cost => 200;

        public override string Description => "Use enhancements to level up this monkey.";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {

        }
    }

    public class Display : ModTowerDisplay<EnhancementMonkey>
    {
        public override string BaseDisplay => GetDisplay(TowerType.DartMonkey);

        public override bool UseForTower(params int[] tiers) => tiers.Sum() >= 0;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            for(int i = 0; i < node.GetMeshRenderers().Count; i++)
            {
                SetMeshTexture(node, Name, i);
                SetMeshOutlineColor(node, new(0, 0.7f, 0), i);
            }
        }
    }

}
