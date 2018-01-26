using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace gvn_ab_mobile.Behaviors
{
    public class EntryDifferZeroBehavior : EntryLengthBehavior
    {
        public EntryDifferZeroBehavior()
        {
            base.MinLength = 0;
            base.MaxLength = 2;
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

            buffer = new Regex("^[0][0-9]*").Replace(entry.Text, "");

            entry.Text = buffer;

            base.OnEntryTextChanged(entry, e);
        }
    }
}
