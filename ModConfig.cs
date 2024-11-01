using BepInEx.Configuration;

namespace EZCaves;

public class ModConfig
{
    public readonly ConfigEntry<float> StepOffset;

    public ModConfig(ConfigFile cfg) {
        StepOffset = cfg.Bind(
            "General",
            "StepOffset",
            0.6f,
            "How high your character can step up.");
    }
}