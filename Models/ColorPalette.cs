using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace slack_theme_builder_blazor.Models {

    public class ColorPalette {

        public ColorPalette() {
        }

        public ColorPalette(ColorPalette palette) {
            ColumnBG = palette.ColumnBG;
            MenuBGHover = palette.MenuBGHover;
            ActiveItem = palette.ActiveItem;
            ActiveItemText = palette.ActiveItemText;
            HoverItem = palette.HoverItem;
            TextColor = palette.TextColor;
            ActivePresence = palette.ActivePresence;
            MentionBadge = palette.MentionBadge;
        }

        // Returns a Color struct whose IsKnownColor, IsNamedColor and IsSystemColor are false
        private static Color FromKnownName(Color source) => Color.FromArgb(source.R, source.G, source.B);

        public Color ColumnBG { get; set; } = FromKnownName(Color.Olive);
        public Color MenuBGHover { get; set; } = FromKnownName(Color.Blue);
        public Color ActiveItem { get; set; } = FromKnownName(Color.DarkKhaki);
        public Color ActiveItemText { get; set; } = FromKnownName(Color.DarkSeaGreen);
        public Color HoverItem { get; set; } = FromKnownName(Color.LightSeaGreen);
        public Color TextColor { get; set; } = FromKnownName(Color.AliceBlue);
        public Color ActivePresence { get; set; } = FromKnownName(Color.YellowGreen);
        public Color MentionBadge { get; set; } = FromKnownName(Color.LightYellow);

        public string Text => string.Join(',',
                ColorTranslator.ToHtml(ColumnBG),
                ColorTranslator.ToHtml(MenuBGHover),
                ColorTranslator.ToHtml(ActiveItem),
                ColorTranslator.ToHtml(ActiveItemText),
                ColorTranslator.ToHtml(HoverItem),
                ColorTranslator.ToHtml(TextColor),
                ColorTranslator.ToHtml(ActivePresence),
                ColorTranslator.ToHtml(MentionBadge)
            );
    }
}

