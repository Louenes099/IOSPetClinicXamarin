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
            if (txtPassword.Text == null || txtPassword.Text.Length < 10)
            {
                await DisplayAlert("Register Result", "Failure, Password should have 10 characters", "OK");
            }
            else if (string.IsNullOrWhiteSpace(txtUserName.Text) || string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                string action = await DisplayActionSheet("Error", "Cancel", null, "Missing Fields, Please fill out properly.");
            }
            else
            {
                await App.Database.SavePersonAsync(new User
                {
                    Name = txtUserName.Text,
                    Password = txtPassword.Text,
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Email = txtEmail.Text,
                    PhoneNumber = txtPhone.Text

                });
                await DisplayAlert("Register Result", "Success", "OK");
                await Navigation.PushAsync(new Login());
            }
        }
    }
}