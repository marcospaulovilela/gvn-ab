using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace gvn_ab_mobile.Behaviors {
    public class EntryNomeBehavior : EntryLengthBehavior {
        public EntryNomeBehavior() {
            base.MinLength = 3;
            base.MaxLength = 70;
        }

        public bool ValidacaoNomeEsus { get; set; } = true;

        protected override void OnAttachedTo(Entry bindable) {
            bindable.TextChanged += OnEntryTextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable) {
            bindable.TextChanged -= OnEntryTextChanged;
        }

        public override bool isValid(object input) {
            if (!ValidacaoNomeEsus) return true;

            var text = ((string)input);
            if (string.IsNullOrEmpty(text)) return false;

            text = text.Trim();

            var textSplited = text.Split(' ');
            if (textSplited.Length == 1) return false;

            for(int i = 1; i< textSplited.Length; i++) {
                if(textSplited[i].Length == 1 && textSplited[i] != "E" && textSplited[i] != "Y") {
                    return false;
                };
            };

            if (textSplited[0].Length == 1 && textSplited[1].Length == 1) return false;

            if(textSplited.Length == 2 && (textSplited[0].Length == 2 && textSplited[1].Length == 2)) return false;

            return true;


        }

        protected override void OnEntryTextChanged(object sender, TextChangedEventArgs e) {
            var entry = (Entry)sender;
            
            var buffer = entry.Text;
            
            buffer = new Regex("[^a-zA-Z ']").Replace(entry.Text, "");
            for (; buffer.IndexOf("  ") != -1; buffer = buffer.Replace("  ", " ")) ;

            buffer = buffer.ToUpper();

            entry.Text = buffer;

            base.OnEntryTextChanged(entry, e);
        }
    }
}
