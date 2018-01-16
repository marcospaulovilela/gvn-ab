using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace gvn_ab_mobile.Behaviors {
    public class ValidatorSelectMultipleItems : Validator<Controls.SelectMultipleItems> {
        private Color DefaultColor { get; set; }

        public int? MinLength { get; set; }
        public int? MaxLength { get; set; }

        protected override void OnAttachedTo(Controls.SelectMultipleItems bindable) {
            this.DefaultColor = bindable.BackgroundColor;
            bindable.SelectedItemsChanged += OnIndexChanged;
            
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Controls.SelectMultipleItems bindable) {
            bindable.SelectedItemsChanged -= OnIndexChanged;
            base.OnDetachingFrom(bindable);
        }

        public override bool isValid(object input) {
            var length = ((IEnumerable<object>)input)?.Count();

            var isValid = !this.MinLength.HasValue || length >= this.MinLength;
            isValid &= !this.MaxLength.HasValue || length <= this.MaxLength;

            return isValid;
        } 

        public override bool Validate(object sender) {
            var obj = ((Controls.SelectMultipleItems)sender);

            if (this.isValid(obj.SelectedItems)) {
                obj.SetBackgroundColor(this.DefaultColor);
                return true;
            } else {
                obj.SetBackgroundColor(Color.DarkOrange);
                return false;
            };
        }

        void OnIndexChanged(object sender, EventArgs args) {
            var Picker = ((Controls.SelectMultipleItems)sender);

            this.Validate(sender);
        }
    }
}
