using UnityEngine;

namespace CustomNapalm;

public class ObjectSpawns : MonoBehaviour
{
    public GameObject bouncyCube;

    public void Awake()
    {
        LoadBouncyCube();
    }

    public void LoadBouncyCube()
    {
        string pluginfolder = System.IO.Path.GetDirectoryName(GetType().Assembly.Location);
        string bundleName = "napalm_assets_all_d73cb56529cc1aab54f6984b9e0d8ad7.bundle";
        string prefabName = "Assets/bouncy.prefab";

        bouncyCube = AssetBundle.LoadFromFile($"{pluginfolder}\\{bundleName}").LoadAsset<GameObject>(prefabName);
        Plugin.Logger.LogInfo("loaded bouncy asset");
    }

    public void SetupBouncyCube(GameObject bouncy)
    {
        GameObject infoRef = GameObject.Find("GameController");

        bouncy.transform.position = infoRef.GetComponent<PlayerTracker>().GetPlayer().position;
        bouncy.tag = "Floor";
        bouncy.layer = LayerMask.NameToLayer("Outdoors");

        GameObject outdoorsChecker = new GameObject();
        outdoorsChecker = Instantiate(outdoorsChecker, bouncy.transform);
        outdoorsChecker.AddComponent<OutdoorsChecker>();

        bouncy.AddComponent<Bouncy>();
    }
}