using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace gvn_ab_mobile.Behaviors
{
    public class ValidatorPickerSearchBehavior : Validator<Controls.PickerSearch>
    {
        private Color DefaultColor { get; set; }

        public int? MinLength { get; set; }
        public int? MaxLength { get; set; }
        public bool Required { get; set; } = false;

        protected override void OnAttachedTo(Controls.PickerSearch bindable)
        {
            this.DefaultColor = bindable.BackgroundColor;
            bindable.SelectedItemChanged += OnIndexChanged;

            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Controls.PickerSearch bindable)
        {
            bindable.SelectedItemChanged -= OnIndexChanged;
            base.OnDetachingFrom(bindable);
        }

        public override bool isValid(object input)
        {
            return input != null || !this.Required;
        }

        public override bool Validate(object sender)
        {
            var obj = ((Controls.PickerSearch)sender);

            if (this.isValid(obj.SelectedItem))
            {
                obj.SetBackgroundColor(this.DefaultColor);
                return true;
            }
            else
            {
                obj.SetBackgroundColor(Color.DarkOrange);
                return false;
            };
        }

        void OnIndexChanged(object sender, EventArgs args)
        {
            var Picker = ((Controls.PickerSearch)sender);

            this.Validate(sender);
        }
    }
}