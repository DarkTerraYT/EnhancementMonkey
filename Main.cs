using MelonLoader;
using BTD_Mod_Helper;
using EnhancementMonkey;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.ModOptions;
using System.Collections.Generic;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Models;
using EnhancementMonkey.Api.Ui.Submenues;
using System.Text;
using Il2CppAssets.Scripts.Simulation.Objects;

[assembly: MelonInfo(typeof(EnhancementMonkey.Main), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace EnhancementMonkey;

public class Main : BloonsTD6Mod
{
    public static bool MIB = false;

    public static string Space(string string_)
    {
        if (string.IsNullOrWhiteSpace(string_))
            return "";
        StringBuilder newString = new(string_.Length * 2);

        for(int i = 0; i < string_.Length; i++)
        {
            if((char.IsUpper(string_, i) | char.IsNumber(string_, i)) & i > 0 )
            {
                newString.Append(' ');
            }
            newString.Append(string_[i]);
        }

        return newString.ToString();
    }

    public static bool menuOpen = false;

    public static List<EnhancementLevel> UnlockedLevels = [EnhancementLevel.Basic];

    public static List<ModEnhancement> NormalEnhancements = [];

    public static List<ModSubmenu> EnhancementSubmenus = [];

    public static readonly ModSettingBool DebugMode = new(false)
    {
        icon = VanillaSprites.SettingsIcon
    };

    public static readonly ModSettingBool LevelsUnlocked = new(false)
    {
        icon = VanillaSprites.UpgradeIcon,
        description = "Are all of the enhancement levels pre-unlocked?"
    };

    public static readonly ModSettingBool ShowHidden = new(false)
    {
        icon = VanillaSprites.EnhancedEyesightUpgradeIcon,
        description = "Show hidden enhancements? (Be default there are none) "
    };

    public static readonly ModSettingBool ShowBuyPopups = new(false)
    {
        icon = VanillaSprites.WarningSign2,
        description = "Does a popup show saying you bought the enhancement after buying the enhancement? (Super annoying so false by default)",
        requiresRestart = true
    };

    public static Main instance;
    /// <summary>
    /// Clears everything.
    /// </summary>
    public static void Reset()
    {
        UnlockedLevels = [EnhancementLevel.Basic];
        foreach(var enhancement in ModContent.GetContent<ModEnhancement>())
        {
            enhancement.Cost = enhancement.BaseCost;
            enhancement.TimesBought = 0;

            if (!enhancement.LockedByDefault)
            {
                enhancement.Locked = false;
            }
            else
            {
                enhancement.Locked = true;
            }

            enhancement.Added = false;
        }
        MIB = false;
    }

    public override void OnTowerSold(Tower tower, float amount)
    {
        if (tower.towerModel.name.Contains("EnhancementMonkey"))
        {
            Reset();
            if(MainUi.instance != null)
            {
                MainUi.instance.Close();
            }
        }
    }

    public override void OnGameModelLoaded(GameModel gameModel)
    {
        Reset();
    }

    public override void OnTowerCreated(Tower tower, Entity target, Model modelToUse)
    {
        if (tower.towerModel.baseId.Contains(ModContent.TowerID<EnhancementMonkey>()))
        {
            Reset();
        }
    }

    public override void OnApplicationStart()
    {
        instance = this;
        int currentPriorityNum = 0;

        List<ModEnhancement> enhancements = ModContent.GetContent<ModEnhancement>();

        while (currentPriorityNum !> NormalEnhancements.Count)
        {
            foreach (var enhancement in enhancements)
            {
                if(enhancement.EnhancementGroup == EnhancementType.Normal)
                {
                    if (enhancement.Priority == currentPriorityNum)
                    {
                        NormalEnhancements.Add(enhancement);
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
                else
                {
                    return;
                }
            }
        }

        currentPriorityNum = 0;
    }


    public override void OnTowerSelected(Tower tower)
    {
        if(MainUi.instance != null)
        { 
            MainUi.instance?.Close(); 
        }

        if (tower.towerModel.baseId == ModContent.TowerID<EnhancementMonkey>()) { MainUi.CreateMainPanel(ModContent.GetContent<ModSubmenu>(), tower); }
    }

    public override void OnTowerDeselected(Tower tower)
    {
        if(MainUi.instance != null)
        {
            MainUi.instance.Close();
        }
    }
}