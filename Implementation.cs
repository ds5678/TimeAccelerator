using Harmony;
using MelonLoader;
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
		private static bool accelerated = false;
		public static void Prefix()
		{
			if (InterfaceManager.IsOverlayActiveCached()) return;
			if (Settings.options.accelerationBehaviour == 0)
			{
				if (KeyboardUtilities.InputManager.GetKey(Settings.options.accelerationKey))
				{
					Time.timeScale = Settings.options.accelerationValue;
				}
				else
				{
					Time.timeScale = 1.0f;
				}
			}
			else
			{
				if (KeyboardUtilities.InputManager.GetKeyDown(Settings.options.accelerationKey))
				{
					accelerated = !accelerated;
				}

				if (accelerated) Time.timeScale = Settings.options.accelerationValue;
				else Time.timeScale = 1.0f;
			}
		}
	}
}
