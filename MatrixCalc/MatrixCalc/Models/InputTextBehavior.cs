﻿using System;
using Xamarin.Forms;

namespace MatrixCalc.Models
{
	public class InputTextBehavior : Behavior<Entry>
	{
        private Color baseBackgroundColor;
        private Color baseTextColor;

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.Focused += OnFocusedInput;
            bindable.Unfocused += OnUnfocusedInput;
            baseBackgroundColor = bindable.BackgroundColor;
            baseTextColor = bindable.TextColor;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.Focused -= OnFocusedInput;
            bindable.Unfocused -= OnUnfocusedInput;
            base.OnDetachingFrom(bindable);
        }

        private void OnFocusedInput(object sender, FocusEventArgs e)
        {
            var entry = sender as Entry;

            entry.BackgroundColor = baseTextColor;
            entry.TextColor = baseBackgroundColor;
        }

        private void OnUnfocusedInput(object sender, FocusEventArgs e)
        {
            var entry = sender as Entry;

            entry.BackgroundColor = baseBackgroundColor;
            entry.TextColor = baseTextColor;
        }
    }
}

