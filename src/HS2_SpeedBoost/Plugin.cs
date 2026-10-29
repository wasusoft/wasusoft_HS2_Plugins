using System;
using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using UnityEngine;

// Raises the maximum speed of H scene animations (normal game and official VR).
// The game picks the speed between a minimum and a maximum using the wheel (or stick),
// so only the maximum is multiplied.
[BepInPlugin(GUID, "SpeedBoost", Version)]
[BepInProcess("HoneySelect2")]
[BepInProcess("HoneySelect2VR")]
public class SpeedBoost : BaseUnityPlugin
{
    public const string GUID = "wasusoft.hs2.speedboost";
    public const string Version = "1.0.0";

    ConfigEntry<float> maxMultiplier;
    Type flagType;
    UnityEngine.Object applied;
    UnityEngine.Object lastFlag;
    float appliedMultiplier;
    float nextCheck;

    // Fields that hold the maximum speeds
    static readonly string[] LoopMax = { "maxLoopSpeedW", "maxLoopSpeedS", "maxLoopSpeedO" };
    static readonly string[] MasturbationMax = { "maxLoopSpeedW", "maxLoopSpeedM", "maxLoopSpeedS", "maxLoopSpeedO" };

    void Awake()
    {
        maxMultiplier = Config.Bind("Speed", "MaxMultiplier", 2f,
            new ConfigDescription("Multiplier for the maximum speed. 1 = original, 2 = twice as fast at maximum.", new AcceptableValueRange<float>(1f, 5f)));
        maxMultiplier.SettingChanged += (s, e) => applied = null;
        flagType = HarmonyLib.AccessTools.TypeByName("HSceneFlagCtrl");
        if (flagType == null) Logger.LogError("HSceneFlagCtrl not found");
    }

    void Update()
    {
        if (flagType == null || Time.unscaledTime < nextCheck) return;
        nextCheck = Time.unscaledTime + 1f;
        var flag = UnityEngine.Object.FindObjectOfType(flagType);
        if (flag == null || flag == applied) return;

        float m = maxMultiplier.Value;
        // When re-applying to the same object, undo the previous multiplier first
        float factor = flag == lastFlag ? m / appliedMultiplier : m;
        Scale(flag, "loopSpeeds", LoopMax, factor);
        Scale(flag, "masterbationSpeeds", MasturbationMax, factor);
        lastFlag = flag;
        applied = flag;
        appliedMultiplier = m;
        Logger.LogInfo("Max speed x" + m);
    }

    static void Scale(object flag, string fieldName, string[] names, float factor)
    {
        FieldInfo f = flag.GetType().GetField(fieldName);
        if (f == null) return;
        object speeds = f.GetValue(flag);
        foreach (var n in names)
        {
            FieldInfo sf = speeds.GetType().GetField(n);
            if (sf != null) sf.SetValue(speeds, (float)sf.GetValue(speeds) * factor);
        }
        f.SetValue(flag, speeds);
    }
}
