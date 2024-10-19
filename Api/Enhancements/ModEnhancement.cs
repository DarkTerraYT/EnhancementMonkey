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


        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        protected sealed override int Order => Priority;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public sealed override int RegisterPerFrame => EnhancementsLoadedPerFrame;

        // Methods
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public sealed override void Register()
        {
            // Set Defaults
            Cost = BaseCost;
            Locked = LockedByDefault;

            // Check for dependencies

            foreach (string dependency in DependencyIds.Split(','))
            {
                if (!ModHelper.HasMod(dependency))
                {
                    Locked = true;
                    HasDependencies = false;
                    Debug("Enhancement with the ID " + Name + " Does not have the required mod with the ID " + DependencyIds, LogLevel.Dependency);
                }
            }
            

            // Set Enhancement Level
            if (AutoEnhancementLevel)
            {
                if (Modifies != ModifyType.Unlock)
                {
                    EnhancementLevel newLevel = null!;

                    List<EnhancementLevel> levels = GetContent<EnhancementLevel>();

                    foreach (var level in levels)
                    {
                        if (BaseCost <= level.Cost * 0.9f)
                        {
                            newLevel = level;
                            break;
                        }
                    }

                    newLevel ??= EnhancementLevel.Basic;

                    Debug($"Set enhancement {Name}'s Enhancement Level to {EnhancementLevel.Id}", LogLevel.Info, true);
                }
            }
        }

        /// <summary>
        /// Modifies the tower model on buy and changes the actual cost. 
        /// 
        /// Also does stuff related to locking.
        /// 
        /// To apply this enhancement without these extra functions, use the other various methods in this class.
        /// </summary>
        /// <param name="tower">The EnhancementMonkeyTower that the enhancement's being applied to.</param>
        public void ApplyEnhancement(Il2CppAssets.Scripts.Simulation.Towers.Tower tower)
        {
            // Check for dependiencies
            if (DependencyIds != null & !ModHelper.HasMod(DependencyIds))
            {
                Debug("Enhancement with the ID " + Name + " Does not have the required mod with the ID " + DependencyIds, LogLevel.Dependency);
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
                        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();

                        ModifyTowerOnNewEnhancement(towerModel);

                        tower.UpdateRootModel(towerModel);
                    }
                }

                Cost *= (int)(Cost * CostMultiplier);

                ModifyOther();
                AbilityMenu.instance.AbilitiesChanged(); // Update Ability Menu

                // Get current open submenu
                ModSubmenu submenu = null;

                foreach (var submenu_ in GetContent<ModSubmenu>())
                {
                    if (submenu_.Id == Submenu.Id)
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

                    MainUi.instance?.OpenSubmenu(tower, InGame.instance.uiRect, Submenu.Id);
                }
                if (TimesBought >= Max & Max > 0)
                {
                    Locked = true;
                    if (PopupScreen.instance != null)
                    {
                        PopupScreen.instance.ShowOkPopup("Max amount of this enhancement as been bought!");
                    }

                    OnLock();

                    MainUi.instance?.OpenSubmenu(tower, InGame.instance.uiRect, Submenu.Id);
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
        /// <param name="towerModel">Tower to apply to</param>
        public virtual void ModifyTowerOnNewEnhancement(TowerModel towerModel) 
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
        /// Unable to be bought, if this is set to true then the enhancement will be hidden on next open
        /// </summary>
        public bool Locked = false;
        /// <summary>
        /// Has this enhancement been loaded into the submenu?
        /// </summary>
        public bool Added { get; internal set; } = false;

        //Pricing
        /// <summary>
        /// How much this enhancement costs, will not be affected by game mode.
        /// </summary>
        public abstract int BaseCost { get; }

        /// <summary>
        /// Base cost of the enhancement
        /// </summary>
        public int Cost { get; set; } = 0;
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
        /// The larger priority, changes the enhancement's color. Also makes it locked behind certain upgrades if the setting is turned on. Set automatically if AutoEnhancementLevel is set to true (true by default)
        /// </summary>
        public virtual EnhancementLevel EnhancementLevel { get; internal set; } = EnhancementLevel.Basic;

        /// <summary>
        /// Which submenu to put it in (normal is stat)
        /// </summary>
        public abstract ModSubmenu Submenu { get; }

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
        /// If this ModEnhancement requires another mod. Set as an empty string if it doesn't require another mod. Seperate mods with a comma. Example: public override string? DependencyIds "CardMonkey,Unlimited5thTiers"
        /// </summary>
        public virtual string DependencyIds => "";


        /// <summary>
        /// Does the mod automatically set the enhancement level based on the price?
        /// </summary>
        public virtual bool AutoEnhancementLevel => true;

        /// <summary>
        /// Whether or not 
        /// </summary>
        public bool HasDependencies = true;

        /// <summary>
        /// Unused
        /// </summary>
        public bool hitCamo = false;
        /// <summary>
        /// Unused
        /// </summary>
        public bool hitLead = false;
    }
}
