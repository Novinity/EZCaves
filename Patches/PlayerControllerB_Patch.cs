using GameNetcodeStuff;
using HarmonyLib;

namespace EZCaves.Patches;

[HarmonyPatch(typeof(PlayerControllerB))]
public class PlayerControllerB_Patch
{
    [HarmonyPatch(nameof(PlayerControllerB.Start))]
    [HarmonyPostfix]
    private static void Start_Postfix(PlayerControllerB __instance) {
        __instance.thisController.stepOffset = Plugin.BoundConfig.StepOffset.Value;
        Plugin.Logger.LogDebug(__instance.thisController.stepOffset);
    }
}