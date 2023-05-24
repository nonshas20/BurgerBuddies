using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Android.Graphics.Drawables;
using popo;
using popo.Droid;

namespace popo
{
    public class EntryCustomBehavior : Behavior<Entry>
    {
        private const string PasswordIcon = "show_password_icon.png";
        private const string HideIcon = "hide_password_icon.png";

        protected override void OnAttachedTo(Entry entry)
        {
            entry.Focused += Entry_Focused;
            entry.Unfocused += Entry_Unfocused;

            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.Focused -= Entry_Focused;
            entry.Unfocused -= Entry_Unfocused;

            base.OnDetachingFrom(entry);
        }

        private void Entry_Focused(object sender, FocusEventArgs e)
        {
            if (sender is Entry entry)
            {
                if (entry.IsPassword)
                {
                    entry.IsPassword = false;
                    entry.Behaviors.Remove(this);
                }
            }
        }

        private void Entry_Unfocused(object sender, FocusEventArgs e)
        {
            if (sender is Entry entry)
            {
                if (!entry.IsPassword)
                {
                    entry.IsPassword = true;
                    entry.Behaviors.Add(this);
                }
            }
        }
    }
}