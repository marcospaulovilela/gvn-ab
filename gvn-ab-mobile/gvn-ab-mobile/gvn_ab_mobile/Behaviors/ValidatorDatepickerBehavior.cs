using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace gvn_ab_mobile.Behaviors {
    public class ValidatorDatepickerBehavior : Validator<DatePicker> {
        private Color DefaultColor { get; set; }

        protected override void OnAttachedTo(DatePicker bindable) {
            this.DefaultColor = bindable.BackgroundColor;
            bindable.DateSelected += OnDateChanged;
            
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(DatePicker bindable) {
            bindable.DateSelected -= OnDateChanged;
            base.OnDetachingFrom(bindable);
        }

        public override bool isValid(object input) {
            return input != null;
        }

        public override bool Validate(object sender) {
            if (this.isValid(((DatePicker)sender).Date)) {
                ((DatePicker)sender).BackgroundColor = this.DefaultColor;
                return true;
            } else {
                ((DatePicker)sender).BackgroundColor = Color.DarkOrange;
                return false;
            };
        }

        void OnDateChanged(object sender, EventArgs args) {
            this.Validate((DatePicker)sender);
        }
    }
}
