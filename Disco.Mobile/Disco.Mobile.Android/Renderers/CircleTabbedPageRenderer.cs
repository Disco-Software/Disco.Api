using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using Disco.Mobile.Droid.Renderers;
using Disco.Mobile.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(CustomTabbedPage), typeof(CircleTabbedPageRenderer))]
namespace Disco.Mobile.Droid.Renderers
{
    public class CircleTabbedPageRenderer : TabbedPageRenderer
    {
        private readonly Context ctx;
        public CircleTabbedPageRenderer(Context ctx) : base(ctx)
        {
            this.ctx = ctx;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                TabLayout tabLayout = null;
                for (int i = 0; i < ChildCount; ++i)
                {
                    Android.Views.View view = (Android.Views.View)GetChildAt(i);
                    if (view is TabLayout) tabLayout = (TabLayout)view;
                }
                Android.Widget.ImageButton imgButton = new Android.Widget.ImageButton(ctx);
                imgButton.Click += (sender, args) =>
                {
                    ((CustomTabbedPage)e.NewElement).SendCenterButtonClicked();
                    var command = ((CustomTabbedPage)e.NewElement).Command;
                    if (command == null) return;
                    if (command.CanExecute(null))
                    {
                        command.Execute(null);
                    }
                };
                imgButton.SetImageResource(Resource.Drawable.TabButton);
                imgButton.SetBackgroundColor(Android.Graphics.Color.Transparent);
                var viewgroup = ((ViewGroup)tabLayout.GetChildAt(0));
                for (int i = 0; i < viewgroup.ChildCount; ++i)
                {
                    Android.Views.View view = viewgroup.GetChildAt(i);
                    if (view != null)
                    {
                        view.SetPadding(0, 50, 0, 50);
                    }
                }
                imgButton.SetPadding(0, 50, 0, 50);
                viewgroup.RemoveViewAt(2);
                var buttonscount = viewgroup.ChildCount;
                viewgroup.AddView(imgButton, 2);

            }
        }
        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            InvertLayoutThroughScale();

            base.OnLayout(changed, l, t, r, b);
        }

        private void InvertLayoutThroughScale()
        {
            ViewGroup.ScaleY = -1;

            TabLayout tabLayout = null;
            ViewPager viewPager = null;

            for (int i = 0; i < ChildCount; ++i)
            {
                Android.Views.View view = (Android.Views.View)GetChildAt(i);
                if (view is TabLayout) tabLayout = (TabLayout)view;
                else if (view is ViewPager) viewPager = (ViewPager)view;
            }

            tabLayout.ScaleY = viewPager.ScaleY = -1;
            //tabLayout.SetPadding(0, 100, 0, 100);
            tabLayout.SetMinimumHeight(200);
            tabLayout.Measure(0, 0);
            viewPager.SetPadding(0, Math.Min(-270, -tabLayout.MeasuredHeight), 0, 0);

            tabLayout.ScaleY = viewPager.ScaleY = -1;
            viewPager.SetPadding(0, -tabLayout.MeasuredHeight, 0, 0);
        }
    }
}