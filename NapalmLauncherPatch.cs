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
            GameObject tempBouncy = Object.Instantiate(Plugin.objectSpawns.bouncyCube);
            napalmProjectileField.SetValue(__instance, tempBouncy.GetComponent<Rigidbody>());
            Object.Destroy(tempBouncy);
            Rigidbody rb = (Rigidbody)napalmProjectileField.GetValue(__instance);
            Plugin.objectSpawns.SetupBouncyCube(rb.gameObject);

            return true;
        }
    }
}
