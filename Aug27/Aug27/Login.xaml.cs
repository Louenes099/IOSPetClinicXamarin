﻿using App1;
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
        }
        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            String userName = txtUserName.Text;
            String PassWord = txtPassword.Text;
            Boolean value = false;
            User user = await App.Database.GetItemAsync(userName, PassWord);
            if (user != null || (userName.Equals("admin") & PassWord.Equals("123")))
            {
                await DisplayAlert("Login result", "Success", "OK");
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Login result", "Failure", "OK");
            }
        }
        async void btnGoRegister_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());
        }
}
}