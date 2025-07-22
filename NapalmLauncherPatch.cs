using HarmonyLib;
using UnityEngine;

namespace CustomNapalm
{
    public class NapalmLauncherPatch
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

            var napalmProjectileField = AccessTools.Field(typeof(RocketLauncher), "napalmProjectile");
            napalmProjectileField.SetValue(__instance, Plugin.objectSpawns.bouncyCube.GetComponent<Rigidbody>());
            Rigidbody rb = (Rigidbody)napalmProjectileField.GetValue(__instance);
            Plugin.objectSpawns.SetupBouncyCube(rb.gameObject);

            return true;
        }
    }
}
