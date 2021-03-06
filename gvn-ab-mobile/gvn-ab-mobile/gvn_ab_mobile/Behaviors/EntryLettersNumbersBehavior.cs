﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace gvn_ab_mobile.Behaviors
{
    public class EntryLettersNumbersBehavior : EntryLengthBehavior
    {
        public EntryLettersNumbersBehavior()
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

            buffer = new Regex("[^0-9a-zA-Z]*").Replace(entry.Text, "");

            entry.Text = buffer;

            base.OnEntryTextChanged(entry, e);
        }
    }
}
