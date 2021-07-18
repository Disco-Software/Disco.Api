using Disco.Mobile.Renderers;
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
    public partial class MainTabbedPage : CustomTabbedPage
    {
        public MainTabbedPage()
        {
            InitializeComponent();
        }

        private void CustomTabbedPage_CenterButtonClicked(object sender, EventArgs e)
        {

        }
    }
}