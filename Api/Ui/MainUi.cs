using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Extensions;
using EnhancementMonkey.Api.Enhancements.Paragon;
using EnhancementMonkey.Api.Enhancements.Unlocks;
using EnhancementMonkey.Api.Ui.Submenues;
using Il2CppAssets.Scripts.Simulation.Towers;
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
    internal class MainUi : MonoBehaviour
    {
        public static MainUi instance = null;

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

        public static void CreateMainPanel(List<ModSubmenu> submenus, Il2CppAssets.Scripts.Simulation.Towers.Tower tower)
        {
            List<ModSubmenu> submenus_ = submenus.Duplicate();

            foreach (ModSubmenu submenu in submenus_)
            {
                if (submenu.Hide)
                {
                    submenus.Remove(submenu);
                }
            }

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
                    instance.OpenSubmenu(tower, rect, menu.Id);
                }));
                ModHelperText text = button2.AddText(new("Text_", InfoPreset.FillParent), menu.DisplayName, 70);
                text.Text.enableAutoSizing = true;

                Debug(menu.Id, LogLevel.Info);
            }

            foreach(ModEnhancement enhancement in GetContent<ModEnhancement>())
            {
                Debug(enhancement.Submenu.Id, LogLevel.Info);
            }

            var redButton = new SpriteReference(VanillaSprites.RedBtnLong);
            var greenButton = new SpriteReference(VanillaSprites.GreenBtnLong);
            var greenBtnCircle = GetSpriteReference<EnhancementMonkey>("GreenBtnCircleSmall");
            var redBtnCircle = GetSpriteReference<EnhancementMonkey>("RedBtnCircleSmall");

            var buttonUpgrade = panel.AddButton(new("Button_Upgrade", panel.RectTransform.rect.left, panel.RectTransform.rect.top, 300), VanillaSprites.UpgradeIcon, new Action(() =>
            {
                instance.Close();

                CreateUpgradeButton(rect, tower);

                var btnReturn = panel.AddButton(new("Button_Return_Upgrade", panel.RectTransform.rect.right, panel.RectTransform.rect.top, 200), VanillaSprites.BackBtn, new Action(() =>
                {
                    instance.Close();
                    CreateMainPanel(GetContent<ModSubmenu>(), tower);
                }));
            }));

            var button = panel.AddButton(new("Button_Filter", panel.RectTransform.rect.right, panel.RectTransform.rect.top, 200), VanillaSprites.BlueBtnCircleSmall, new Action(() =>
            {
                instance.Close();

                ModHelperPanel panel1 = rect.gameObject.AddModHelperPanel(new("Panel_Filter", rect.rect.center.x, rect.rect.center.y, 850, 1620), VanillaSprites.BrownInsertPanel);
                instance = panel1.AddComponent<MainUi>();

                panel1.AddText(new("Text_Filters", panel1.RectTransform.rect.center.x, panel1.RectTransform.rect.bottom - 100, 850, 200), "Levels Filters", 100);

                var scrollPanel = panel1.AddScrollPanel(new("FiltersScroll", 0, -220, 850, 1400), RectTransform.Axis.Vertical, null, 35, 35);

                ModHelperButton returnBtn = panel1.AddButton(new("Button_Back", panel1.RectTransform.rect.right, panel1.RectTransform.rect.top, 200), VanillaSprites.BackBtn, new Action(() =>
                {
                    instance.Close();
                    CreateMainPanel(GetContent<ModSubmenu>(), tower);
                }));

                foreach(var level in GetContent<EnhancementLevel>().FindAll(level => level.ShownInFiltersList))
                {
                    var filterPanel = ModHelperPanel.Create(new("Filter_" + level.Name, 800, 120));

                    var name = filterPanel.AddText(new("Name", -50, 650, 100), level.DisplayName, 100, Il2CppTMPro.TextAlignmentOptions.Left);
                    name.Text.fontSizeMax = 100;
                    name.Text.enableAutoSizing = true;

                    string guid = "";
                    if(level.IsShown)
                    {
                        guid = greenBtnCircle.AssetGUID;
                    }
                    else
                    {
                        guid = redBtnCircle.AssetGUID;
                    }

                    var showBtn = filterPanel.AddButton(new("Show", 0, 440, 100), guid, new Action(() =>
                    {
                        level.IsShown = !level.IsShown;

                        var btn = filterPanel.GetDescendent<ModHelperButton>("Show");
                        if (level.IsShown)
                        {
                            btn.Image.SetSprite(greenBtnCircle.AssetGUID);
                        }
                        else
                        {
                            btn.Image.SetSprite(redBtnCircle.AssetGUID);
                        }
                    }));
                }
            }));

            SpriteReference filterSprite = GetSpriteReference<EnhancementMonkey>("FilterIcon");

            var filterIcon = button.AddImage(new("Image_Filter", 0, 0, 125), filterSprite.AssetGUID);
        }

        private static void CreateUpgradeButton(RectTransform rect, Tower tower) 
        {
            float width = 680;
            float height = 780;

            float PanelWidth = width * 1.3f;
            float PanelHeight = height * 1.3f;

            ModHelperPanel panel1 = rect.gameObject.AddModHelperPanel(new("Panel_Upgrade", rect.rect.center.x, rect.rect.center.y, PanelWidth, PanelHeight), VanillaSprites.MainBGPanelGold);
            instance = panel1.AddComponent<MainUi>();

            var title = panel1.AddText(new("Title_", 0, 420, PanelWidth, 160), "Enhancement Levels", 78);

            UpgradeEnhancement enhancement = null;
            foreach (var enhancement_ in GetContent<UpgradeEnhancement>())
            {
                if (!enhancement_.Locked)
                {
                    enhancement = enhancement_;
                    break;
                }
            }
            if (enhancement != null)
            {
                ModHelperPanel enhancementPanel = panel1.AddPanel(new("Panel_Enhancement", panel1.RectTransform.rect.center.x, panel1.RectTransform.rect.center.y, width, height), GetSpriteReference<EnhancementMonkey>(enhancement.Background.Background).GetGUID());

                var icon = enhancementPanel.AddImage(new("Icon_", 0, 75, 300), enhancement.Icon);
                var name = enhancementPanel.AddText(new("Title_", 0, 320, width, 100), enhancement.EnhancementName, 50);
                var price = enhancementPanel.AddText(new("Cost_", 0, 270, width, 100), "$" + enhancement.BaseCost);
                price.Text.color = Color.green;

                if (enhancement.hitCamo)
                {
                    enhancementPanel.AddImage(new("Image_Camo", width - 50, 300, 80), VanillaSprites.CamoBloonIcon);
                }
                if (enhancement.hitLead)
                {
                    enhancementPanel.AddImage(new("Image_Camo", width - 100, 300, 80), VanillaSprites.LeadBloonIcon);
                }

                var desc = enhancementPanel.AddText(new("Description_", 0, -100, width * .9616f, height / 2 - 50), enhancement.Description);

                ModHelperButton buyButton = enhancementPanel.AddButton(new("EnhancementPanel_", 0, -300, width / 1.33f, height / 5), VanillaSprites.BlueBtnLong, new Action(() =>
                {
                    bool inAGame = InGame.instance != null && InGame.instance.bridge != null;
                    if (inAGame)
                    {
                        if (InGame.instance.GetCash() >= enhancement.BaseCost)
                        {
                            InGame.instance.AddCash(-enhancement.BaseCost);
                            tower.worth += enhancement.BaseCost;
                            enhancement.Cost += (int)(enhancement.Cost * enhancement.CostMultiplier);
                            enhancement.TimesBought++;


                            if (!BoughtEnhancements.Contains(enhancement))
                            {
                                BoughtEnhancements.Add(enhancement);
                            }

                            tower.UpdatedModel(tower.towerModel);

                            enhancement.ModifyOther();
                            enhancement.Locked = true;

                            instance.Close();
                            CreateUpgradeButton(rect, tower);

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
                                Debug($"Costs {enhancement.BaseCost} while the player only has {InGame.instance.GetCash()}", LogLevel.Info);
                            }
                            if (PopupScreen.instance != null)
                            {
                                PopupScreen.instance.ShowOkPopup($"Not enough cash. You need {InGame.instance.GetCash() - enhancement.BaseCost} more cash.");
                            }
                        }
                    }
                    price.SetText("$" + enhancement.BaseCost);
                }));
                ModHelperText buyText = buyButton.AddText(new("BuyText_", 0, 0, width / 1.33f, height / 5), "Buy", 100);
            }
            else 
            {
                panel1.AddText(new("Text_NoShownEnhancements", 0, 0, PanelWidth, 300), "You've Unlocked Every Enhancement Level (or your filters are preventing you from seeing them!)", 60);
            }
        }

        private static ModHelperPanel CreateEnhancementPanel(ModEnhancement enhancement, float width, float height, Il2CppAssets.Scripts.Simulation.Towers.Tower tower)
        {
            var level = GetContent<EnhancementLevel>().Find(level => level.Name == enhancement.Background.Name);

            ModHelperPanel panel2 = ModHelperPanel.Create(new("EnhancementPanel_", -75, 0, width, height), level!.Background);
            panel2.Background.color = level!.BackgroundOverlayColor;

            var icon = panel2.AddImage(new("Icon_", 0, 75, 300), enhancement.Icon);
            var name = panel2.AddText(new("Title_", 0, 320, width, 100), enhancement.EnhancementName, 65);
            var price = panel2.AddText(new("Cost_", 0, 270, width, 100), "$" + enhancement.BaseCost, 55);

            price.Text.fontSizeMin = 10;
            price.Text.fontSizeMax = 55;

            price.Text.color = Color.green;

            if (enhancement.hitCamo)
            {
                panel2.AddImage(new("Image_Camo", width - 50, 300, 80), VanillaSprites.CamoBloonIcon);
            }
            if (enhancement.hitLead)
            {
                panel2.AddImage(new("Image_Camo", width - 100, 300, 80), VanillaSprites.LeadBloonIcon);
            }

            var desc = panel2.AddText(new("Description_", 0, -100, width * .9616f, height / 2 - 50), enhancement.Description, 55);
            desc.Text.fontSizeMin = 10;
            desc.Text.fontSizeMax = 55;

            ModHelperButton buyButton = panel2.AddButton(new("EnhancementPanel_", 0, -300, width / 1.33f, height / 5), VanillaSprites.BlueBtnLong, new Action(() =>
            {
                bool inAGame = InGame.instance != null && InGame.instance.bridge != null;
                if (inAGame)
                {
                    if (InGame.instance.GetCash() >= enhancement.BaseCost)
                    {
                        InGame.instance.AddCash(-enhancement.BaseCost);
                        tower.worth += enhancement.BaseCost;
                        enhancement.Cost += (int)(enhancement.BaseCost * enhancement.CostMultiplier);
                        enhancement.TimesBought++;

                        if (!BoughtEnhancements.Contains(enhancement)) 
                        {
                            BoughtEnhancements.Add(enhancement);
                        }

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
                            Debug($"Costs {enhancement.BaseCost} while the player only has {InGame.instance.GetCash()}", LogLevel.Info);
                        }
                        if (PopupScreen.instance != null)
                        {
                            PopupScreen.instance.ShowOkPopup($"Not enough cash. You need {InGame.instance.GetCash() - enhancement.BaseCost} more cash.");
                        }
                    }
                }
                price.SetText("$" + enhancement.BaseCost);
            }));
            ModHelperText buyText = buyButton.AddText(new("BuyText_", 0, 0, width / 1.33f, height / 5), "Buy", 100);

            return panel2;
        }

        public void OpenSubmenu(Tower tower, RectTransform rect, string submenuId)
        {
            instance?.Close();

            foreach (var enhancement in GetContent<ModEnhancement>())
            {
                enhancement.Added = false;
            }

            List<ModEnhancement> enhancements = GetContent<ModEnhancement>();
            List<ModEnhancement> enhancements_ = [];

            var submenu = ModSubmenu.GetSubmenu(submenuId);

            if (!submenu.Hide)
            {
                foreach (var level in UnlockedLevels)
                {
                    foreach (var enhancement in enhancements)
                    {
                        if (enhancement.Modifies == ModifyType.Unlock & UnlockedLevels.Contains(enhancement.EnhancementLevel))
                        {
                            if (enhancement.Submenu.Id == submenu.Id)
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
                            if (enhancement.Submenu.Id == submenu.Id)
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
                    }
                }
            }
            else if (submenu.Id == ModSubmenu.Paragon.Id) 
            {
                foreach(var enhancement in GetContent<ParagonEnhancement>())
                {
                    List<ModEnhancement> missingEnhancements = [];

                    foreach (var reqEnhancement in enhancement.RequiredEnhancements)
                    {
                        if (!BoughtEnhancements.Contains(reqEnhancement))
                        {
                            missingEnhancements.Add(reqEnhancement);
                            Debug("Paragon enhancement " + enhancement.Name + " is missing enhancement " + reqEnhancement.Name, LogLevel.Info);
                        }
                    }

                    enhancement.HasRequirements = missingEnhancements.Count == 0;

                    if ((!enhancement.Locked && enhancement.HasRequirements && !enhancement.Added)/* | ParagonsUnlocked*/)
                    {
                        enhancements_.Add(enhancement);
                        enhancement.Added = true;
                        Debug("Added Paragon Enhancement " + enhancement.EnhancementName, LogLevel.Info, GetContent<ParagonEnhancement>().Count > 8); // 8 is the number of vanilla paragons
                    }
                }
            }

            float width = 680;
            float height = 780;

            float PanelWidth = width * PanelWidthMultiplier;
            float PanelHeight = height * PanelHeightMultiplier;

            ModHelperScrollPanel panel = rect.gameObject.AddModHelperScrollPanel(new("Panel_", PanelX, PanelY, PanelWidth, PanelHeight, new()), RectTransform.Axis.Vertical, VanillaSprites.BlueInsertPanel, 45, 100);

            var title =  panel.AddText(new("Title_", 0, panel.RectTransform.rect.bottom - 100, PanelWidth, 160), submenu.DisplayName, 100); // Title
            title.Text.fontSizeMin = 90;
            title.Text.fontSizeMax = 100;


            MainUi ui = panel.AddComponent<MainUi>();

            instance = ui;

            ModHelperButton returnBtn = panel.AddButton(new("Button_Back", panel.RectTransform.rect.right - 125, panel.RectTransform.rect.bottom - 125, 200), VanillaSprites.BackBtn, new Action(() =>
            {
                instance.Close();
                CreateMainPanel(GetContent<ModSubmenu>(), tower);
            }));

            bool addedInEnhancement = false;

            int enhancementsAdded = 0;

            foreach (var enhancement in enhancements_)
            {
                if (ModSubmenu.LevelFilters[enhancement.Background.Id] & enhancement.BaseCost >= ModSubmenu.MinShowCost)
                {
                    if (!(enhancement.Modifies == ModifyType.Unlock & !ModSubmenu.LevelFilters["Unlocks"]))
                    {
                        panel.AddScrollContent(CreateEnhancementPanel(enhancement, width, height, tower));
                        addedInEnhancement = true;
                        enhancementsAdded++;
                    }
                }

            }

            if(enhancementsAdded >= 70) 
            {
                if(PopupScreen.instance != null) 
                {
                    PopupScreen.instance.ShowOkPopup("70+ Enhancements have loaded! You might be noticing some lag when opening this submenu. Adjusting filters can improve submenu opening speeds.");
                }
            }

            if (!addedInEnhancement)
            {
                panel.AddText(new("Text_NoShownEnhancements", 0, 0, PanelWidth + 150, 300), submenu.EmptyText, 60);
            }
        }
    }
}