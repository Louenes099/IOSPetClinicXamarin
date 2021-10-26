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
    public partial class PetRegister : ContentPage
    {
        public PetRegister()
        {
            InitializeComponent();
        }

        private async void register_btn_clicked(object sender, EventArgs e)
        {
            string name_entered = pet_name_ent.Text;
            string species_entered = pet_type_ent.Text;
            DateTime birth_date_entered = birth_date_picker.Date;

            await App._PetDatabase.SavePetAsync(new Pets
            {
                PetName = name_entered,
                PetType = species_entered,
                birthDate = birth_date_entered
            });
        }
    }
}