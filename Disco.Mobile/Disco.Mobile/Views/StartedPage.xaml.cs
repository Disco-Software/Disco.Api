using Disco.Mobile.ViewModels;
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
    public partial class StartedPage : ContentPage
    {
        public StartedPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            var viewModel = new AccountViewModel(this);
            InitializeComponent();
            this.BindingContext = viewModel;
        }

        //private void welcomeButton_Clicked(object sender, EventArgs e)
        //{
        //    welcomeButton.FadeTo(0, 5000);
        //    welcomeButton.IsVisible = false;
        //    //loginForm.IsVisible = true;
        //    //loginForm.FadeTo(1, 5000);
        //}

        //private void loginButton_Clicked(object sender, EventArgs e)
        //{
        //    DisplayAlert("Test", "This is a test of popup", "ok");
        //}

        ////private void ImageButton_Clicked(object sender, EventArgs e)
        ////{
        ////    if(!string.IsNullOrEmpty(emailValue.Text))
        ////    {
        ////        Animation anim = new Animation(positon => emailButton.TranslateTo(emailButton.TranslationX + 800, emailButton.TranslationY, length: 2000));
        ////        Animation moveAnimation = new Animation();
        ////        moveAnimation.Add(0.1, 1.0, anim);
        ////        moveAnimation.Commit(emailButton, "MoveAnimation", rate: 500, length: 1000, easing: Easing.CubicInOut, (x, y) =>
        ////        {
        ////            emailButton.FadeTo(0, 1000);
        ////            emailButton.IsVisible = false;
        ////            emailFrame.FadeTo(0, 1000);
        ////            emailFrame.IsVisible = false;
        ////            emailText.FadeTo(0, 1000);
        ////            emailText.IsVisible = false;
        ////            emailValue.FadeTo(0, 1000);
        ////            emailValue.IsVisible = false;
        ////            passwordInput.IsVisible = true;
        ////            passwordButton.IsVisible = true;
        ////            passwordText.IsVisible = true;
        ////            passwordText.FadeTo(1, 1000);
        ////            passwordButton.FadeTo(1, 1000);
        ////            passwordInput.FadeTo(1, 1000);
        ////        });
        ////    }
        ////    else
        ////    {
        ////        DisplayAlert("Error", "this input can not be null", "Ok");
        ////    }
        ////}

        ////private void PasswordButton_Clicked(object sender, EventArgs e)
        ////{
        ////    if(!string.IsNullOrEmpty(passwordValue.Text))
        ////    {
        ////        Page pg = new Page { Opacity = 0 };
        ////        Animation anim = new Animation(positon => passwordButton.TranslateTo(passwordButton.TranslationX + 800, passwordButton.TranslationY, length: 2000));
        ////        Animation moveAnimation = new Animation();
        ////        moveAnimation.Add(0.1, 1.0, anim);
        ////        moveAnimation.Commit(emailButton, "MoveAnimation", rate: 500, length: 1000, easing: Easing.CubicInOut, async (x, y) =>
        ////        {
        ////        });

        ////    }
        ////}

        ////private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        ////{
        ////    //RegisterPage page = new RegisterPage { Opacity=0 };
        ////    //Animation pushAnimationHandller = new Animation();
        ////    //Animation pushAnimation = new Animation(opacity => this.Opacity = 1);
        ////    //pushAnimationHandller.Add(0, 1, pushAnimation);
        ////    //pushAnimationHandller.Commit(this, name: "pushAnimation", rate: 16, length: 1000, easing: Easing.CubicInOut, (X, y) =>
        ////    //{
        ////    //    this.FadeTo(0, 1000, Easing.CubicInOut);
        ////    //    this.Navigation.PushAsync(page, false);
        ////    //    page.FadeTo(1, 1000, Easing.CubicInOut);
        ////    //});
        ////}
    }
}