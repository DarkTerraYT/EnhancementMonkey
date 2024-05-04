using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api;
using EnhancementMonkey.Api.Enhancements.Templates;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity;
using MelonLoader;
using System;
using System.Collections.Generic;
using UnityEngine;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Simulation.Towers;
using EnhancementMonkey.Api.Ui.Submenues;
using static EnhancementMonkey.Main;
using EnhancementMonkey.Api.Enum;

namespace EnhancementMonkey.Api.Ui
{
    [RegisterTypeInIl2Cpp(false)]
    public class MainUi : MonoBehaviour
    {
        public static MainUi? instance;

        public static ModHelperInputField? inputField;

        public void Close()
        {
            if (gameObject)
            {
                Destroy(gameObject);
            }
        }



        public static void CreateMainPanel(List<ModSubmenu> submenus, Tower tower)
        {
            RectTransform rect = InGame.instance.uiRect;

            ModHelperPanel panel = rect.gameObject.AddModHelperPanel(new("Panel_", 2400, 1800, 650, 200 * submenus.Count + 20 * (submenus.Count + 2), new()), VanillaSprites.BlueInsertPanel);
            MainUi upgradeUi = panel.AddComponent<MainUi>();

            instance = upgradeUi;


            foreach (ModSubmenu menu in submenus)
            {
                float y = (200 * submenus.Count) + 40 - 200 * submenus.IndexOf(menu) - 50 - submenus.IndexOf(menu) * 10;

                ModHelperButton button = panel.AddButton(new("Button_", 325, y, 500, 200, new()), VanillaSprites.GreenBtnLong, new System.Action(() =>
                {
                    instance.OpenSubmenu(tower, rect, menu.Name, menu.Info.Group, Game.instance.model);
                }));
                ModHelperText text = button.AddText(new("Text_", 0, 0, 700, 175), menu.Info.Name, 70);
            }
        }



        public void OpenSubmenu(Tower tower, RectTransform rect, string submenuName, EnhancementGroup group, GameModel game)
        {
            instance.Close();

            List<ModEnhancement> enhancements = ModContent.GetContent<ModEnhancement>();
            List<ModEnhancement> enhancements_ = new();

            foreach (var enhancement in enhancements)
            {
                if (enhancement.EnhancementGroup == group)
                {
                    enhancements_.Add(enhancement);
                }
            }

            float enhancementPanelWidth = 780;
            float enhancmentButtonHeight = 680;

            float PanelWidth = enhancementPanelWidth + 25;
            float PanelHeight = enhancmentButtonHeight * enhancements_.Count;

            ModHelperScrollPanel panel = rect.gameObject.AddModHelperScrollPanel(new("Panel_", 1500, 2000, PanelWidth, PanelHeight, new()), RectTransform.Axis.Vertical, VanillaSprites.BlueInsertPanel);

            ModHelperText text1 = panel.AddText(new("Text_Title", 0, 0, 700, 160), submenuName + " Enhancements");

            MainUi ui = panel.AddComponent<MainUi>();

            instance = ui;



            foreach (var enhancement in enhancements_)
            {
                foreach (var level in UnlockedLevels)
                {
                    if (enhancement.EnhancementLevel == level)
                    {
                        string textureName()
                        {
                            if (UnlockedLevels.IndexOf(level) == 0)
                            {
                                return "Basic";
                            }
                            else if (UnlockedLevels.IndexOf(level) == 1)
                            {
                                return "Good";
                            }
                            else if (UnlockedLevels.IndexOf(level) == 2)
                            {
                                return "Great";
                            }
                            else if (UnlockedLevels.IndexOf(level) == 3)
                            {
                                return "Awesome";
                            }
                            else if (UnlockedLevels.IndexOf(level) == 4)
                            {
                                return "Godly";
                            }
                            else if (UnlockedLevels.IndexOf(level) == 5)
                            {
                                return "Pure";
                            }
                            else if (UnlockedLevels.IndexOf(level) == 6)
                            {
                                return "Hidden";
                            }
                            else
                            {
                                return "Basic";
                            }
                        }

                        float buttonX = 402;
                        float buttonY = (200 * enhancements.Count) + 40 - 200 * enhancements.IndexOf(enhancement) - 50 - enhancements.IndexOf(enhancement) * 10;

                        ModHelperButton button = panel.AddButton(new("Button_", 0, 0, 500, 200, new(0.5f, 0.5f)), VanillaSprites.GreyInsertPanel, new System.Action(() =>
                        {
                            if (game.cash >= enhancement.ActualCost)
                            {
                                if (!enhancement.Locked)
                                {
                                    enhancement.ApplyEnhancement(tower.towerModel);

                                    game.cash -= enhancement.ActualCost;

                                    tower.worth += enhancement.ActualCost;
                                }
                            }
                        }));

                        var icon = button.AddPanel(new("Icon_", 0, buttonY = 50, 100), enhancement.Icon);
                        var text = button.AddText(new("Title_", 0, buttonY + 50, 100), enhancement.EnhancementName);

                        if (enhancement.Locked)
                        {
                            var lockIcon = button.AddImage(new("lock", 0, 0, 200), VanillaSprites.LockIcon);
                        }
                    }

                    ModHelperButton exitButton = panel.AddButton(new("Button_Exit", PanelWidth, PanelHeight / 2, 500), VanillaSprites.ExitIcon, new System.Action(() =>
                    {
                        instance.Close();
                    }));
                }
            }
        }
    }
}
