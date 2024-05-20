using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Extensions;
using EnhancementMonkey.Api.Ui.Submenues;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EnhancementMonkey.Api.Ui
{
    /// <summary>
    /// If creating a mod for this, you shouldn't need to touch this class. Use <see cref="instance"/> unless you're creating the main panel.
    /// </summary>
    [RegisterTypeInIl2Cpp(false)]
    public class MainUi : MonoBehaviour
    {
        public static MainUi? instance = null;

        public static ModHelperInputField? inputField;

        public void Close()
        {
            if (gameObject)
            {
                Destroy(gameObject);

                foreach (var enhancement in GetContent<ModEnhancement>())
                {
                    enhancement.Added = false;
                }
            }
        }

        static string EnhancementLevelName(ModEnhancement enhancement)
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
        static string EnhancementLevelName(EnhancementLevel enhancementLevel)
        {
            if (enhancementLevel == EnhancementLevel.Basic)
            {
                return "Basic";
            }
            else if (enhancementLevel == EnhancementLevel.Good)
            {
                return "Good";
            }
            else if (enhancementLevel == EnhancementLevel.Great)
            {
                return "Great";
            }
            else if (enhancementLevel == EnhancementLevel.Awesome)
            {
                return "Awesome";
            }
            else if (enhancementLevel == EnhancementLevel.Godly)
            {
                return "Godly";
            }
            else if (enhancementLevel == EnhancementLevel.Pure)
            {
                return "Pure";
            }
            else if (enhancementLevel == EnhancementLevel.Hidden)
            {
                return "Hidden";
            }
            else
            {
                return "Basic";
            }
        }
        public static void CreateMainPanel(List<ModSubmenu> submenus, Il2CppAssets.Scripts.Simulation.Towers.Tower tower)
        {
            RectTransform rect = InGame.instance.uiRect;

            ModHelperPanel panel = rect.gameObject.AddModHelperPanel(new("Panel_", 2100, 1600, 650, 200 * submenus.Count + 20 * (submenus.Count + 2), new()), VanillaSprites.BlueInsertPanel);
            MainUi upgradeUi = panel.AddComponent<MainUi>();

            instance = upgradeUi;

            float width = 680;
            float height = 780;


            float PanelWidth = width * 1.3f;
            float PanelHeight = height * 1.3f;

            foreach (ModSubmenu menu in submenus)
            {
                float y = (200 * submenus.Count) + 40 - 200 * submenus.IndexOf(menu) - 50 - submenus.IndexOf(menu) * 10;

                ModHelperButton button2 = panel.AddButton(new("Button_", 325, y, 500, 200, new()), VanillaSprites.GreenBtnLong, new System.Action(() =>
                {
                    instance.OpenSubmenu(tower, rect, menu, menu.Info.Group);
                }));
                ModHelperText text = button2.AddText(new("Text_", 0, 0, 700, 175), menu.Info.Name, 70);
            }

            var redButton = new SpriteReference(VanillaSprites.RedBtnLong);
            var greenButton = new SpriteReference(VanillaSprites.GreenBtnLong);
            var greenBtnCircle = GetSpriteReference<EnhancementMonkey>("GreenBtnCircleSmall");
            var redBtnCircle = GetSpriteReference<EnhancementMonkey>("RedBtnCircleSmall");

            var button = panel.AddButton(new("Button_Filter", panel.RectTransform.rect.right, panel.RectTransform.rect.top, 200), VanillaSprites.BlueBtnCircleSmall, new Action(() =>
            {
                instance.Close();

                ModHelperPanel panel1 = rect.gameObject.AddModHelperPanel(new("Panel_Filter", rect.rect.center.x, rect.rect.center.y, 850, 1620), VanillaSprites.BrownInsertPanel);
                instance = panel1.AddComponent<MainUi>();

                panel1.AddText(new("Text_Filters", panel1.RectTransform.rect.center.x, panel1.RectTransform.rect.bottom - 100, 850, 200), "Filters", 100);

                ModHelperButton returnBtn = panel1.AddButton(new("Button_Back", panel1.RectTransform.rect.right, panel1.RectTransform.rect.top, 200), VanillaSprites.BackBtn, new Action(() =>
                {
                    instance.Close();
                    CreateMainPanel(GetContent<ModSubmenu>(), tower);
                }));

                string guid = "";

                if (ModSubmenu.Filters["Unlocks"])
                {
                    guid = greenButton.GUID;
                }
                else
                {
                    guid = redButton.GUID;
                }

                float textX = panel1.RectTransform.rect.left + 200;
                float buttonX = panel1.RectTransform.rect.left + 620;

                ModHelperButton showUnlocksToggle = panel1.AddButton(new("Button_ShowUnlocks", panel1.RectTransform.rect.left + 620, 560, 360, 150), guid, new Action(() =>
                {
                    ModHelperButton button = panel1.GetDescendent<ModHelperButton>("Button_ShowUnlocks");

                    if (ModSubmenu.Filters["Unlocks"])
                    {
                        ModSubmenu.Filters["Unlocks"] = false;
                        button.Image.SetSprite(redButton);
                    }
                    else
                    {
                        ModSubmenu.Filters["Unlocks"] = true;
                        button.Image.SetSprite(greenButton);
                    }
                }));

                ModHelperText showUnlocksText = panel1.AddText(new("Text_ShowUnlocks", panel1.RectTransform.rect.left + 200, 560, 360, 150), "Show Unlocks?", 65);

                ModHelperText subTitle = panel1.AddText(new("Text_Level_Filters", 0, 410, 850, 100), "Level Filters", 80);

                var enhancementLevels = System.Enum.GetValues(typeof(EnhancementLevel)).Cast<EnhancementLevel>().ToList();

                int lowestLevelY = 5;

                var seperatorLine_ = panel1.AddImage(new("Image_Seperator_Level_Unlocks", 0, 305, 850, 10), GetSpriteReference<EnhancementMonkey>("SeperatorLine").GUID);

                for (int i = 0; i < enhancementLevels.Count; i++)
                {
                    string name = EnhancementLevelName(enhancementLevels[i]);

                    string guid2 = "";

                    if (ModSubmenu.Filters[name])
                    {
                        guid2 = greenBtnCircle.GUID;
                    }
                    else
                    {
                        guid2 = redBtnCircle.GUID;
                    }
                    int y = 245 - 120 * i;

                    int seperatorY = y - 60;

                    var seperatorLine = panel1.AddImage(new("Image_Seperator_" + name, 0, seperatorY, 850, 10), GetSpriteReference<EnhancementMonkey>("SeperatorLine").GUID);


                    var title = panel1.AddText(new("Text_Option_Filter_" + name, textX, y, 360, 200), name, 65);

                    ModHelperButton button1 = panel1.AddButton(new("Button_Filter_" + name, buttonX, y, 100), guid2, new Action(() =>
                    {
                        ModHelperButton button = panel1.GetDescendent<ModHelperButton>("Button_Filter_" + name);
                        if (ModSubmenu.Filters[name])
                        {
                            ModSubmenu.Filters[name] = false;
                            button.Image.SetSprite(redBtnCircle);
                        }
                        else
                        {
                            ModSubmenu.Filters[name] = true;
                            button.Image.SetSprite(greenBtnCircle);
                        }
                    }));

                    lowestLevelY = seperatorY;
                }

                int minCostY = lowestLevelY - 110;

                ModHelperInputField minCost = panel1.AddInputField(new("InputField_Min_Cost", buttonX, minCostY, 300, 100), "0", VanillaSprites.BlueInsertPanelRound, new Action<string>(input =>
                {
                    int value = int.Parse(input);

                    ModSubmenu.MinShowCost = value;

                }), 40, Il2CppTMPro.TMP_InputField.CharacterValidation.Integer);

                ModHelperText minCostText = panel1.AddText(new("Text_Min_Cost", textX, minCostY, 360, 200), "Minimum Cost", 65);

            }));

            SpriteReference filterSprite = GetSpriteReference<EnhancementMonkey>("FilterIcon");

            var filterIcon = button.AddImage(new("Image_Filter", 0, 0, 125), filterSprite.GUID);
        }

        private static ModHelperPanel CreateEnhancementPanel(ModEnhancement enhancement, float width, float height, Il2CppAssets.Scripts.Simulation.Towers.Tower tower)
        {
            ModHelperPanel panel2 = ModHelperPanel.Create(new("EnhancementPanel_", -75, 0, width, height), GetSpriteReference<EnhancementMonkey>(EnhancementLevelName(enhancement)).GUID);

            var icon = panel2.AddImage(new("Icon_", 0, 75, 300), enhancement.Icon);
            var name = panel2.AddText(new("Title_", 0, 320, width, 100), enhancement.EnhancementName, 50);
            var price = panel2.AddText(new("Cost_", 0, 270, width, 100), "$" + enhancement.Cost);
            price.Text.color = Color.green;

            if (enhancement.hitCamo)
            {
                panel2.AddImage(new("Image_Camo", width - 50, 300, 80), VanillaSprites.CamoBloonIcon);
            }
            if (enhancement.hitLead)
            {
                panel2.AddImage(new("Image_Camo", width - 100, 300, 80), VanillaSprites.LeadBloonIcon);
            }

            var desc = panel2.AddText(new("Description_", 0, -100, width * .9616f, height / 2 - 50), enhancement.Description);

            ModHelperButton buyButton = panel2.AddButton(new("EnhancementPanel_", 0, -300, width / 1.33f, height / 5), VanillaSprites.BlueBtnLong, new Action(() =>
            {
                bool inAGame = InGame.instance != null && InGame.instance.bridge != null;
                if (inAGame)
                {
                    if (InGame.instance.GetCash() >= enhancement.Cost)
                    {
                        InGame.instance.AddCash(-enhancement.Cost);
                        tower.worth += enhancement.Cost;
                        enhancement.Cost += (int)(enhancement.TrueBaseCost * enhancement.CostMultiplier);
                        enhancement.TimesBought++;

                        tower.UpdatedModel(tower.towerModel);

                        enhancement.ApplyEnhancement(tower);

                        if (DebugMode)
                        {
                            Debug("Bought Enhancement!", LogLevel.Info);
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
                            Debug("Not enough cash.", LogLevel.Info);
                            Debug($"Costs {enhancement.Cost} while the player only has {InGame.instance.GetCash()}", LogLevel.Info);
                        }
                        if (PopupScreen.instance != null)
                        {
                            PopupScreen.instance.ShowOkPopup("Not enough cash.");
                        }
                    }
                }
                price.SetText("$" + enhancement.Cost);
            }));
            ModHelperText buyText = buyButton.AddText(new("BuyText_", 0, 0, width / 1.33f, height / 5), "Buy", 100);

            return panel2;
        }

        public void OpenSubmenu(Il2CppAssets.Scripts.Simulation.Towers.Tower tower, RectTransform rect, ModSubmenu submenu, EnhancementType group)
        {
            instance?.Close();

            foreach (var enhancement in GetContent<ModEnhancement>())
            {
                enhancement.Added = false;
            }

            List<ModEnhancement> enhancements = GetContent<ModEnhancement>();
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
                                    Debug("Added Enhancement " + enhancement.EnhancementName, LogLevel.Info, true);
                                }
                            }

                        }
                    }
                    else if (enhancement.EnhancementLevel == level)
                    {
                        if (enhancement.EnhancementGroup == group)
                        {
                            if (!enhancement.Locked & !enhancement.Added)
                            {
                                enhancements_.Add(enhancement);
                                if (DebugMode)
                                {
                                    Debug("Added Enhancement " + enhancement.EnhancementName, LogLevel.Info, true);
                                }
                            }

                        }
                    }
                }
            }

            float width = 680;
            float height = 780;

            float PanelWidth = width * 1.3f;
            float PanelHeight = height * 1.3f;

            ModHelperScrollPanel panel = rect.gameObject.AddModHelperScrollPanel(new("Panel_", 2100, 1600, PanelWidth + 150, PanelHeight, new()), RectTransform.Axis.Vertical, VanillaSprites.BlueInsertPanel, 45, 100);

            panel.AddScrollContent(ModHelperText.Create(new("Title_", 0, 500, PanelWidth, 160), submenu.Info.Name, 90)); // Title

            MainUi ui = panel.AddComponent<MainUi>();

            instance = ui;

            ModHelperButton returnBtn = panel.AddButton(new("Button_Back", panel.RectTransform.rect.right - 125, panel.RectTransform.rect.bottom - 125, 200), VanillaSprites.BackBtn, new Action(() =>
            {
                instance.Close();
                CreateMainPanel(GetContent<ModSubmenu>(), tower);
            }));

            bool addedInEnhancement = false;


            foreach (var enhancement in enhancements_)
            {
                if (ModSubmenu.Filters[EnhancementLevelName(enhancement)] & enhancement.BaseCost >= ModSubmenu.MinShowCost)
                {
                    if (!(enhancement.Modifies == ModifyType.Unlock & !ModSubmenu.Filters["Unlocks"]))
                    {
                        panel.AddScrollContent(CreateEnhancementPanel(enhancement, width, height, tower));
                        addedInEnhancement = true;
                    }
                }

                ModHelperButton exitButton = panel.AddButton(new("Button_Exit", PanelWidth, PanelHeight / 2, 500), VanillaSprites.ExitIcon, new Action(() =>
                {
                    instance.Close();
                    CreateMainPanel(GetContent<ModSubmenu>(), tower);
                }));

            }
            if (!addedInEnhancement)
            {
                panel.AddText(new("Text_NoShownEnhancements", 0, 0, PanelWidth + 150, 300), "No Enhancements Found! \nTry changing filters?", 60);
            }
        }
    }
}
