using ModSettings;
using UnityEngine;

namespace TimeAccelerator
{
	internal class TimeAcceleratorSettings : JsonModSettings
	{
		[Name("Acceleration Key")]
		public KeyCode accelerationKey = KeyCode.B;

		[Name("Acceleration Behaviour")]
		[Choice("Hold to accelerate", "Toggle on press")]
		public int accelerationBehaviour = 0;

		[Name("Acceleration Speed")]
		[Description("1 = 100%, 2 = 200%")]
		[Slider(0f, 10f, 101)]
		public float accelerationValue = 3f;
	}


	internal static class Settings
	{
		internal static TimeAcceleratorSettings options;
		internal static void OnLoad()
		{
			options = new TimeAcceleratorSettings();
			options.AddToModSettings("Time Accelerator", MenuType.Both);
		}
	}
}
