using App1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Aug27
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
		{
			InitializeComponent();
        }
        async void btnLogout_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());
        }
        async void btnVetList_Clicked(object sender, EventArgs e)
        {
            var x = await App.DatabaseVet.GetPeopleAsync();
            if (x.Count == 0)
            {
                await DisplayAlert("Alert", "Databse is empty", "OK");
            }
            else
            {
                await Navigation.PushAsync(new VetList());
            }
        }
        async void btnPetDisplay_Clicked(object sender, EventArgs e)
        {
            if (App.User.Role == "viewer" || App.User.Role == "internal2")
            {
                await DisplayAlert("Alert", "Access Denied", "OK");
            }
            else
            {
                var x = await App._PetDatabase.GetPetsAsync();
                if (x.Count == 0)
                {
                    await DisplayAlert("Alert", "Databse is empty", "OK");
                }
                else
                {
                    await Navigation.PushAsync(new PetDisplay());
                }
            }
        }
        async void btnPetRegistration_Clicked(object sender, EventArgs e)
        {
            if (App.User.Role == "viewer" || App.User.Role == "internal2" || App.User.Role == "internal3")
            {
                await DisplayAlert("Alert", "Access Denied", "OK");
            }
            else
            {
                await Navigation.PushAsync(new PetRegister());
            }
        }
        async void btnVetRegistration_Clicked(object sender, EventArgs e)
        {
            if (App.User.Role == "viewer" || App.User.Role == "internal3" || App.User.Role == "internal4")
            {
                await DisplayAlert("Alert", "Access Denied", "OK");
            }
            else
            {
                await Navigation.PushAsync(new VetRegister());
            }
        }
    }
}