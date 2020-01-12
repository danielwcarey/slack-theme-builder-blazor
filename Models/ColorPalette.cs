using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;
using System.Text;

namespace slack_theme_builder_blazor.Models {

    public class ColorPalette : INotifyPropertyChanged {

        public ColorPalette() { }

        // Create Palette from string array of html colors
        public ColorPalette(string colorCsv) => Parse(colorCsv);

        // Create Palette by copying another palette
        public ColorPalette(ColorPalette palette) {
            ColumnBG = FromKnownName(palette.ColumnBG);
            MenuBGHover = FromKnownName(palette.MenuBGHover);
            ActiveItem = FromKnownName(palette.ActiveItem);
            ActiveItemText = FromKnownName(palette.ActiveItemText);
            HoverItem = FromKnownName(palette.HoverItem);
            TextColor = FromKnownName(palette.TextColor);
            ActivePresence = FromKnownName(palette.ActivePresence);
            MentionBadge = FromKnownName(palette.MentionBadge);
        }

        // Index the palette colors.
        public static string IndexName(int index) => index switch
        {
            0 => "ColumnBG",
            1 => "MenuBGHover",
            2 => "ActiveItem",
            3 => "ActiveItemText",
            4 => "HoverItem",
            5 => "TextColor",
            6 => "ActivePresence",
            7 => "MentionBadge",
            _ => "",
        };

        public Color this[int index] {
            get {
                return index switch
                {
                    0 => ColumnBG,
                    1 => MenuBGHover,
                    2 => ActiveItem,
                    3 => ActiveItemText,
                    4 => HoverItem,
                    5 => TextColor,
                    6 => ActivePresence,
                    7 => MentionBadge,
                    _ => FromKnownName(Color.Black),
                };
            }
            set {
                switch (index) {
                    case 0: ColumnBG = FromKnownName(value); break;
                    case 1: MenuBGHover = FromKnownName(value); break;
                    case 2: ActiveItem = FromKnownName(value); break;
                    case 3: ActiveItemText = FromKnownName(value); break;
                    case 4: HoverItem = FromKnownName(value); break;
                    case 5: TextColor = FromKnownName(value); break;
                    case 6: ActivePresence = FromKnownName(value); break;
                    case 7: MentionBadge = FromKnownName(value); break;
                    default: break;
                }
            }
        }

        public Color this[ColorPalettePart index] {
            get {
                return index switch
                {
                    ColorPalettePart.ColumnBG => ColumnBG,
                    ColorPalettePart.MenuBGHover => MenuBGHover,
                    ColorPalettePart.ActiveItem => ActiveItem,
                    ColorPalettePart.ActiveItemText => ActiveItemText,
                    ColorPalettePart.HoverItem => HoverItem,
                    ColorPalettePart.TextColor => TextColor,
                    ColorPalettePart.ActivePresence => ActivePresence,
                    ColorPalettePart.MentionBadge => MentionBadge,
                    _ => FromKnownName(Color.Black),
                };
            }
            set {
                switch (index) {
                    case ColorPalettePart.ColumnBG: ColumnBG = FromKnownName(value); break;
                    case ColorPalettePart.ActiveItem: ActiveItem = FromKnownName(value); break;
                    case ColorPalettePart.ActiveItemText: ActiveItemText = FromKnownName(value); break;
                    case ColorPalettePart.HoverItem: HoverItem = FromKnownName(value); break;
                    case ColorPalettePart.TextColor: TextColor = FromKnownName(value); break;
                    case ColorPalettePart.ActivePresence: ActivePresence = FromKnownName(value); break;
                    case ColorPalettePart.MentionBadge: MentionBadge = FromKnownName(value); break;
                    default: break;
                }
            }
        }

        // Returns a Color struct whose IsKnownColor, IsNamedColor and IsSystemColor are false
        private static Color FromKnownName(Color source) => Color.FromArgb(source.R, source.G, source.B);

        private Color _columnBG = FromKnownName(Color.Olive);
        public Color ColumnBG { get => _columnBG; set => SetProperty(value, ref _columnBG); }

        private Color _menuBGHover = FromKnownName(Color.Blue);
        public Color MenuBGHover { get => _menuBGHover; set => SetProperty(value, ref _menuBGHover); }

        private Color _activeItem = FromKnownName(Color.DarkKhaki);
        public Color ActiveItem { get => _activeItem; set => SetProperty(value, ref _activeItem); }

        private Color _activeItemText = FromKnownName(Color.DarkSeaGreen);
        public Color ActiveItemText { get => _activeItemText; set => SetProperty(value, ref _activeItemText); }

        private Color _hoverItem = FromKnownName(Color.LightSeaGreen);
        public Color HoverItem { get => _hoverItem; set => SetProperty(value, ref _hoverItem); }

        private Color _textColor = FromKnownName(Color.AliceBlue);
        public Color TextColor { get => _textColor; set => SetProperty(value, ref _textColor); }

        private Color _activePresence = FromKnownName(Color.YellowGreen);
        public Color ActivePresence { get => _activePresence; set => SetProperty(value, ref _activePresence); }

        private Color _mentionBadge = FromKnownName(Color.LightYellow);
        public Color MentionBadge { get => _mentionBadge; set => SetProperty(value, ref _mentionBadge); }

        // The palette as a comma-separated string 
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

        // Make a url friendly string
        public string UrlEncoded => System.Web.HttpUtility.UrlEncode(Text);

        // Parse a comma-seperated string and set colors
        public void Parse(string colorCsv) {
            if (string.IsNullOrWhiteSpace(colorCsv)) return;

            _errors.Clear();
            var errorMessages = new List<string>();

            var colorValues = colorCsv.Split(new char[] { ';', ',' });

            for (int index = 0; index < colorValues.Length; index++) {
                try {
                    this[index] = ColorTranslator.FromHtml(colorValues[index]);
                }catch(System.ArgumentException exc) {
                    errorMessages.Add($"{ColorPalette.IndexName(index)}: {exc.Message}");
                }
            }
            if (errorMessages.Any()) {
                Errors.AddRange(errorMessages);
                if (OnParseError != null) OnParseError.Invoke(this, errorMessages);
            }
        }

        private List<string> _errors = new List<string>();
        public List<string> Errors => _errors;

        public EventHandler<List<string>> OnParseError { get; set; }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void SetProperty<T>(T value, ref T field,
            [System.Runtime.CompilerServices.CallerMemberName] string propertyName = "") {
            if (!Equals(field, value)) {
                field = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}

