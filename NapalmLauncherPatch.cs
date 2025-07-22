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
        static bool ShootCustomNapalm(RocketLauncher __instance)
        {
            Plugin.Logger.LogInfo("napalm time :3");

            var napalmProjectileField = AccessTools.Field(typeof(RocketLauncher), "napalmProjectile");
            Plugin.Logger.LogInfo(napalmProjectileField.GetValue(__instance));
            napalmProjectileField.SetValue(__instance, null);

            return true;
        }
    }
}
