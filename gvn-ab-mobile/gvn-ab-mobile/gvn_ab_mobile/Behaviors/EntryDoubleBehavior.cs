using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace gvn_ab_mobile.Behaviors
{
    public class EntryDoubleBehavior : EntryLengthBehavior
    {
        public EntryDoubleBehavior()
        {
            base.MinLength = 0;
            base.MaxLength = 6;
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += OnEntryTextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= OnEntryTextChanged;
        }

        protected override void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = (Entry)sender;
            base.OnEntryTextChanged(entry, e);

            entry.Text = new Regex("/[0-9]{0,3}[.][0-9]$").Replace(entry.Text, "");
        }
    }
}
