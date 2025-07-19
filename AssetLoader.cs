using BepInEx;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace CustomNapalm;

public class AssetLoader : BaseUnityPlugin
{
    //tools
    public static void LoadObject(string address)
    {
        AsyncOperationHandle<GameObject> asyncOperationHandle =
            Addressables.LoadAssetAsync<GameObject>(address);

        asyncOperationHandle.Completed += AsyncOperationHandle_Completed;

    }

    public static void Deload()
    {

    }

    //internal
    private static void AsyncOperationHandle_Completed(AsyncOperationHandle<GameObject> asyncOperationHandle)
    {
        if (asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
        {
            Instantiate(asyncOperationHandle.Result);
        }
        else
        {
            Plugin.Logger.LogError("Failed to load object " + asyncOperationHandle.Result.name);
        }
    }
}
