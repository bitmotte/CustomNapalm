using BepInEx;
using BepInEx.Logging;
using UnityEngine;

namespace CustomNapalm;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    internal static new ManualLogSource Logger;

    public static ObjectSpawns objectSpawns;

    private void Awake()
    {
        // Plugin startup logic
        Logger = base.Logger;
        Logger.LogInfo($"{MyPluginInfo.PLUGIN_GUID} is loading!!!11!");

        //new scripts
        objectSpawns = gameObject.AddComponent<ObjectSpawns>();

        //patches
        NapalmLauncherPatch.Patch();
    }
}
