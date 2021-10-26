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
    public partial class VetRegister : ContentPage
    {
        public VetRegister()
        {
            InitializeComponent();
        }


        async void btnVetRegister_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtVetId.Text) || string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtTelephone.Text) || string.IsNullOrWhiteSpace(txtResume.Text) ||
                string.IsNullOrWhiteSpace(txtSpecialty.Text) || string.IsNullOrWhiteSpace(txtWorkday.Text))
            {
                string action = await DisplayActionSheet("Error", "Cancel", null, "Missing Fields, Please fill out properly.");
            }
            else
            {
                await App.DatabaseVet.SavePersonAsync(new Vet
                {
                    VetId = txtVetId.Text,
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Email = txtEmail.Text,
                    Telephone = txtTelephone.Text,
                    Resume = txtResume.Text,
                    Specialty = txtSpecialty.Text,
                    Workday = txtWorkday.Text

                });
                await DisplayAlert("Register Result", "Success", "OK");
                await Navigation.PushAsync(new VetList());
            }
        }
    }
}