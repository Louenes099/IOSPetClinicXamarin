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
    public partial class VetList : ContentPage
    {


        public VetList()
		{
			InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.DatabaseVet.GetPeopleAsync();
        }
        async void btnBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }



    }
}