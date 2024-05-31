using BTD_Mod_Helper.Api.ModOptions;
using BTD_Mod_Helper.Extensions;
using EnhancementMonkey;
using EnhancementMonkey.Api.Enhancements.Paragon;
using EnhancementMonkey.Api.Ui.Submenues;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Simulation;
using Il2CppAssets.Scripts.Simulation.Objects;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using MelonLoader;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static Il2CppAssets.Scripts.Simulation.Simulation;

[assembly: MelonInfo(typeof(EnhancementMonkey.EnhancementMonkey), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
[assembly: MelonOptionalDependencies("CardMonkey", "BananaFarmParagon")]

namespace EnhancementMonkey;

public class EnhancementMonkey : BloonsTD6Mod
{
    public static bool MIB = false;
    public static bool MonkeyTown = false;

    public static List<ModEnhancement> BoughtEnhancements = [];
    /// <summary>
    /// Logs a certain thing if <see cref="DebugMode"/> and the minimum log level is at least this log level
    /// </summary>
    /// <param name="message">What to log</param>
    /// <param name="level">Log level</param>
    /// <param name="clutter">does this get logged a lot/not very helpful</param>
    public static void Debug(object message, LogLevel level, bool clutter = false)
    {
        if (DebugMode && level <= DebugLevel)
        {
            if (clutter & HideClutter)
            {
                return;
            }

            if (level == LogLevel.Info)
            {
                Log<EnhancementMonkey>(message);
            }
            else if (level == LogLevel.Warn | level == LogLevel.Dependency)
            {
                Warning<EnhancementMonkey>(message);
            }
            else if (level == LogLevel.Error)
            {
                Error<EnhancementMonkey>(message);
            }
        }
    }
    public static bool menuOpen = false;

    public static List<EnhancementLevel> UnlockedLevels = [EnhancementLevel.Paragon, EnhancementLevel.Basic];

    public static readonly ModSettingCategory Debuging = new("Debuging")
    { icon = VanillaSprites.AdvancedIntelUpgradeIcon };

    public static readonly ModSettingBool DebugMode = new(false)
    {
        category = Debuging,
        icon = VanillaSprites.SettingsIcon,
        description = "Print extra information into the log (uneeded for the average user)"
    };

    public enum LogLevel
    {
        /// <summary>
        /// Basic Info
        /// </summary>
        Info,
        /// <summary>
        /// Warnings except for dependencies
        /// </summary>
        Warn,
        /// <summary>
        /// All Errors
        /// </summary>
        Error,
        /// <summary>
        /// Show Dependency Warnings
        /// </summary>
        Dependency
    }

    public static readonly ModSettingEnum<LogLevel> DebugLevel = new(LogLevel.Error)
    {
        category = Debuging,
        description = "Highest level displayed in debug mode"
    };

    public static readonly ModSettingBool HideClutter = new(false)
    {
        category = Debuging,
        description = "Remove not so helpful logging from happening"
    };

    public static readonly ModSettingBool LevelsUnlocked = new(false)
    {
        icon = VanillaSprites.UpgradeIcon,
        description = "Are all of the enhancement levels pre-unlocked?"
    };

    public static readonly ModSettingBool ShowBuyPopups = new(false)
    {
        icon = VanillaSprites.WarningSign2,
        description = "Does a popup show saying you bought the enhancement after buying the enhancement? (Super annoying so false by default)",
        requiresRestart = true
    };

    /*public static readonly ModSettingBool ParagonsUnlocked = new(false)
    {
        icon = VanillaSprites.ParagonIcon,
        description = "Are all paragon enhancements pre-unlocked?"
    };*/

    public static readonly ModSettingInt EnhancementsLoadedPerFrame = new(200)
    {
        description = "How many enhancements to load per frame during loading, change this number if there's a lot of enhancements to load. Maxes at 1000/frame. \n\nOnly affects when the game first loads",
        max = 1000,
        min = 200
    };

    public static readonly ModSettingCategory GUI = new("GUI");

    public static readonly ModSettingDouble PanelHeightMultiplier = new(2.5f)
    {
        description = "How many times taller the submenu panels are compared to how tall an enhancement details panel is. Small values may make the menu look cramped, and large values may break the game.",
        min = 0.5,
        category = GUI
    };

    public static readonly ModSettingDouble PanelWidthMultiplier = new(1.4f)
    {
        description = "How many times wider the submenu panels are compared to how wide an enhancement details panel is. Small values may make the menu look cramped, and large values may block the screen.",
        min = 0.5,
        category = GUI
    };

    public static readonly ModSettingInt PanelX = new(2100)
    {
        description = "Horizontal location on screen",
        category = GUI
    };

    public static readonly ModSettingInt PanelY = new(1600)
    {
        description = "Vertical location on screen",
        category = GUI
    };


    /// <summary>
    /// Clears everything.
    /// </summary>
    public static void Reset()
    {
        UnlockedLevels = [EnhancementLevel.Basic];

        foreach (var enhancement in GetContent<ModEnhancement>())
        {
            enhancement.Cost = enhancement.BaseCost;
            enhancement.TimesBought = 0;

            if (enhancement.LockedByDefault || !enhancement.HasDependencies)
            {
                enhancement.Locked = true;
            }
            else
            {
                enhancement.Locked = false;
            }

            enhancement.Added = false;
        }
        if (LevelsUnlocked)
        {
            foreach (ModEnhancement enhancement in ModEnhancement.Enhancements)
            {
                if (enhancement.Modifies == ModifyType.Unlock)
                {
                    enhancement.ModifyOther();
                    enhancement.Locked = true;
                }
            }
        }
        foreach(var pEnhancement in GetContent<ParagonEnhancement>())
        {
            pEnhancement.HasRequirements = false;
        }
        MIB = false;
        MonkeyTown = false;
    }

    public override void OnGameModelLoaded(GameModel model)
    {
        Reset();
        foreach ((string name, bool value) in ModSubmenu.Filters)
        {
            ModSubmenu.Filters[name] = true;
        }


    }

    public override void OnCashAdded(double amount, Simulation.CashType from, int cashIndex, Simulation.CashSource source, Tower tower)
    {
        if (from == CashType.Normal)
        {
            if (tower != null && tower.towerModel.baseId == GetTowerModel<EnhancementMonkeyTower>().baseId && MonkeyTown)
            {
                InGame.instance.AddCash(amount);
            }
        }
    }

    public override void OnTowerSold(Il2CppAssets.Scripts.Simulation.Towers.Tower tower, float amount)
    {
        if (tower.towerModel.name.Contains("EnhancementMonkey"))
        {
            Reset();
            if (MainUi.instance != null)
            {
                MainUi.instance.Close();
            }
        }
    }

    public override void OnTowerCreated(Il2CppAssets.Scripts.Simulation.Towers.Tower tower, Entity target, Model modelToUse)
    {
        if (tower.towerModel.baseId.Contains(TowerID<EnhancementMonkeyTower>()))
        {
            Reset();
        }
    }

    public override void OnTowerSelected(Il2CppAssets.Scripts.Simulation.Towers.Tower tower)
    {
        if (MainUi.instance != null)
        {
            MainUi.instance?.Close();
        }

        if (tower.towerModel.baseId == TowerID<EnhancementMonkeyTower>()) { MainUi.CreateMainPanel(GetContent<ModSubmenu>(), tower); }
    }

    public override void OnTowerDeselected(Il2CppAssets.Scripts.Simulation.Towers.Tower tower)
    {
        if (MainUi.instance != null)
        {
            if (tower.towerModel.name.Contains("EnhancementMonkey"))
            {
                MainUi.instance.Close();
            }
        }
    }
}