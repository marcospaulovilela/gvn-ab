using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace gvn_ab_mobile.Behaviors {
    public class ValidatorPickerBehavior : Validator<Picker> {
        private Color DefaultColor { get; set; }

        protected override void OnAttachedTo(Picker bindable) {
            this.DefaultColor = bindable.BackgroundColor;
            bindable.SelectedIndexChanged += OnIndexChanged;
            
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Picker bindable) {
            bindable.SelectedIndexChanged -= OnIndexChanged;
            base.OnDetachingFrom(bindable);
        }

        public override bool isValid(object input) {
            return input != null && (int)input >= 0;
        }

        public override bool Validate(object sender) {
            if (this.isValid(((Picker)sender).SelectedIndex)) {
                ((Picker)sender).BackgroundColor = this.DefaultColor;
                return true;
            } else {
                ((Picker)sender).BackgroundColor = Color.DarkOrange;
                return false;
            };
        }

        void OnIndexChanged(object sender, EventArgs args) {
            var Picker = (Picker)sender;

            this.Validate(sender);
        }
    }
}
