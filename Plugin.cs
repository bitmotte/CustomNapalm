using BepInEx;
using BepInEx.Logging;
using UnityEngine;
using HarmonyLib;

namespace CustomNapalm;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    internal static new ManualLogSource Logger;

    private void Awake()
    {
        // Plugin startup logic
        Logger = base.Logger;
        Logger.LogInfo($"{MyPluginInfo.PLUGIN_GUID} is loading!!!!");

        // new scripts
        GameObject loader = new()
        {
            name = "CustomNapalmLoader"
        };
        loader.AddComponent<Loaders>();

        // patches
        NapalmLauncherPatch.Patch();
    }

    private void OnDestroy()
    {
        Harmony.UnpatchAll();
    }

    void Update()
    {
        Instantiate(Loaders.I.loadedNapalm);
    }
}
