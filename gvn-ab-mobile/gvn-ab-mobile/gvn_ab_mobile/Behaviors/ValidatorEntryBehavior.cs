using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace gvn_ab_mobile.Behaviors {
    public abstract class ValidatorEntryBehavior : Validator<Entry> {
        private Color DefaultColor { get; set; }

        public int? MinLength { get; set; }
        public int? MaxLength { get; set; }
        public bool Required { get; set; } = false;

        protected override void OnAttachedTo(Entry bindable) {
            this.DefaultColor = bindable.BackgroundColor;
            bindable.TextChanged += OnEntryTextChanged;
            
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable) {
            bindable.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(bindable);
        }

        /// <summary>
        /// Responsavel por validar a entrada no componente Entry.
        /// </summary>
        /// <param name="input">Entrada do Entry.</param>
        /// <returns> TRUE se a validação tiver sucesso, FALSE se não.</returns>

        public override bool Validate(object sender) {
            var buffer = ((Entry)sender).Text;
            bool valid = !this.Required || (this.Required && !string.IsNullOrEmpty(buffer));
            valid &= string.IsNullOrEmpty(buffer) || !this.MinLength.HasValue || buffer.Length >= this.MinLength;
            valid &= this.isValid(buffer);

            ((Entry)sender).BackgroundColor = valid ? this.DefaultColor : Color.DarkOrange;

            return valid;
        }

        protected virtual void OnEntryTextChanged(object sender, TextChangedEventArgs args) {
            var entry = (Entry)sender;

            //VALIDAÇÃO DE CONTROLE
            this.Validate(sender);

            //LIMITA O TAMANHO DO TEXTO
            if (entry.Text.Length > MaxLength) {
                entry.Text = args.OldTextValue;
            };
        }
    }
}
