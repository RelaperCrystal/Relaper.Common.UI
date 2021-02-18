using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTA.Native;

namespace Relaper.Common.UI.Drawing
{
    /// <summary>
    /// Provides utilities to handle HUD coloring. 
    /// </summary>
    public class HudColor
    {
        public HudColor(HudColorType type)
        {
            Type = type;
        }

        /// <summary>
        /// Gets the type of this <see cref="HudColor"/>.
        /// </summary>
        public HudColorType Type { get; private set; }

        /// <summary>
        /// Gets or sets the value of this instance.
        /// </summary>
        public Color Value
        {
            get
            {
                int r;
                int g;
                int b;
                int a;

                unsafe
                {
                    Function.Call(Hash.GET_HUD_COLOUR, Type, &r, &g, &b, &a);
                }

                return Color.FromArgb(a, r, g, b);
            }
            set
            {
                ReplaceValueWithColor(Type, value);
            }
        }

        /// <summary>
        /// Replaces the value of the specified color type with the specified color.
        /// </summary>
        /// <param name="colorType">The type of the color.</param>
        /// <param name="color">The color to replace.</param>
        public static void ReplaceValueWithColor(HudColorType colorType, Color color)
        {
            Function.Call(Hash.REPLACE_HUD_COLOUR_WITH_RGBA, colorType, color.R, color.G, color.B, color.A);
        }

        /// <summary>
        /// Duplicates the value of the <paramref name="source"/> color type and replaces the value of
        /// <paramref name="target"/> color type with the duplicated color.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="target">The target.</param>
        public static void DuplicateValueTo(HudColorType source, HudColorType target)
        {
            Function.Call(Hash.REPLACE_HUD_COLOUR, target, source);
        }

        public static implicit operator Color(HudColor color)
        {
            return color.Value;
        }
    }
}
