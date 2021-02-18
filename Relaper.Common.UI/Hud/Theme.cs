using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Relaper.Common.UI.Drawing;

namespace Relaper.Common.UI.Hud
{
    /// <summary>
    /// Provides utilities to handle HUD themes.
    /// </summary>
    public static class Theme
    {
        /// <summary>
        /// Sets the global theme of the in-game user interface.
        /// </summary>
        public static Color GlobalTheme
        {
            set
            {
                MichaelTheme = value;
                TrevorTheme = value;
                FranklinTheme = value;
            }
        }

        /// <summary>
        /// Gets or sets the theme when the player is playing as Michael De Santa.
        /// </summary>
        public static Color MichaelTheme
        {
            get
            {
                return new HudColor(HudColorType.Michael);
            }
            set
            {
                HudColor.ReplaceValueWithColor(HudColorType.Michael, value);
                HudColor.ReplaceValueWithColor(HudColorType.MichaelDark, value);
            }
        }

        /// <summary>
        /// Gets or sets the theme when the player is playing as Franklin Clinton.
        /// </summary>
        public static Color FranklinTheme
        {
            get
            {
                return new HudColor(HudColorType.Franklin);
            }
            set
            {
                HudColor.ReplaceValueWithColor(HudColorType.Franklin, value);
                HudColor.ReplaceValueWithColor(HudColorType.FranklinDark, value);
            }
        }

        /// <summary>
        /// Gets or sets the theme when the player is playing as Trevor Phillips.
        /// </summary>
        public static Color TrevorTheme
        {
            get
            {
                return new HudColor(HudColorType.Trevor);
            }
            set
            {
                HudColor.ReplaceValueWithColor(HudColorType.Trevor, value);
                HudColor.ReplaceValueWithColor(HudColorType.TrevorDark, value);
            }
        }
    }
}
