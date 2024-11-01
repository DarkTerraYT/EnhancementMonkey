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
using System.Collections;
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

        private static ModHelperScrollPanel enhancementScrollPanel;

        private static Tower enhancementMonkey;

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
                if (submenu.Info.Group == EnhancementType.Hide)
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

            enhancementMonkey = tower;

            foreach (ModSubmenu menu in submenus)
            {
                float y = (200 * submenus.Count) + 40 - 200 * submenus.IndexOf(menu) - 50 - submenus.IndexOf(menu) * 10;

                ModHelperButton button2 = panel.AddButton(new("Button_", 325, y, 500, 200, new()), VanillaSprites.GreenBtnLong, new System.Action(() =>
                {
                    instance.OpenSubmenu(rect, menu, menu.Info.Group);
                }));
                ModHelperText text = button2.AddText(new("Text_", 0, 0, 700, 175), menu.Info.Name, 70);
            }

            var redButton = new SpriteReference(VanillaSprites.RedBtnLong);
            var greenButton = new SpriteReference(VanillaSprites.GreenBtnLong);
            var greenBtnCircle = GetSpriteReference<EnhancementMonkey>("GreenBtnCircleSmall");
            var redBtnCircle = GetSpriteReference<EnhancementMonkey>("RedBtnCircleSmall");
            if (!LevelsUnlocked | ModSubmenu.Filters["Unlocks"])
            {
                var buttonUpgrade = panel.AddButton(new("Button_Upgrade", panel.RectTransform.rect.left, panel.RectTransform.rect.top, 300), VanillaSprites.UpgradeIcon, new Action(() =>
            {
                instance.Close();

                CreateUpgradeButton(rect);

                var btnReturn = panel.AddButton(new("Button_Return_Upgrade", panel.RectTransform.rect.right, panel.RectTransform.rect.top, 200), VanillaSprites.BackBtn, new Action(() =>
                {
                    instance.Close();
                    CreateMainPanel(GetContent<ModSubmenu>(), enhancementMonkey);
                }));
            }));
            }

            var button = panel.AddButton(new("Button_Filter", panel.RectTransform.rect.right, panel.RectTransform.rect.top, 200), VanillaSprites.BlueBtnCircleSmall, new Action(() =>
            {
                instance.Close();

                ModHelperPanel panel1 = rect.gameObject.AddModHelperPanel(new("Panel_Filter", rect.rect.center.x, rect.rect.center.y, 850, 1620), VanillaSprites.BrownInsertPanel);
                instance = panel1.AddComponent<MainUi>();

                panel1.AddText(new("Text_Filters", panel1.RectTransform.rect.center.x, panel1.RectTransform.rect.bottom - 100, 850, 200), "Filters", 100);

                ModHelperButton returnBtn = panel1.AddButton(new("Button_Back", panel1.RectTransform.rect.right, panel1.RectTransform.rect.top, 200), VanillaSprites.BackBtn, new Action(() =>
                {
                    instance.Close();
                    CreateMainPanel(GetContent<ModSubmenu>(), enhancementMonkey);
                }));

                string guid = "";

                if (ModSubmenu.Filters["Unlocks"])
                {
                    guid = greenButton.AssetGUID;
                }
                else
                {
                    guid = redButton.AssetGUID;
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
                enhancementLevels.Remove(EnhancementLevel.Paragon);

                int lowestLevelY = 5;

                var seperatorLine_ = panel1.AddImage(new("Image_Seperator_Level_Unlocks", 0, 305, 850, 10), GetSpriteReference<EnhancementMonkey>("SeperatorLine").AssetGUID);

                for (int i = 0; i < enhancementLevels.Count; i++)
                {
                    string name = ModEnhancement.EnhancementLevelNames[enhancementLevels[i]];

                    string guid2 = "";

                    if (ModSubmenu.Filters[name])
                    {
                        guid2 = greenBtnCircle.AssetGUID;
                    }
                    else
                    {
                        guid2 = redBtnCircle.AssetGUID;
                    }
                    int y = 245 - 120 * i;

                    int seperatorY = y - 60;

                    var seperatorLine = panel1.AddImage(new("Image_Seperator_" + name, 0, seperatorY, 850, 10), GetSpriteReference<EnhancementMonkey>("SeperatorLine").AssetGUID);


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

            var filterIcon = button.AddImage(new("Image_Filter", 0, 0, 125), filterSprite.AssetGUID);
        }

        private static void CreateUpgradeButton(RectTransform rect) 
        {
            float width = 680;
            float height = 780;

            float PanelWidth = width * 1.3f;
            float PanelHeight = height * 1.3f;

            ModHelperPanel panel1 = rect.gameObject.AddModHelperPanel(new("Panel_Upgrade", rect.rect.center.x, rect.rect.center.y, PanelWidth, PanelHeight), VanillaSprites.MainBGPanelGold);
            instance = panel1.AddComponent<MainUi>();

            var title = panel1.AddText(new("Title_", 0, 420, PanelWidth, 160), "Enhancement Levels", 78);

            UpgradeEnhancement? enhancement = null;
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
                ModHelperPanel enhancementPanel = panel1.AddPanel(new("Panel_Enhancement", panel1.RectTransform.rect.center.x, panel1.RectTransform.rect.center.y, width, height), GetSpriteReference<EnhancementMonkey>(ModEnhancement.EnhancementLevelNames[enhancement.Background]).GetGUID());

                var icon = enhancementPanel.AddImage(new("Icon_", 0, 75, 300), enhancement.Icon);
                var name = enhancementPanel.AddText(new("Title_", 0, 320, width, 100), enhancement.EnhancementName, 50);
                var price = enhancementPanel.AddText(new("Cost_", 0, 270, width, 100), "$" + enhancement.Cost);
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
                        if (InGame.instance.GetCash() >= enhancement.Cost)
                        {
                            InGame.instance.AddCash(-enhancement.Cost);
                            enhancementMonkey.worth += enhancement.Cost;
                            enhancement.Cost += (int)(enhancement.TrueBaseCost * enhancement.CostMultiplier);
                            enhancement.TimesBought++;


                            if (!BoughtEnhancements.Contains(enhancement))
                            {
                                BoughtEnhancements.Add(enhancement);
                            }

                            enhancementMonkey.UpdatedModel(enhancementMonkey.towerModel);

                            enhancement.ModifyOther();
                            enhancement.Locked = true;

                            instance.Close();
                            CreateUpgradeButton(rect);

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
                                PopupScreen.instance.ShowOkPopup($"Not enough cash. You need {InGame.instance.GetCash() - enhancement.Cost} more cash.");
                            }
                        }
                    }
                    price.SetText("$" + enhancement.Cost);
                }));
                ModHelperText buyText = buyButton.AddText(new("BuyText_", 0, 0, width / 1.33f, height / 5), "Buy", 100);
            }
            else 
            {
                panel1.AddText(new("Text_NoShownEnhancements", 0, 0, PanelWidth, 300), "You've Unlocked Every Enhancement Level (or your filters are preventing you from seeing them!)", 60);
            }
        }

        private static Tower GetEnhancementMonkey()
        {
            return InGame.instance.bridge.GetAllTowers().ToList().First(tts => tts.tower.towerModel.GetBaseId() == TowerID<EnhancementMonkeyTower>()).tower;
        }

        private static IEnumerator LoadEnhancementPanels(List<ModEnhancement> enhancements, string emptyText)
        {
            float width = 680;
            float height = 780;

            float PanelWidth = width * PanelWidthMultiplier;
            float PanelHeight = height * PanelHeightMultiplier;

            bool addedInEnhancement = false;

            foreach (var enhancement in enhancements)
            {
                if (ModSubmenu.Filters[ModEnhancement.EnhancementLevelNames[enhancement.Background]] & enhancement.BaseCost >= ModSubmenu.MinShowCost)
                {
                    if (!(enhancement.Modifies == ModifyType.Unlock & !ModSubmenu.Filters["Unlocks"]))
                    {
                        ModHelperPanel panel2 = ModHelperPanel.Create(new("EnhancementPanel_", -75, 0, width, height), GetSpriteReference<EnhancementMonkey>(ModEnhancement.EnhancementLevelNames[enhancement.Background]).AssetGUID);

                        var icon = panel2.AddImage(new("Icon_", 0, 75, 300), enhancement.Icon);
                        var name = panel2.AddText(new("Title_", 0, 320, width, 100), enhancement.EnhancementName, 65);
                        var price = panel2.AddText(new("Cost_", 0, 270, width, 100), "$" + enhancement.Cost, 55);

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
                                if (InGame.instance.GetCash() >= enhancement.Cost)
                                {
                                    InGame.instance.AddCash(-enhancement.Cost);
                                    enhancementMonkey.worth += enhancement.Cost;
                                    
                                    enhancement.TimesBought++;

                                    if (!BoughtEnhancements.Contains(enhancement))
                                    {
                                        BoughtEnhancements.Add(enhancement);
                                    }

                                    enhancementMonkey.UpdatedModel(enhancementMonkey.towerModel);

                                    enhancement.ApplyEnhancement(enhancementMonkey);

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
                                        PopupScreen.instance.ShowOkPopup($"Not enough cash. You need {enhancement.Cost - InGame.instance.GetCash()} more cash.");
                                    }
                                }
                            }
                            price.SetText("$" + enhancement.Cost.ToString());
                        }));
                        ModHelperText buyText = buyButton.AddText(new("BuyText_", 0, 0, width / 1.33f, height / 5), "Buy", 100);

                        try
                        {
                            enhancementScrollPanel.AddScrollContent(panel2);
                            addedInEnhancement = true;
                        }
                        catch
                        {
                            Debug($"Couldn't load enhancement for {enhancement.Id}", LogLevel.Warn);
                        }

                        if(instance == null)
                        {
                            yield break;
                        }

                        yield return null;
                    }
                }

            }

            if (!addedInEnhancement)
            {
                enhancementScrollPanel.AddText(new("Text_NoShownEnhancements", 0, 0, PanelWidth + 150, 300), emptyText, 60);
            }

            yield return null;
        }

        public void OpenSubmenu(RectTransform rect, ModSubmenu submenu, EnhancementType group)
        {
            instance?.Close();

            foreach (var enhancement in GetContent<ModEnhancement>())
            {
                enhancement.Added = false;
            }

            List<ModEnhancement> enhancements = GetContent<ModEnhancement>();
            List<ModEnhancement> enhancements_ = [];

            if (submenu.Info.Group != EnhancementType.Paragon)
            {
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
            else if (submenu.Info.Group == EnhancementType.Paragon)
            {
                foreach (var enhancement in GetContent<ParagonEnhancement>())
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

            enhancementScrollPanel = rect.gameObject.AddModHelperScrollPanel(new("Panel_", PanelX, PanelY, PanelWidth, PanelHeight, new()), RectTransform.Axis.Vertical, VanillaSprites.BlueInsertPanel, 45, 100);

            var title = enhancementScrollPanel.AddText(new("Title_", 0, enhancementScrollPanel.RectTransform.rect.bottom - 100, PanelWidth, 160), submenu.Info.Name, 100); // Title
            title.Text.fontSizeMin = 90;
            title.Text.fontSizeMax = 100;

            MainUi ui = enhancementScrollPanel.AddComponent<MainUi>();

            instance = ui;

            ModHelperButton returnBtn = enhancementScrollPanel.AddButton(new("Button_Back", enhancementScrollPanel.RectTransform.rect.right - 125, enhancementScrollPanel.RectTransform.rect.bottom - 125, 200), VanillaSprites.BackBtn, new Action(() =>
            {
                instance.Close();
                CreateMainPanel(GetContent<ModSubmenu>(), enhancementMonkey);
            }));

            MelonCoroutines.Start(LoadEnhancementPanels(enhancements_, submenu.EmptyText));        
        }
    }
}
