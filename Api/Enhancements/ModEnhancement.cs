using BTD_Mod_Helper;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Extensions;
using EnhancementMonkey.Api.Enum;
using EnhancementMonkey.Api.Ui;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.AbilitiesMenu;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using EnhancementMonkey.Api.Enhancements.Weapon;

namespace EnhancementMonkey.Api.Enhancements
{
    /// <summary>
    /// Base class for ModEnhancements, used by all enhancements (including <see cref="ProgressionModEnhancement"/>, <see cref="WeaponEnhancement"/>...)
    /// </summary>
    public abstract class ModEnhancement : ModContent
    {
        protected override int Order => Priority;

        // Methods
        public override void Register()
        {
            Cost = BaseCost;
            Locked = LockedByDefault;
        }

        /// <summary>
        /// Modifies the tower model on buy and changes the actual cost. 
        /// 
        /// Also does stuff related to locking.
        /// 
        /// To apply this enhancement to a particular weapon use <see cref="ModifyWeapon(WeaponModel)"/> 
        /// </summary>
        /// <param name="tower">The Tower that the enhancement's being applied to.</param>
        public void ApplyEnhancement(Tower tower)
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
                MainUi.instance?.Close();
                if(PopupScreen.instance != null)
                {
                    PopupScreen.instance.ShowOkPopup("Max amount of this enhancement as been bought!");
                }
                OnLock();
            }
            if (TimesBought >= Max & Max > 0)
            {
                Locked = true;
                MainUi.instance?.Close();
                if(PopupScreen.instance != null)
                {
                    PopupScreen.instance.ShowOkPopup("Max amount of this enhancement as been bought!");
                }
                OnLock();
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
        public AttackModel Apply(AttackModel atck)
        {
            foreach (var wpn in atck.weapons)
            {
                foreach (ModEnhancement enhancement in GetContent<ModEnhancement>())
                {
                    if (enhancement.Modifies == ModifyType.Weapon)
                    {
                        for(int i = 0; i < enhancement.TimesBought; i++)
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
        public WeaponModel Apply(WeaponModel wpn)
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
        public virtual void ModifyTower(Tower tower)
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
            ModHelper.Warning<Main>("Enhancement " + EnhancementName + "doesn't change new weapons.");
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
            ModHelper.Warning<Main>("Enhancement " + EnhancementName + "doesn't change new projectiles.");
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
        public virtual string Description => "Applies " + EnhancementName + "To this tower";
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
        /// 
        /// If set to true, override ModifyWeaponModel and modify the new weapon model there.
        /// </summary>
        public abstract ModifyType Modifies { get; }

        public virtual bool LockedByDefault => false;
    }
}
