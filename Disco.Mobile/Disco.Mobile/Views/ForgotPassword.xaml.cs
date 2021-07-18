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
    public partial class ForgotPassword : Rg.Plugins.Popup.Pages.PopupPage
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }
    }
}