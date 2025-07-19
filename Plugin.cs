using BepInEx;
using BepInEx.Logging;
using UnityEngine;

namespace CustomNapalm;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    internal static new ManualLogSource Logger;
    GameObject bouncyCube;

    private void Awake()
    {
        // Plugin startup logic
        Logger = base.Logger;
        Logger.LogInfo($"{MyPluginInfo.PLUGIN_GUID} is loading!!!11!");

        string pluginfolder = System.IO.Path.GetDirectoryName(GetType().Assembly.Location);
        string bundleName = "napalm_assets_all_d73cb56529cc1aab54f6984b9e0d8ad7.bundle";
        string prefabName = "Assets/bouncy.prefab";

        bouncyCube = AssetBundle.LoadFromFile($"{pluginfolder}\\{bundleName}").LoadAsset<GameObject>(prefabName);
        Logger.LogInfo("loaded bouncy asset");
    }

    private void OnSceneLoaded()
    {
        Debug.Log("hi");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            GameObject infoRef = GameObject.Find("GameController");
            Logger.LogInfo(infoRef);

            GameObject newNapalm = Instantiate(bouncyCube);
            newNapalm.transform.position = infoRef.GetComponent<PlayerTracker>().GetPlayer().position;
            newNapalm.tag = "Floor";
            newNapalm.layer = LayerMask.NameToLayer("Outdoors");

            GameObject outdoorsChecker = new GameObject();
            outdoorsChecker = Instantiate(outdoorsChecker, newNapalm.transform);
            outdoorsChecker.AddComponent<OutdoorsChecker>();
        }

        Logger.LogInfo(GameObject.Find("Rocket Launcher Napalm(Clone)"));
        //GunControl.currentWeapon
    }
}
