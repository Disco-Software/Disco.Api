using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Disco.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashScreenPage : ContentPage
    {
        public SplashScreenPage()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            StartedPage startedPage = new StartedPage();
            await Task.Delay(2000);
            Animation anim = new Animation(async c =>
            {
                await Task.Delay(5000);
                await logo.ScaleTo(2,5000);
                await start.FadeTo(0, 3000);
                await end.FadeTo(1, 1000);
            });
            anim.Commit(this, "SetAnimation", rate: 16,length: 5000, easing: Easing.Linear, async (X, y) =>
            {
                await Task.Delay(5000);
                await this.FadeTo(0, 2000);
                await this.Navigation.PushAsync(startedPage);
                await startedPage.FadeTo(1, 2000);
            });
        }
    }
}