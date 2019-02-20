using System;
using System.ComponentModel;
using Android.Graphics;
using Android.Widget;
using CustomEffectTest.Droid;
using CustomEffectTest.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("CustomEffectTest")]
[assembly: ExportEffect(typeof(ChangeToolbarFontEffect), "ChangeToolbarFontEffect")]
namespace CustomEffectTest.Droid
{
    class ChangeToolbarFontEffect : PlatformEffect
    {
        TextView control;

        protected override void OnAttached()
        {
            try
            {
                control = Control as TextView;
                Typeface font = Typeface.CreateFromAsset(Forms.Context.ApplicationContext.Assets, ChangeFontEffect.GetFont(Element));
                control.Typeface = font;
            }
            catch(Exception e)
            {

            }
        }

        protected override void OnDetached()
        {
            
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            if (args.PropertyName == ChangeFontEffect.FontProperty.PropertyName)
            {
                var val = ChangeFontEffect.GetFont(Element);
                if (val != null)
                {
                    Typeface font = Typeface.CreateFromAsset(Forms.Context.ApplicationContext.Assets, ChangeFontEffect.GetFont(Element));
                    control.Typeface = font;
                }
            }
        }
    }
}