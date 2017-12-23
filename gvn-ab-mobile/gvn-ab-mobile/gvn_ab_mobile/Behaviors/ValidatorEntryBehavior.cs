using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace gvn_ab_mobile.Behaviors {
    public abstract class ValidatorEntryBehavior : Validator<Entry> {
        private Color DefaultColor { get; set; }

        protected int? MaxLength { get; set; }

        protected override void OnAttachedTo(Entry bindable) {
            this.DefaultColor = bindable.BackgroundColor;
            bindable.TextChanged += onTextChanged;
            
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable) {
            bindable.TextChanged -= onTextChanged;
            base.OnDetachingFrom(bindable);
        }

        /// <summary>
        /// Responsavel por validar a entrada no componente Entry.
        /// </summary>
        /// <param name="input">Entrada do Entry.</param>
        /// <returns> TRUE se a validação tiver sucesso, FALSE se não.</returns>

        public override bool Validate(object sender) {
            if (this.isValid(((Entry)sender).Text)) {
                ((Entry)sender).BackgroundColor = this.DefaultColor;
                return true;
            } else {
                ((Entry)sender).BackgroundColor = Color.DarkOrange;
                return false;
            };
        }

        void onTextChanged(object sender, TextChangedEventArgs args) {
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
