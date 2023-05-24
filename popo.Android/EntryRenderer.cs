using Android.Content;
using Android.Graphics.Drawables;
using popo;
using popo.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Entry), typeof(CustomEntryRenderer))]
namespace popo.Droid
{
    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                // Set background color to white
                Control.SetBackgroundColor(Android.Graphics.Color.White);

                // Remove underline
                Control.Background = null;

                
            }
        }
    }
}
