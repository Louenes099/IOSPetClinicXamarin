using App1;
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
    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();
        }


        async void btnRegister_Clicked(object sender, EventArgs e)
        {
            await App.Database.SavePersonAsync(new User
            {
                Name = txtUserName.Text,
                Password = txtPassword.Text
            });
            await DisplayAlert("Register Result", "Success", "OK");
            await Navigation.PushAsync(new Login());
        }
    }
}