using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace EZCaves;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    public static Plugin Instance { get; private set; } = null!;
    internal new static ManualLogSource Logger { get; private set; } = null!;
    internal static Harmony? Harmony { get; set; }

    internal static ModConfig BoundConfig { get; private set; } = null!;

    private void Awake()
    {
        Logger = base.Logger;
        Instance = this;

        BoundConfig = new ModConfig(base.Config);

        if (BoundConfig.StepOffset.Value > 2.5f)
        {
            Logger.LogError("StepOffset cannot be higher than 2.5, fixing...");
            BoundConfig.StepOffset.Value = 2.5f;
        }

        if (BoundConfig.StepOffset.Value < 0)
        {
            Logger.LogError("StepOffset cannot be lower than 0, setting to default.");
            BoundConfig.StepOffset.Value = 0.6f;
        }

        Patch();

        Logger.LogInfo($"{MyPluginInfo.PLUGIN_GUID} v{MyPluginInfo.PLUGIN_VERSION} has loaded!");
    }

    internal static void Patch()
    {
        Harmony ??= new Harmony(MyPluginInfo.PLUGIN_GUID);

        Logger.LogDebug("Patching...");

        Harmony.PatchAll();

        Logger.LogDebug("Finished patching!");
    }

    internal static void Unpatch()
    {
        Logger.LogDebug("Unpatching...");

        Harmony?.UnpatchSelf();

        Logger.LogDebug("Finished unpatching!");
    }
}