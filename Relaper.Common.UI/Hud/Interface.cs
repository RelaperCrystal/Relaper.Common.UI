using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTA.Native;

namespace Relaper.Common.UI.Hud
{
    /// <summary>
    /// Provides utilities to access HUD UI.
    /// </summary>
    public static class HudInterface
    {
        /// <summary>
        /// Sets a value indicating whether the bigger map is active.
        /// </summary>
        public static bool IsBiggerRadarEnabled
        {
            set
            {
                Function.Call(Hash.SET_BIGMAP_ACTIVE, value);
            }
        }

        /// <summary>
        /// Gets or sets the fake wanted level.
        /// </summary>
        /// <remarks>
        /// Fake wanted level, as it's name, is a visually fake wanted level that is used during missions.
        /// It was used a lot in Grand Theft Auto IV, for example, in "Blow Your Cover", and "Three Leaf Clover", causing some players
        /// experiencing troubles that cops don't combat with player. However, in the current generation, the cops system is enhanced so the
        /// cops no longer behaves incorrectly when they are told to combat with player. You can see it's effect in "The Pleato Score" mission.
        /// <para>
        /// <note type="warning">
        /// It overrides <see cref="GTA.Player.WantedLevel"/>. Only use the fake wanted level when you wants to customize the gunfight with cops while
        /// retaining the "wanted" visual effects.
        /// </note>
        /// </para>
        /// </remarks>
        /// <value>
        /// The fake wanted level. Must below 5.
        /// </value>
        /// <exception cref="ArgumentOutOfRangeException">The argument is more than 5.</exception>
        public static int FakeWantedLevel
        {
            get
            {
                return Function.Call<int>(Hash.GET_FAKE_WANTED_LEVEL);
            }
            set
            {
                if (value > 5)
                {
                    throw new ArgumentOutOfRangeException("Only 5 star and below is accepted.");
                }

                Function.Call(Hash.SET_FAKE_WANTED_LEVEL, value);
            }
        }

        /// <summary>
        /// Flashes the radar for a short time.
        /// </summary>
        public static void FlashRadar()
        {
            Function.Call(Hash.FLASH_MINIMAP_DISPLAY);
        }

        /// <summary>
        /// Flashes the special ability bar.
        /// </summary>
        /// <param name="duration">The duration to flash the bar.</param>
        public static void FlashAbilityBar(int duration)
        {
            Function.Call(Hash.FLASH_ABILITY_BAR, duration);
        }

        /// <summary>
        /// Set whether to flash the wanted level status display.
        /// </summary>
        /// <param name="flash">Whether to flash.</param>
        public static void FlashWantedLevel(bool flash)
        {
            Function.Call(Hash.FLASH_WANTED_DISPLAY, flash);
        }

        /// <summary>
        /// Sets the value of the special ability bar.
        /// </summary>
        /// <param name="current">The current (filled) value of the ability bar. If set to <c>5</c> while <paramref name="max"/> set to <c>10</c>, it will fill the bar to 50%.</param>
        /// <param name="max">The max value of the ability bar. If set to <c>10</c> while <paramref name="current"/> set to <c>5</c>, it will fill the bar to 50%.</param>
        public static void SetAbilityBarValue(float current, float max)
        {
            Function.Call(Hash.SET_ABILITY_BAR_VALUE, current, max);
        }
    }
}
