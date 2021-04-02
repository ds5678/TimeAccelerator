using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModSettings;
using UnityEngine;

namespace TimeAccelerator
{
    internal class TimeAcceleratorSettings : JsonModSettings
    {
        [Name("Acceleration key")]
        [Choice("A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z")]
        public int accelerationKey = 1;

        [Name("Acceleration behaviour")]
        [Choice("Hold to accelerate", "Toggle on press")]
        public int accelerationBehaviour = 0;

        [Name("Acceleration speed")]
        [Description("1 = 100%, 2 = 200%")]
        [Slider(0f, 10f, 101)]
        public float accelerationValue = 3f;

        protected override void OnConfirm()
        {
            Settings.accelerationKey = KeyCode.A + accelerationKey;
            Settings.holdToAccelerate = accelerationBehaviour == 0;
            Settings.accelerationValue = accelerationValue;
        }
    }


    internal static class Settings
    {
        internal static KeyCode accelerationKey = KeyCode.V;
        internal static float accelerationValue = 3.0f;
        internal static bool holdToAccelerate = false;
        private static TimeAcceleratorSettings options;
        internal static void OnLoad()
        {
            options = new TimeAcceleratorSettings();
            options.AddToModSettings("Time Accelerator", MenuType.Both);
        }
    }
}
