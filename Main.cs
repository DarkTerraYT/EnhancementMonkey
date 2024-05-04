using MelonLoader;
using BTD_Mod_Helper;
using EnhancementMonkey;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.ModOptions;
using BTD_Mod_Helper.Api.Components;
using UnityEngine;
using System.Collections.Generic;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Simulation.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models;
using EnhancementMonkey.Api.Enhancements.Templates;
using EnhancementMonkey.Api.Ui;
using EnhancementMonkey.Api.Ui.Submenues;
using EnhancementMonkey.Api.Enum;

[assembly: MelonInfo(typeof(EnhancementMonkey.Main), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace EnhancementMonkey;

public class Main : BloonsTD6Mod
{
    public static bool menuOpen = false;

    public static List<EnhancementLevel> UnlockedLevels = [EnhancementLevel.Basic];

    public static List<ModEnhancement> Enhancements = [];

    public static List<ModSubmenu> EnhancementSubmenus = [];

    public static readonly ModSettingBool DebugMode = new(false)
    {
        description = "Does the mod output logs while loading? (For people who are adding new enhancements)",
        icon = VanillaSprites.SettingsIcon
    };

    public static readonly ModSettingBool OnAllTowers = new(false)
    {
        description = "Does the enhancement menu get shown on all towers? Might be a bit buggy."
    };

    public static readonly ModSettingBool LevelsUnlocked = new(false)
    {
        description = "Are all of the enhancement levels pre-unlocked?"
    };

    public static readonly ModSettingBool ShowHidden = new(false)
    {
        description = "Show hidden enhancements? (Be default there are none) "
    };

    public static Main Mod = new();

    public override void OnApplicationStart()
    {
        Mod = this;
        int currentPriorityNum = 0;

        List<ModEnhancement> enhancements_ = ModContent.GetContent<ModEnhancement>();
        while (enhancements_.Count > 0)
        {

            foreach (var enhancement in enhancements_)
            {
                if (enhancement.Priority == currentPriorityNum)
                {
                    Enhancements.Add(enhancement);
                    enhancements_.Remove(enhancement);
                    currentPriorityNum++;

                    if (DebugMode)
                    {
                        ModHelper.Log<Main>("Added Enhancement " + enhancement.EnhancementName + " To the list! (Prioity: " + enhancement.Priority + ")");
                    }
                }
                else
                {
                    return;
                }
            }
        }
    }


    public override void OnTowerSelected(Tower tower)
    {
        if (MainUi.instance != null)
        {
            MainUi.instance.Close();
        }

        if (tower.towerModel.baseId == ModContent.TowerID<EnhancementMonkey>() || OnAllTowers) { MainUi.CreateMainPanel(ModContent.GetContent<ModSubmenu>(), tower); }
    }

    public override void OnTowerDeselected(Tower tower)
    {
        if (MainUi.instance != null)
        {
            MainUi.instance.Close();
        }
    }
}