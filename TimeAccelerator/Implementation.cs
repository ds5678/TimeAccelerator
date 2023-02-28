using HarmonyLib;
using Il2Cpp;
using MelonLoader;
using UnityEngine;

namespace TimeAccelerator;

public class Implementation : MelonMod
{
	public override void OnInitializeMelon()
	{
		Settings.OnLoad();
	}
}

[HarmonyPatch(typeof(InterfaceManager), nameof(InterfaceManager.Update))]
public class TimeAcceleratorUpdate
{
	private static bool accelerated = false;
	public static void Prefix()
	{
		if (InterfaceManager.IsOverlayActiveCached())
		{
		}
		else if (Settings.Instance.accelerationBehaviour == 0)
		{
			bool keyHeld = KeyboardUtilities.InputManager.GetKey(Settings.Instance.accelerationKey);
			Time.timeScale = keyHeld ? Settings.Instance.accelerationValue : 1.0f;
		}
		else
		{
			if (KeyboardUtilities.InputManager.GetKeyDown(Settings.Instance.accelerationKey))
			{
				accelerated = !accelerated;
			}

			Time.timeScale = accelerated ? Settings.Instance.accelerationValue : 1.0f;
		}
	}
}
