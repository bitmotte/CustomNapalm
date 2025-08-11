using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace CustomNapalm;

public class Loaders : MonoBehaviour
{
    string pluginfolder;
    string bundleName;
    string objectsPath;

    public Rigidbody loadedNapalm;

    public enum NapalmTypes
    {
        DefaultOutdoors,
        BouncyCube
    }

    public static Loaders I { get; private set; }

    public void Awake()
    {
        I = this;
        DontDestroyOnLoad(gameObject);

        pluginfolder = System.IO.Path.GetDirectoryName(GetType().Assembly.Location);
        bundleName = "assets_assets_all_20719035d97114b6e07edcfd3c7259ec.bundle";

        objectsPath = $"{pluginfolder}\\assets\\{bundleName}";

        loadedNapalm = LoadNapalm("Assets/bouncy.prefab", NapalmTypes.DefaultOutdoors);
    }

    public Rigidbody LoadNapalm(string address, NapalmTypes loaded)
    {
        Plugin.Logger.LogInfo($"loading {address}");
        GameObject napalm = AssetBundle.LoadFromFile(objectsPath).LoadAsset<GameObject>(address);

        SetupBouncyCube(napalm, loaded);

        return napalm.GetComponent<Rigidbody>();
    }

    public void SetupBouncyCube(GameObject napalm, NapalmTypes loaded)
    {
        switch (loaded)
        {
            case NapalmTypes.BouncyCube:
                Plugin.Logger.LogInfo("setting up default outdoors");

                napalm.tag = "Floor";
                napalm.layer = LayerMask.NameToLayer("Outdoors");

                napalm.AddComponent<OutdoorsChecker>();
                break;
        }
    }
}