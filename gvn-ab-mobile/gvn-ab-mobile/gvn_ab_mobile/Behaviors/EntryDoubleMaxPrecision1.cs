using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace gvn_ab_mobile.Behaviors
{
    public class EntryDoubleMaxPrecision1 : EntryLengthBehavior
    {
        public EntryDoubleMaxPrecision1()
        {
            base.MinLength = 2;
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

            buffer = new Regex("^\\d+(\\.\\d{2})$").Replace(entry.Text, "");

            if (buffer.Length > 2)
            {

                if (double.Parse(buffer) < 20 && double.Parse(buffer) != 0)
                {
                    buffer = "20";
                }
                if (double.Parse(buffer) > 250.0)
                {
                    buffer = "250.0";
                }
            }

            entry.Text = buffer;

            base.OnEntryTextChanged(entry, e);
        }
    }
}
