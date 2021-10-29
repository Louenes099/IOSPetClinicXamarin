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
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            CreateAdmin();
        }
        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            String userName = txtUserName.Text;
            String PassWord = txtPassword.Text;
            App.User = await App.Database.GetItemAsync(userName, PassWord);
            if (string.IsNullOrWhiteSpace(txtUserName.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                string action = await DisplayActionSheet("Error", "Cancel", null, "Missing Fields, Please fill out properly.");
            }
            if (App.User != null)
            {
                if (App.User.Role == "admin")
                {
                    await DisplayAlert("Login result", "Success", "OK");
                    await Navigation.PushAsync(new HomePage());
                }
                else
                {
                    await DisplayAlert("Login result", "Success", "OK");
                    await Navigation.PushAsync(new MainPage());
                }
            }
            else
            {
                await DisplayAlert("Login result", "Failure", "OK");
            }
        }
        async void CreateAdmin()
        {
            var x = await App.Database.GetPeopleAsync();
            if (x.Count == 0)
            {
                await App.Database.SavePersonAsync(new User
                {
                    Name = "admin",
                    Password = "123",
                    FirstName = "System",
                    LastName = "Admin",
                    Email = "Email",
                    PhoneNumber = "Phone",
                    Role = "admin"

                });
            }
        }

        async void btnGoRegister_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());
        }
}
}