using System.Reflection;
using HarmonyLib;
using UnityEngine;

namespace CustomNapalm
{
    public class NapalmLauncherPatch : MonoBehaviour
    {
        public static void Patch()
        {
            Harmony.CreateAndPatchAll(typeof(NapalmLauncherPatch));
        }

        [HarmonyPatch(typeof(RocketLauncher), "ShootNapalm")]
        [HarmonyPrefix]
        static bool ShootCustomNapalmPre(RocketLauncher __instance)
        {
            Plugin.Logger.LogInfo("napalm time :3");
            //
            //var napalmProjectileField = AccessTools.Field(typeof(RocketLauncher), "napalmProjectile");
            //napalmProjectileField.SetValue(__instance, Loaders.Instance.LoadNapalm("Assets/bouncy.prefab"));

            return true;
        }
    }
}
