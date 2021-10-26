using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Aug27
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PetDisplay : ContentPage
    {
        public PetDisplay()
        {
            InitializeComponent();
        }
        async void btnBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}