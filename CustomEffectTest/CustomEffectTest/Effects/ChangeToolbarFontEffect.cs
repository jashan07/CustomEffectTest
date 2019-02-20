using System.Linq;
using Xamarin.Forms;

namespace CustomEffectTest.Effects
{
    public static class ChangeFontEffect
    {
        public static readonly BindableProperty FontProperty = BindableProperty.CreateAttached("Font",
            typeof(string),
            typeof(ChangeToolbarFontEffect),
            null, propertyChanged: OnFontChanged);

        private static void OnFontChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if(bindable is Label labelControl)
            {
                if (!labelControl.Effects.Any((e) => e is ChangeToolbarFontEffect))
                    labelControl.Effects.Add(new ChangeToolbarFontEffect());
            }
            else if(bindable is ToolbarItem toolbarItem)
            {
                if (bindable is ToolbarItem)
                    if (!toolbarItem.Effects.Any((e) => e is ChangeToolbarFontEffect))
                        toolbarItem.Effects.Add(new ChangeToolbarFontEffect());
            }
            return;
        }

        public static string GetFont(BindableObject view)
        {
            return (string)view.GetValue(FontProperty);
        }

        public static void SetFont(BindableObject view, string value)
        {
            view.SetValue(FontProperty, value);
        }

        class ChangeToolbarFontEffect : RoutingEffect
        {
            public ChangeToolbarFontEffect() : base("CustomEffectTest.ChangeToolbarFontEffect") { }
        }
    }
}
