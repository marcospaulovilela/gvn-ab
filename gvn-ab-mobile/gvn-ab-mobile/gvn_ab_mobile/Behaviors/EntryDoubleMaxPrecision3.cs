using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace gvn_ab_mobile.Behaviors
{
    public class EntryDoubleMaxPrecision3 : EntryLengthBehavior
    {
        public EntryDoubleMaxPrecision3()
        {
            base.MinLength = 1;
            base.MaxLength = 10;
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += OnEntryTextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= OnEntryTextChanged;
        }

        protected override void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = (Entry)sender;

            var buffer = entry.Text;

            buffer = new Regex("^\\d+(\\.\\d{4})$").Replace(entry.Text, "");

            if (buffer.Length > 1 && buffer.Length < 8)
            {

                if (double.Parse(buffer) < 0.5 && double.Parse(buffer) != 0)
                {
                    buffer = "0.5";
                }
                if (double.Parse(buffer) > 500.0)
                {
                    buffer = "500.0";
                }
            }

            entry.Text = buffer;

            base.OnEntryTextChanged(entry, e);
        }
    }
}
