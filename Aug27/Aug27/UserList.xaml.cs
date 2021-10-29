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
    public partial class UserList : ContentPage
    {


        public UserList()
		{
			InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GetPeopleAsync();
        }

        async void OnButtonClicked(object sender, EventArgs e)
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
            else if (txtUserName.Text == "admin" || txtUserName.Text == "Admin" || txtUserName.Text == "ADMIN")
            {
                string action = await DisplayActionSheet("Error", "Cancel", null, "Forbidden, Cannot use reserved username");
            }
            else
            {
                if (viewerEntry.IsChecked)
                {
                    await App.Database.SavePersonAsync(new User
                    {
                        Name = txtUserName.Text,
                        Password = txtPassword.Text,
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        Email = txtEmail.Text,
                        PhoneNumber = txtPhone.Text,
                        Role = "viewer"

                    });
                }
                else if (role1Entry.IsChecked)
                {
                    await App.Database.SavePersonAsync(new User
                    {
                        Name = txtUserName.Text,
                        Password = txtPassword.Text,
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        Email = txtEmail.Text,
                        PhoneNumber = txtPhone.Text,
                        Role = "internal1"

                    });
                }
                else if (role2Entry.IsChecked)
                {
                    await App.Database.SavePersonAsync(new User
                    {
                        Name = txtUserName.Text,
                        Password = txtPassword.Text,
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        Email = txtEmail.Text,
                        PhoneNumber = txtPhone.Text,
                        Role = "internal2"

                    });
                }
                else if (role3Entry.IsChecked)
                {
                    await App.Database.SavePersonAsync(new User
                    {
                        Name = txtUserName.Text,
                        Password = txtPassword.Text,
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        Email = txtEmail.Text,
                        PhoneNumber = txtPhone.Text,
                        Role = "internal3"

                    });
                }
                else if (role4Entry.IsChecked)
                {
                    await App.Database.SavePersonAsync(new User
                    {
                        Name = txtUserName.Text,
                        Password = txtPassword.Text,
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        Email = txtEmail.Text,
                        PhoneNumber = txtPhone.Text,
                        Role = "internal4"

                    });
                }
                await DisplayAlert("Register Result", "Success", "OK");
            }
        }

        async void Button_Clicked_1(object sender, EventArgs e)
        {
            string selectedId = await DisplayPromptAsync("Required Information", "Enter User ID");
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
            else if (txtUserName.Text == "admin" || txtUserName.Text == "Admin" || txtUserName.Text == "ADMIN")
            {
                string action = await DisplayActionSheet("Error", "Cancel", null, "Forbidden, Cannot use reserved username");
            }
            else
            {
                if (viewerEntry.IsChecked)
                {
                    await App.Database.UpdatePersonAsync(new User
                    {
                        ID = int.Parse(selectedId),
                        Name = txtUserName.Text,
                        Password = txtPassword.Text,
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        Email = txtEmail.Text,
                        PhoneNumber = txtPhone.Text,
                        Role = "viewer"

                    });
                }
                else if (role1Entry.IsChecked)
                {
                    await App.Database.UpdatePersonAsync(new User
                    {
                        ID = int.Parse(selectedId),
                        Name = txtUserName.Text,
                        Password = txtPassword.Text,
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        Email = txtEmail.Text,
                        PhoneNumber = txtPhone.Text,
                        Role = "internal1"

                    });
                }
                else if (role2Entry.IsChecked)
                {
                    await App.Database.UpdatePersonAsync(new User
                    {
                        ID = int.Parse(selectedId),
                        Name = txtUserName.Text,
                        Password = txtPassword.Text,
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        Email = txtEmail.Text,
                        PhoneNumber = txtPhone.Text,
                        Role = "internal2"

                    });
                }
                else if (role3Entry.IsChecked)
                {
                    await App.Database.UpdatePersonAsync(new User
                    {
                        ID = int.Parse(selectedId),
                        Name = txtUserName.Text,
                        Password = txtPassword.Text,
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        Email = txtEmail.Text,
                        PhoneNumber = txtPhone.Text,
                        Role = "internal3"

                    });
                }
                else if (role4Entry.IsChecked)
                {
                    await App.Database.UpdatePersonAsync(new User
                    {
                        ID = int.Parse(selectedId),
                        Name = txtUserName.Text,
                        Password = txtPassword.Text,
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        Email = txtEmail.Text,
                        PhoneNumber = txtPhone.Text,
                        Role = "internal4"

                    });
                }
                await DisplayAlert("Update Result", "Success", "OK");
            }
        }

        async void Button_Clicked_2(object sender, EventArgs e)
        {
            string selectedId = await DisplayPromptAsync("Required Information", "Enter User ID");
            var user = await App.Database.GetItemAsync(Convert.ToInt32(selectedId));

            if (user != null)
            {
                await App.Database.DeleteItemAsync(user);
                await DisplayAlert("Success", "Student Deleted= " + selectedId, "OK");
            }
            else
            {
                await DisplayAlert("Required", "User doesn't exist", "OK");
            }
            OnAppearing();
        }
        async void btnBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomePage());
        }



    }
}