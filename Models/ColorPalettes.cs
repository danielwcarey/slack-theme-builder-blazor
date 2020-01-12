using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;

namespace slack_theme_builder_blazor.Models {
    public class ColorPalettes {

        private static Color HexColor(string hex) => ColorTranslator.FromHtml(hex);

        public static ColorPalette Default = new ColorPalette();

        public static ColorPalette Aubergine = new ColorPalette() {
            ColumnBG = HexColor("#3F0E40"),
            MenuBGHover = HexColor("#350d36"),
            ActiveItem = HexColor("#1164A3"),
            ActiveItemText = HexColor("#FFFFFF"),
            HoverItem = HexColor("#350D36"),
            TextColor = HexColor("#FFFFFF"),
            ActivePresence = HexColor("#2BAC76"),
            MentionBadge = HexColor("#CD2553"),
        };

        public static ColorPalette Nocturne = new ColorPalette {
            ColumnBG = HexColor("#1A1D21"),
            MenuBGHover = HexColor("#000000"),
            ActiveItem = HexColor("#0576B9"),
            ActiveItemText = HexColor("#FFFFFF"),
            HoverItem = HexColor("#000000"),
            TextColor = HexColor("#FFFFFF"),
            ActivePresence = HexColor("#39E500"),
            MentionBadge = HexColor("#CC4400"),
        };
    }
}
