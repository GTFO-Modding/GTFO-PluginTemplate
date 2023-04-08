using BepInEx;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using System.Linq;

namespace $safeprojectname$;

[BepInPlugin("$safeprojectname$.GUID", "$safeprojectname$", VersionInfo.Version)]
//[BepInDependency("dev.gtfomodding.gtfo-api", BepInDependency.DependencyFlags.HardDependency)]
internal class EntryPoint : BasePlugin
{
    private Harmony _Harmony = null;

    public override void Load()
    {
        _Harmony = new Harmony($"{VersionInfo.RootNamespace}.Harmony");
        _Harmony.PatchAll();
        Logger.Info($"Plugin has loaded with {_Harmony.GetPatchedMethods().Count()} patches!");
    }

    public override bool Unload()
    {
        _Harmony.UnpatchSelf();
        return base.Unload();
    }
}
