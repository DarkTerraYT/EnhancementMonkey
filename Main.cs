using MelonLoader;
using BTD_Mod_Helper;
using EnhancementMonkey;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using EnhancementMonkey.Upgrades;
using BTD_Mod_Helper.Api;

[assembly: MelonInfo(typeof(EnhancementMonkey.Main), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace EnhancementMonkey;

public class Main : BloonsTD6Mod
{
    Main Mod;

    public override void OnApplicationStart()
    {
        Mod = this;
    }
}