using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Extensions;
using EnhancementMonkey.Api.Enhancements.Weapon;
using EnhancementMonkey.Api.Ui.Submenues;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
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

        public sealed override int RegisterPerFrame => EnhancementsLoadedPerFrame;

        // Methods
        public sealed override void Register()
        {
            Cost = BaseCost;
            Locked = LockedByDefault;

            if (!ModHelper.HasMod(ModID) & ModID != null)
            {
                if (ModID != null)
                {
                    Locked = true;
                    HasDependencies = false;
                    Debug("Enhancement with the ID " + Name + " Does not have the required mod with the ID " + ModID, LogLevel.Dependency);
                }
            }
        }

        /// <summary>
        /// Modifies the tower model on buy and changes the actual cost. 
        /// 
        /// Also does stuff related to locking.
        /// 
        /// To apply this enhancement to a particular weapon use <see cref="ModifyWeapon(WeaponModel)"/> 
        /// </summary>
        /// <param name="tower">The Tower that the enhancement's being applied to.</param>
        public void ApplyEnhancement(Il2CppAssets.Scripts.Simulation.Towers.Tower tower)
        {
            if (ModID != null & !ModHelper.HasMod(ModID))
            {
                Debug("Enhancement with the ID " + Name + " Does not have the required mod with the ID " + ModID, LogLevel.Dependency);
                return;
            }
            else
            {
                if (Modifies > ModifyType.Unlock)
                {
                    ModifyTower(tower);
                }
                ModifyOther();
                AbilityMenu.instance.AbilitiesChanged();

                if (LockAfterBuy)
                {
                    Locked = true;
                    if (PopupScreen.instance != null)
                    {
                        PopupScreen.instance.ShowOkPopup("Max amount of this enhancement as been bought!");
                    }
                    OnLock();
                }
                if (TimesBought >= Max & Max > 0)
                {
                    Locked = true;
                    if (PopupScreen.instance != null)
                    {
                        PopupScreen.instance.ShowOkPopup("Max amount of this enhancement as been bought!");
                    }
                    OnLock();
                }
                ModSubmenu? submenu = null;

                foreach (var submenu_ in GetContent<ModSubmenu>())
                {
                    if (submenu_.Info.Group == EnhancementGroup)
                    {
                        submenu = submenu_;
                    }
                }
                if (submenu == null)
                {
                    submenu = GetContent<ModSubmenu>()[0];
                }

                MainUi.instance?.OpenSubmenu(tower, InGame.instance.uiRect, submenu, EnhancementGroup);
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
        /// <param name="tower">The Tower that the enhancement's being applied to.</param>
        public virtual void ModifyTower(Il2CppAssets.Scripts.Simulation.Towers.Tower tower)
        {
            var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
            ModifyTower(towerModel);

            tower.UpdateRootModel(towerModel);
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
        public virtual string EnhancementName => Space(Name);
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
        /// The larger priority, changes the enhancement's color. Also makes it locked behind certain upgrades if the setting is turned on.
        /// </summary>
        public abstract EnhancementLevel EnhancementLevel { get; }
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

        public bool HasDependencies = true;
        /// <summary>
        /// Use this for getting the actual base cost after the game mode has been chosen
        /// </summary>
        public int TrueBaseCost = 0;

        public bool hitCamo = false;
        public bool hitLead = false;
    }
}
