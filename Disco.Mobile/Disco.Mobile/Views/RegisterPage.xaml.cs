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
    public partial class RegisterPage : ContentPage
    {
        //ViewModels.AccountViewModel vm;
        public RegisterPage()
        {
            InitializeComponent();
            var vm = new ViewModels.AccountViewModel(this);
            this.BindingContext = vm;
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}