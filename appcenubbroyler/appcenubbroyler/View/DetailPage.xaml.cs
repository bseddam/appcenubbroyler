using appcenubbroyler.Model;
using appcenubbroyler.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace appcenubbroyler.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailPage : ContentPage
	{
        public DetailPage(Users model)
        {
            InitializeComponent();
            txtName.Text = model.Name;
            txtSurname.Text = model.Sname;
            txtPhone.Text = model.Phone;
            if( model.Birthday!=null)
            dtpckrBirthDate.Date = model.Birthday.Value;
            BindingContext = model;
        }
        private async void onUpdate(object sender, EventArgs e)
        {
            Button myButton = (Button)sender;
            var updatedUser = (Users)myButton.CommandParameter;
            Users model = new Users
            {
                Name = txtName.Text,
                Sname = txtSurname.Text,
                Phone = txtPhone.Text,
                Email = txtEmail.Text,
                Password = txtPassword.Text,

                Birthday = dtpckrBirthDate.Date,
                UserID = updatedUser.UserID
            };

            ServiceManager manager = new ServiceManager();
            MobileResult result = await manager.Update(model);
            if (result.Result)
            {
                await DisplayAlert("Success", result.Message, "OK", "CANCEL");
                await Navigation.PopAsync();
            }
        }
    }
}