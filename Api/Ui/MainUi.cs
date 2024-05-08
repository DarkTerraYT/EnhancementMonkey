using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using MelonLoader;
using System;
using System.Collections.Generic;
using UnityEngine;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Simulation.Towers;
using EnhancementMonkey.Api.Ui.Submenues;
using BTD_Mod_Helper;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using HarmonyLib;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using EnhancementMonkey.Api.Enhancements.Weapon;

namespace EnhancementMonkey.Api.Ui
{
    /// <summary>
    /// If creating a mod for this, you shouldn't need to touch this class. Use MainUi.instance unless you're creating the main panel.
    /// </summary>
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

                foreach (var enhancement in ModContent.GetContent<ModEnhancement>())
                {
                    enhancement.Added = false;
                }
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
                    instance.OpenSubmenu(tower, rect, menu, menu.Info.Group);
                }));
                ModHelperText text = button.AddText(new("Text_", 0, 0, 700, 175), menu.Info.Name, 70);
            }
        }

        private ModHelperPanel CreateEnhancementPanel(RectTransform rect, ModEnhancement enhancement, float width, float height, Tower tower)
        {
            string textureName()
            {
                if (enhancement.Background == EnhancementLevel.Basic)
                {
                    return "Basic";
                }
                else if (enhancement.Background == EnhancementLevel.Good)
                {
                    return "Good";
                }
                else if (enhancement.Background == EnhancementLevel.Great)
                {
                    return "Great";
                }
                else if (enhancement.Background == EnhancementLevel.Awesome)
                {
                    return "Awesome";
                }
                else if (enhancement.Background == EnhancementLevel.Godly)
                {
                    return "Godly";
                }
                else if (enhancement.Background == EnhancementLevel.Pure)
                {
                    return "Pure";
                }
                else if (enhancement.Background == EnhancementLevel.Hidden)
                {
                    return "Hidden";
                }
                else
                {
                    return "Basic";
                }
            }

            ModHelperPanel panel2 = ModHelperPanel.Create(new("EnhancementPanel_", 0, 0, width, height), ModContent.GetSpriteReference<Main>(textureName()).GUID);

            var icon = panel2.AddImage(new("Icon_", 0, 75, 300), enhancement.Icon);
            var name = panel2.AddText(new("Title_", 0, 330, width, 100), enhancement.EnhancementName);
            var price = panel2.AddText(new("Cost_", 0, 290, width, 100), "$" + enhancement.Cost);
            price.Text.color = Color.green;

            var desc = panel2.AddText(new("Description_", 0, -100, width * .9616f, height / 2 - 50), enhancement.Description);

            ModHelperButton buyButton = panel2.AddButton(new("EnhancementPanel_",0 , -300, width / 1.33f, height / 5), VanillaSprites.BlueBtnLong, new Action(() =>
            {
                bool inAGame = InGame.instance != null && InGame.instance.bridge != null;
                if (inAGame)
                {
                    if (InGame.instance.GetCash() >= enhancement.Cost)
                    {
                        InGame.instance.AddCash(-enhancement.Cost);
                        tower.worth += enhancement.Cost;
                        enhancement.Cost += (int)(enhancement.BaseCost * enhancement.CostMultiplier);
                        enhancement.TimesBought++;

                        tower.UpdatedModel(tower.towerModel);

                        enhancement.ApplyEnhancement(tower);

                        if (DebugMode)
                        {
                            ModHelper.Log<Main>("Bought Enhancement!");
                        }
                        if (PopupScreen.instance != null)
                        {
                            if (ShowBuyPopups)
                            {
                                PopupScreen.instance.ShowOkPopup("Bought Enhancement! You can turn off this popup in the config.");
                            }
                        }
                    }
                    else
                    {
                        if (DebugMode)
                        {
                            ModHelper.Log<Main>("Not enough cash.");
                            ModHelper.Log<Main>($"Costs {enhancement.Cost} while the player only has {InGame.instance.GetCash()}");
                        }
                        if (PopupScreen.instance != null)
                        {
                            if (ShowBuyPopups)
                            {
                                PopupScreen.instance.ShowOkPopup("Not enough cash.");
                            }
                        }
                    }
                }
                price.SetText("$" + enhancement.Cost);
            }));
            ModHelperText buyText = buyButton.AddText(new("BuyText_", 0, 0, width / 1.33f, height / 5), "Buy", 100);

            return panel2;
        }

        public void OpenSubmenu(Tower tower, RectTransform rect, ModSubmenu submenu, EnhancementType group)
        {
            instance?.Close();

            foreach (var enhancement in ModContent.GetContent<ModEnhancement>())
            {
                enhancement.Added = false;
            }

            List<ModEnhancement> enhancements = ModContent.GetContent<ModEnhancement>();
            List<ModEnhancement> enhancements_ = [];

            foreach (var level in UnlockedLevels)
            {
                foreach (var enhancement in enhancements)
                {
                    if (enhancement.Modifies == ModifyType.Unlock & UnlockedLevels.Contains(enhancement.EnhancementLevel))
                    {
                        if (enhancement.EnhancementGroup == group)
                        {
                            if (!enhancement.Locked & !enhancement.Added)
                            {
                                enhancements_.Add(enhancement);
                                enhancement.Added = true;
                                if (DebugMode)
                                {
                                    ModHelper.Log<Main>("Added Enhancement " + enhancement.EnhancementName);
                                }
                            }

                        }
                    }
                    else if(enhancement.EnhancementLevel == level)
                    {
                        if (enhancement.EnhancementGroup == group)
                        {
                            if (!enhancement.Locked & !enhancement.Added)
                            {
                                enhancements_.Add(enhancement);
                                if (DebugMode)
                                {
                                    ModHelper.Log<Main>("Added Enhancement " + enhancement.EnhancementName);
                                }
                            }

                        }
                    }
                }
            }

            float enhancementPanelWidth = 680;
            float enhancementButtonHeight = 780;

            float PanelWidth = enhancementPanelWidth * 1.3f;
            float PanelHeight = enhancementButtonHeight * 1.3f;

            ModHelperScrollPanel panel = rect.gameObject.AddModHelperScrollPanel(new("Panel_", 1500, 2000, PanelWidth, PanelHeight, new()), RectTransform.Axis.Vertical, VanillaSprites.BlueInsertPanel, 45, 100);

            panel.AddScrollContent(ModHelperText.Create(new("Title_", 0, 500, PanelWidth, 160), submenu.Info.Name, 60)); // 

            MainUi ui = panel.AddComponent<MainUi>();

            instance = ui;



            foreach (var enhancement in enhancements_)
            {
                panel.AddScrollContent(CreateEnhancementPanel(rect, enhancement, enhancementPanelWidth, enhancementButtonHeight, tower));

                ModHelperButton exitButton = panel.AddButton(new("Button_Exit", PanelWidth, PanelHeight / 2, 500), VanillaSprites.ExitIcon, new Action(() =>
                {
                    instance.Close();
                }));

            }
        }
    }
}
