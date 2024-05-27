using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Extensions;
using EnhancementMonkey.Api.Enhancements.Paragon;
using EnhancementMonkey.Api.Enhancements.Unlocks;
using EnhancementMonkey.Api.Enhancements.Weapon;
using EnhancementMonkey.Api.Ui.Submenues;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.AbilitiesMenu;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using System.Collections.Generic;

namespace EnhancementMonkey.Api.Enhancements
{
    /// <summary>
    /// Base class for ModEnhancements, used by all enhancements (including <see cref="ProgressionModEnhancement"/>, <see cref="WeaponEnhancement"/>...)
    /// </summary>
    public abstract class ModEnhancement : ModContent
    {
        /// <summary>
        /// Zero-Arguement Constructor Required for ModContent
        /// </summary>
        protected ModEnhancement() { }

        protected sealed override int Order => Priority;

        public static List<ModEnhancement> Enhancements = GetContent<ModEnhancement>();

        public static Dictionary<EnhancementType, int> EnhancementsInType = new()
        {
            [EnhancementType.Normal] = 0,
            [EnhancementType.Weapon] = 0,
            [EnhancementType.Ability] = 0,
            [EnhancementType.Misc] = 0,
            [EnhancementType.Paragon] = 0
        };

        public sealed override int RegisterPerFrame => EnhancementsLoadedPerFrame;

        // Methods
        public sealed override void Register()
        {
            // Set Defaults
            Cost = BaseCost;
            Locked = LockedByDefault;

            // Check for dependencies
            if (!ModHelper.HasMod(ModID) & ModID != null)
            {
                if (ModID != null)
                {
                    Locked = true;
                    HasDependencies = false;
                    Debug("Enhancement with the ID " + Name + " Does not have the required mod with the ID " + ModID, LogLevel.Dependency);
                    return;
                }
            }

            // Set Enhancement Level
            if (AutoEnhancementLevel)
            {
                if (Modifies != ModifyType.Unlock)
                {
                    if (BaseCost < GetInstance<GoodEnhancements>().BaseCost * 0.9f)
                    {
                        EnhancementLevel = EnhancementLevel.Basic;
                    }
                    else if (BaseCost < GetInstance<GreatEnhancements>().BaseCost * 0.9f)
                    {
                        EnhancementLevel = EnhancementLevel.Good;
                    }
                    else if (BaseCost < GetInstance<AwesomeEnhancements>().BaseCost * 0.9f)
                    {
                        EnhancementLevel = EnhancementLevel.Great;
                    }
                    else if (BaseCost < GetInstance<GodlyEnhancements>().BaseCost * 0.9f)
                    {
                        EnhancementLevel = EnhancementLevel.Awesome;
                    }
                    else if (BaseCost < GetInstance<PureEnhancements>().BaseCost * 0.9f)
                    {
                        EnhancementLevel = EnhancementLevel.Godly;
                    }
                    else if (BaseCost >= GetInstance<PureEnhancements>().BaseCost * 0.9f)
                    {
                        EnhancementLevel = EnhancementLevel.Pure;
                    }

                    Debug($"Set enhancement {Name}'s Enhancement Level to {EnhancementLevel}", LogLevel.Info, true);
                }
            }
            else
            {
                EnhancementLevel = NewEnhancementLevel;
            }
        }

        /// <summary>
        /// Modifies the tower model on buy and changes the actual cost. 
        /// 
        /// Also does stuff related to locking.
        /// 
        /// To apply this enhancement to a particular weapon use <see cref="ModifyWeapon(WeaponModel)"/> 
        /// </summary>
        /// <param name="tower">The EnhancementMonkeyTower that the enhancement's being applied to.</param>
        public void ApplyEnhancement(Il2CppAssets.Scripts.Simulation.Towers.Tower tower)
        {
            // Check for dependiencies
            if (ModID != null & !ModHelper.HasMod(ModID))
            {
                Debug("Enhancement with the ID " + Name + " Does not have the required mod with the ID " + ModID, LogLevel.Dependency);
                return;
            }
            else
            {
                // Check if modifies tower
                if (Modifies > ModifyType.Unlock)
                {
                    ModifyTower(tower);
                }

                foreach(var enhancement in GetContent<ModEnhancement>()) 
                {
                    if(enhancement.Modifies >= ModifyType.Tower) 
                    {
                        ModifyTowerOnNewEnhancement(tower);
                    }
                }

                ModifyOther();
                AbilityMenu.instance.AbilitiesChanged(); // Update Ability Menu

                // Get current open submenu
                ModSubmenu? submenu = null;

                foreach (var submenu_ in GetContent<ModSubmenu>())
                {
                    if (submenu_.Info.Group == EnhancementGroup)
                    {
                        submenu = submenu_;
                    }
                }
                submenu ??= GetContent<ModSubmenu>()[0];
                // Check if locked
                if (LockAfterBuy)
                {
                    Locked = true;
                    if (PopupScreen.instance != null)
                    {
                        PopupScreen.instance.ShowOkPopup("Max amount of this enhancement as been bought!");
                    }

                    OnLock();

                    MainUi.instance?.OpenSubmenu(tower, InGame.instance.uiRect, submenu, EnhancementGroup);
                }
                if (TimesBought >= Max & Max > 0)
                {
                    Locked = true;
                    if (PopupScreen.instance != null)
                    {
                        PopupScreen.instance.ShowOkPopup("Max amount of this enhancement as been bought!");
                    }

                    OnLock();

                    MainUi.instance?.OpenSubmenu(tower, InGame.instance.uiRect, submenu, EnhancementGroup);
                }
                // Check to see if any paragon enhancements have been unlocked
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

                    if (enhancement.HasRequirements & enhancement.HasDependencies & UnlockedLevels.Contains(enhancement.EnhancementLevel))
                    {
                        if (PopupScreen.instance != null && enhancement.HasDependencies)
                        {
                            PopupScreen.instance.ShowOkPopup(enhancement.UnlockText);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Use this when adding new WeaponModels/AttackModels.
        /// 
        /// If provided an attack model, it'll apply it to every weapon model in it.
        /// If provided a weapon model, it'll apply to that weapon only.
        /// 
        /// Will return the new AttackModel
        /// </summary>
        /// <param name="atck">The attack model you'll like to modify.</param>
        public static AttackModel Apply(AttackModel atck)
        {
            foreach (var wpn in atck.weapons)
            {
                foreach (ModEnhancement enhancement in GetContent<ModEnhancement>())
                {
                    if (enhancement.Modifies == ModifyType.Weapon)
                    {
                        for (int i = 0; i < enhancement.TimesBought; i++)
                        {
                            enhancement.ModifyWeapon(wpn);
                        }
                    }
                    else if (enhancement.Modifies == ModifyType.Projectile)
                    {
                        foreach (var proj in wpn.GetDescendants<ProjectileModel>().ToList())
                        {
                            if (proj.GetDamageModel() != null)
                            {
                                for (int i = 0; i < enhancement.TimesBought; i++)
                                {
                                    enhancement.ModifyProjectile(proj);
                                }
                            }
                        }
                    }
                    else if (enhancement.Modifies == ModifyType.WeaponAndProjectile)
                    {
                        for (int i = 0; i < enhancement.TimesBought; i++)
                        {
                            enhancement.ModifyWeapon(wpn);
                        }
                        foreach (var proj in wpn.GetDescendants<ProjectileModel>().ToList())
                        {
                            enhancement.ModifyProjectile(proj);
                        }
                    }
                }
                if (MIB)
                {
                    wpn.GetDescendants<DamageModel>().ForEach(dmgModel => dmgModel.immuneBloonProperties = Il2Cpp.BloonProperties.None);
                }
            }

            return atck;
        }
        /// <summary>
        /// Use this when adding new WeaponModels/AttackModels
        /// 
        /// If provided an attack model, it'll apply it to every weapon model in it.
        /// If provided a weapon model, it'll apply to that weapon only.
        /// 
        /// Will return the nee WeaponModel
        /// </summary>
        /// <param name="wpn">the weapon model you'll like to apply</param>
        public static WeaponModel Apply(WeaponModel wpn)
        {
            foreach (ModEnhancement enhancement in GetContent<ModEnhancement>())
            {
                if (enhancement.Modifies == ModifyType.Weapon)
                {
                    for (int i = 0; i < enhancement.TimesBought; i++)
                    {
                        enhancement.ModifyWeapon(wpn);
                    }
                }
                else if (enhancement.Modifies == ModifyType.Projectile)
                {
                    foreach (var proj in wpn.GetDescendants<ProjectileModel>().ToList())
                    {
                        if (proj.GetDamageModel() != null)
                        {
                            for (int i = 0; i < enhancement.TimesBought; i++)
                            {
                                enhancement.ModifyProjectile(proj);
                            }
                        }
                    }
                }
                else if (enhancement.Modifies == ModifyType.WeaponAndProjectile)
                {
                    for (int i = 0; i < enhancement.TimesBought; i++)
                    {
                        enhancement.ModifyWeapon(wpn);
                    }
                    foreach (var proj in wpn.GetDescendants<ProjectileModel>().ToList())
                    {
                        enhancement.ModifyProjectile(proj);
                    }
                }
                if (MIB)
                {
                    wpn.GetDescendants<DamageModel>().ForEach(dmgModel => dmgModel.immuneBloonProperties = Il2Cpp.BloonProperties.None);
                }
            }
            return wpn;
        }
        /// <summary>
        /// Use if your enhancement doesn't modify anything in particular. Always Ran.
        /// </summary>
        public virtual void ModifyOther()
        {
        }

        /// <summary>
        /// How this enhancement modifies the tower. Ran if <see cref="Modifies"/> > <see cref="ModifyType.Other"/>
        /// </summary>
        /// <param name="tower">The EnhancementMonkeyTower that the enhancement's being applied to.</param>
        public virtual void ModifyTower(Il2CppAssets.Scripts.Simulation.Towers.Tower tower)
        {
            var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
            ModifyTower(towerModel);

            tower.UpdateRootModel(towerModel);
        }

        /// <summary>
        /// Use when your enhancement changes something in a tower that might change when a new enhancement is bought
        /// </summary>
        /// <param name="tower">Tower to apply to</param>
        public virtual void ModifyTowerOnNewEnhancement(Tower tower) 
        {
        }

        /// <summary>
        /// How this enhancement modifies the tower. Ran if <code>Modifies > <see cref="ModifyType.Other"/></code>
        /// </summary>
        /// <param name="towerModel">The TowerModel that the enhancement's being applied to.</param>
        protected virtual void ModifyTower(TowerModel towerModel)
        {
        }

        /// <summary>
        /// Use this to change a specific WeaponModel or when every projectile descendant needs to be changed
        /// 
        /// Does nothing by default, but provides a warning if <code>Modifies = <see cref="ModifyType.Weapon"/></code>  and if ModifyWeapon hasn't been overridden
        /// 
        /// Not a replacement to ModifyTower.
        /// </summary>
        /// <param name="weaponModel">The WeaponModel that's being modified.</param>
        public virtual void ModifyWeapon(WeaponModel weaponModel)
        {
            Debug("Enhancement " + EnhancementName + "doesn't change new weapons.", LogLevel.Warn);
        }
        /// <summary>
        /// Use this to change a specific ProjectileModel
        /// 
        /// Does nothing by default, but provides a warning if Modifies = ModifyType.Projectile and ModifyProjectile hasn't been overriden.
        /// 
        /// Not a replacement to ModifyTower.
        /// /// </summary>
        /// <param name="projectileModel">The ProjectileModel that's being modified</param>
        public virtual void ModifyProjectile(ProjectileModel projectileModel)
        {
            Debug("Enhancement " + EnhancementName + "doesn't change new projectiles.", LogLevel.Warn);
        }
        /// <summary>
        /// Do something special on lock.
        /// </summary>
        public virtual void OnLock()
        {
        }

        //UI
        /// <summary>
        /// Icon GUID
        /// </summary>
        public abstract string Icon { get; }
        /// <summary>
        /// What's shown in the menu.
        /// </summary>
        public virtual string Description => "Applies " + EnhancementName + " To this tower";
        /// <summary>
        /// Name of the enhancement showed in the menu, by default the name of this mod content.
        /// </summary>
        public virtual string EnhancementName => Name.Spaced();
        /// <summary>
        /// Which enhancement level background to show for this tower. By default the original EnhancementLevel.
        /// </summary>
        public virtual EnhancementLevel Background => EnhancementLevel;
        /// <summary>
        /// Prevent this enhancement from being bought after the first time it's bought
        /// </summary>
        public virtual bool LockAfterBuy => false;
        /// <summary>
        /// How many times this can be bought, 0 = unlimited
        /// </summary>
        public virtual uint Max => 0;
        /// <summary>
        /// Used in the mod for locking
        /// </summary>
        public uint TimesBought = 0;
        /// <summary>
        /// Can be bought, if this is set to true then the enhancement will be hidden on next open
        /// </summary>
        public bool Locked = false;
        /// <summary>
        /// Don't change this, because it might mess up the submenus.
        /// </summary>
        public bool Added = false;

        //Pricing
        /// <summary>
        /// Base Cost, will not be affected by game mode.
        /// </summary>
        public abstract int BaseCost { get; }
        /// <summary>
        /// How much it currently costs. 0 before the enhancement has been registerred.
        /// </summary>
        public int Cost = 0;
        /// <summary>
        /// How much more it costs every upgrade based on the base cost. By default 1.2f. 
        /// </summary>
        public virtual float CostMultiplier => 1.2f;

        //Sorting
        /// <summary>
        /// Where to be placed in the menu. Higher priority = further down in the menu.
        /// The priority is compared with the other enhancements in the enhancement level.
        /// Enchanments with the same priority will be organized by alpabetical order.
        /// For Misc enhancements, keep this at atleast 1. Otherwise it could go before the unlocks.
        /// </summary>
        public virtual int Priority => 1;
        /// <summary>
        /// The larger priority, changes the enhancement's color. Also makes it locked behind certain upgrades if the setting is turned on. Only used if Automatic Enhancement Level is set to false.
        /// </summary>
        public virtual EnhancementLevel NewEnhancementLevel => EnhancementLevel.Basic;

        /// <summary>
        /// Enhancement Level of the enhancement, basic before loading.
        /// </summary>
        public EnhancementLevel EnhancementLevel = EnhancementLevel.Basic;

        /// <summary>
        /// Which submenu to put it in (normal is stat)
        /// </summary>
        public abstract EnhancementType EnhancementGroup { get; }

        // Misc
        /// <summary>
        /// Does this enhancement modify new weapons?
        /// </summary>
        public abstract ModifyType Modifies { get; }

        /// <summary>
        /// Is this enhancement locked by default?
        /// </summary>
        public virtual bool LockedByDefault => false;

        /// <summary>
        /// If this ModEnhancement requires another mod. Set to null if it doesn't require another mod.
        /// </summary>
        public virtual string? ModID => null;


        /// <summary>
        /// Does the mod automatically set the enhancement level based on the price?
        /// </summary>
        public virtual bool AutoEnhancementLevel => true;

        public bool HasDependencies = true;
        /// <summary>
        /// Use this for getting the actual base cost after the game mode has been chosen
        /// </summary>
        public int TrueBaseCost = 0;

        public bool hitCamo = false;
        public bool hitLead = false;

        public static Dictionary<EnhancementLevel, string> EnhancementLevelNames = new()
        {
            [EnhancementLevel.Basic] = "Basic",
            [EnhancementLevel.Good] = "Good",
            [EnhancementLevel.Great] = "Great",
            [EnhancementLevel.Awesome] = "Awesome",
            [EnhancementLevel.Godly] = "Godly",
            [EnhancementLevel.Pure] = "Pure",
            [EnhancementLevel.Paragon] = "Paragon",
            [EnhancementLevel.Hidden] = "Hidden",
        };
    }
}
