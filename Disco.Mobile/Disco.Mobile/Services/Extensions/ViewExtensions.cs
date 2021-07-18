using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Disco.Mobile.Services.Extensions
{
    public static class ViewExtensions
    {
        public static Task<bool> ColorTo(this VisualElement self, Color fromColor, Color toColor, Action<Color> callback, uint length = 250, Easing easing = null)
        {
            Func<double, Color> transform = (t) =>
              Color.FromRgba(fromColor.R + t * (toColor.R - fromColor.R),
                             fromColor.G + t * (toColor.G - fromColor.G),
                             fromColor.B + t * (toColor.B - fromColor.B),
                             fromColor.A + t * (toColor.A - fromColor.A));
            return ColorAnimation(self, "ColorTo", transform, callback, length, easing);
        }
        public static Task<bool> ColorTo(this VisualElement self, GradientStopCollection bagin,GradientStopCollection end, Action<GradientStopCollection> callback, uint length = 250, Easing easing = null)
        {
            var color = new RadialGradientBrush();
            Func<double, GradientStopCollection> func = (t) =>
                            {
                                var collection = new GradientStopCollection();
                                foreach (var i in bagin)
                                {
                                    foreach (var j in end)
                                    {
                                        i.Color = j.Color;
                                        foreach(var col in collection)
                                        {
                                            col.Color = j.Color;
                                            col.Offset = j.Offset;
                                        }
                                    }
                                }
                                return collection;
                            };
            return ColorAnimation(self, "ColorTo", func, callback, length, easing);
        }
        public static void CancelAnimation(this VisualElement self)
        {
            self.AbortAnimation("ColorTo");
        }

        static Task<bool> ColorAnimation(VisualElement element, string name, Func<double, Color> transform, Action<Color> callback, uint length, Easing easing)
        {
            easing = easing ?? Easing.Linear;
            var taskCompletionSource = new TaskCompletionSource<bool>();

            element.Animate<Color>(name, transform, callback, 16, length, easing, (v, c) => taskCompletionSource.SetResult(c));
            return taskCompletionSource.Task;
        }
        static Task<bool> ColorAnimation(VisualElement element, string name, Func<double, GradientStopCollection> transform, Action<GradientStopCollection> callback, uint length, Easing easing)
        {
            easing = easing ?? Easing.Linear;
            var taskCompletionSource = new TaskCompletionSource<bool>();

            element.Animate<GradientStopCollection>(name, transform, callback, 16, length, easing, (v, c) => taskCompletionSource.SetResult(c));
            return taskCompletionSource.Task;
        }

    }
}
