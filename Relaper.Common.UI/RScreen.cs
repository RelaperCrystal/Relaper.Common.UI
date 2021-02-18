using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTA.Native;

namespace Relaper.Common.UI
{
    /// <summary>
    /// Provides methods related to scripts.
    /// </summary>
    public static class RScreen
    {
        /// <summary>
        /// Display a help message at the top left corner of the screen.
        /// Calling on each frame is not needed but it will not cause malfunctions.
        /// </summary>
        /// <param name="text">The text to display.</param>
        /// <param name="duration">The duration that the message will show. If zero or less, it will be set to around 3 seconds. If 5000 or more, it will be 5 seconds.</param>
        /// <param name="beep">If <c>true</c>, the sound effect will play.</param>
        /// <remarks>
        /// This method is used in place as the original <see cref="GTA.UI.Screen.ShowHelpTextThisFrame(string)"/> method provided, which follows an incorrectly
        /// made GTAForums thread. The correct implementation can be found at SHVDN API v2 sources and still available to v2 developers today. It functions more or less the same
        /// like the RPH-equivalent (aka <c>Game.DisplayHelp(string, int)</c>).
        /// </remarks>
        public static void DisplayHelp(string text, int duration = 5000, bool beep = true)
        {
            Function.Call(Hash.BEGIN_TEXT_COMMAND_DISPLAY_HELP, "STRING");
            Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, text);
            Function.Call(Hash.END_TEXT_COMMAND_DISPLAY_HELP, 0, false, beep, duration);
        }
    }
}
