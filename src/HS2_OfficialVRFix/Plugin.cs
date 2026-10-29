using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using HTC.UnityPlugin.Vive;
using UnityEngine;

// Fix for the official VR mode (HoneySelect2VR.exe) on Quest 3 + Virtual Desktop + SteamVR.
// When the headset model name contains "Quest", the game reads the sticks through Oculus input (OVRInput).
// Under SteamVR that input is always zero, so the sticks do nothing. Read them from SteamVR (VIU) instead.
// Also adds an A/X button shortcut for the finish menu, so you do not have to point at the gauge.
[BepInPlugin(GUID, "OfficialVRFix", Version)]
[BepInProcess("HoneySelect2VR")]
public class OfficialVRFix : BaseUnityPlugin
{
    public const string GUID = "wasusoft.hs2.officialvrfix";
    public const string Version = "1.0.0";

    static ConfigEntry<bool> finishButton;
    static bool holdingFinishButton;

    HandRole holdHand;
    bool holding, moved, setEnter;
    HSceneSprite sprite;
    float nextSearch;

    void Awake()
    {
        finishButton = Config.Bind("Controls", "FinishButton", true,
            "A/X button controls the finish menu. Tap: finish with the shown type. Hold + stick up/down: change the type (speed does not change while holding).");

        var h = new Harmony(GUID);
        foreach (var type in new[] { "HScene", "HSceneSpriteFinishCategory", "HS2VR.GripMoveCrtl" })
        {
            var m = AccessTools.Method(AccessTools.TypeByName(type), "GetAxis", new[] { typeof(HandRole) });
            if (m == null) { Logger.LogError(type + ".GetAxis not found"); continue; }
            var prefix = type == "HScene" ? nameof(GetAxisSpeed) : nameof(GetAxis);
            h.Patch(m, prefix: new HarmonyMethod(typeof(OfficialVRFix), prefix));
        }
        Logger.LogInfo("loaded");
    }

    // Return the stick value as soon as it is tilted (no click needed)
    static bool GetAxis(HandRole _hand, ref Vector2 __result)
    {
        __result = ViveInput.GetPadAxis(_hand);
        return false;
    }

    // Same, but the speed does not change while the finish button is held
    static bool GetAxisSpeed(HandRole _hand, ref Vector2 __result)
    {
        __result = holdingFinishButton ? Vector2.zero : ViveInput.GetPadAxis(_hand);
        return false;
    }

    void Update()
    {
        holdingFinishButton = false;
        if (!finishButton.Value) return;
        if (sprite == null)
        {
            holding = false;
            if (Time.unscaledTime < nextSearch) return;
            nextSearch = Time.unscaledTime + 1f;
            sprite = FindObjectOfType<HSceneSprite>();
            if (sprite == null) return;
        }
        var finish = sprite.categoryFinish;
        if (finish == null) return;

        if (!holding)
        {
            foreach (var hand in new[] { HandRole.RightHand, HandRole.LeftHand })
            {
                if (!ViveInput.GetPressDownEx(hand, ControllerButton.AKey)) continue;
                holding = true; moved = false; holdHand = hand;
                setEnter = !finish.onEnter;
                finish.onEnter = true;
                break;
            }
            if (!holding) return;
        }

        holdingFinishButton = true;
        if (Mathf.Abs(ViveInput.GetPadAxis(holdHand).y) > 0.7f) moved = true;

        if (ViveInput.GetPressUpEx(holdHand, ControllerButton.AKey))
        {
            holding = false;
            holdingFinishButton = false;
            if (setEnter) finish.onEnter = false;
            if (!moved && finish.ActiveID != -1) sprite.OnClickFinish();
        }
    }
}
