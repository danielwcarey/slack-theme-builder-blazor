using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace slack_theme_builder_blazor.Models {
    public class ColorPalette : INotifyPropertyChanged {

        private Color _columnBG;
        public Color ColumnBG { get => _columnBG; set => SetProperty(value, ref _columnBG); }

        private Color _menuBGHover;
        public Color MenuBGHover { get => _menuBGHover; set => SetProperty(value, ref _menuBGHover); }

        private Color _activeItem;
        public Color ActiveItem { get => _activeItem; set => SetProperty(value, ref _activeItem); }

        private Color _activeItemText;
        public Color ActiveItemText { get => _activeItemText; set => SetProperty(value, ref _activeItemText); }

        private Color _hoverItem;
        public Color HoverItem { get => _hoverItem; set => SetProperty(value, ref _hoverItem); }

        private Color _textColor;
        public Color TextColor { get => _textColor; set => SetProperty(value, ref _textColor); }

        private Color _activePresence;
        public Color ActivePresence { get => _activePresence; set => SetProperty(value, ref _activePresence); }

        private Color _mentionBadge;
        public Color MentionBadge { get => _mentionBadge; set => SetProperty(value, ref _mentionBadge); }

        //public override string ToString() => string.Join(',', 
        //    ColorTranslator.ToHtml(ColumnBG),
        //    ColorTranslator.ToHtml(MenuBGHover),
        //    ColorTranslator.ToHtml(ActiveItem),
        //    ColorTranslator.ToHtml(ActiveItemText),
        //    ColorTranslator.ToHtml(HoverItem),
        //    ColorTranslator.ToHtml(TextColor),
        //    ColorTranslator.ToHtml(ActivePresence),
        //    ColorTranslator.ToHtml(MentionBadge)
        //);

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


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void SetProperty<T>(T value, ref T field, [System.Runtime.CompilerServices.CallerMemberName] string propertyName = "") {
            if (!Equals(field, value)) {
                field = value;
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

    }
};

