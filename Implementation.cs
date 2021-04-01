using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using Harmony;
using UnityEngine;

namespace TimeAccelerator
{
    public class Implementation : MelonMod
    {
        public override void OnApplicationStart()
        {
            Debug.Log($"[{Info.Name}] Version {Info.Version} loaded!");
            Settings.OnLoad();
        }
    }

    [HarmonyPatch(typeof(InterfaceManager), "Update")]
    public class TimeAcceleratorUpdate
    {
        static bool accelerated = false;
        public static void Prefix(HUDManager __instance)
        {
            if (Settings.holdToAccelerate)
            {
                if (KeyboardUtilities.InputManager.GetKey(Settings.accelerationKey))
                {
                    Time.timeScale = Settings.accelerationValue;
                }
                else
                {
                    Time.timeScale = 1.0f;
                }
            }
            else
            {
                if (KeyboardUtilities.InputManager.GetKeyDown(Settings.accelerationKey))
                {
                    accelerated = !accelerated;
                }

                if (accelerated) Time.timeScale = Settings.accelerationValue;
                else             Time.timeScale = 1.0f;
            }
        }
    }
}
