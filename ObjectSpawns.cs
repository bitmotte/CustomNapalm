using UnityEngine;

namespace CustomNapalm;

public class ObjectSpawns : MonoBehaviour
{
    GameObject bouncyCube;

    public void Awake()
    {
        SetupBouncyCube();
    }

    public void SetupBouncyCube()
    {
        string pluginfolder = System.IO.Path.GetDirectoryName(GetType().Assembly.Location);
        string bundleName = "napalm_assets_all_d73cb56529cc1aab54f6984b9e0d8ad7.bundle";
        string prefabName = "Assets/bouncy.prefab";

        bouncyCube = AssetBundle.LoadFromFile($"{pluginfolder}\\{bundleName}").LoadAsset<GameObject>(prefabName);
        Plugin.Logger.LogInfo("loaded bouncy asset");

        GameObject infoRef = GameObject.Find("GameController");

        bouncyCube.transform.position = infoRef.GetComponent<PlayerTracker>().GetPlayer().position;
        bouncyCube.tag = "Floor";
        bouncyCube.layer = LayerMask.NameToLayer("Outdoors");

        GameObject outdoorsChecker = new GameObject();
        outdoorsChecker = Instantiate(outdoorsChecker, bouncyCube.transform);
        outdoorsChecker.AddComponent<OutdoorsChecker>();

        bouncyCube.AddComponent<Bouncy>();
    }

    public void SpawnBouncyCube()
    {
        Instantiate(bouncyCube);
    }
}
