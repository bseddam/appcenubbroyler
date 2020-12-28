using appcenubbroyler.Model;
using appcenubbroyler.Provider;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace appcenubbroyler.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Insert : ContentPage
    {
  
        public Insert()
        {
            InitializeComponent();

        }

        private async void onSave(object sender, EventArgs e)
        {
            Users model = new Users
            {
                Name = txtName.Text,
                Sname = txtSurname.Text,
                Phone = txtPhone.Text,
                Email = txtEmail.Text,
                Password =txtPassword.Text,
                
                Birthday = dtpckrBirthDate.Date
            };

            ServiceManager manager = new ServiceManager();
            MobileResult result = await manager.Insert(model);
            if (result.Result)
            {
                await DisplayAlert("Success", result.Message, "Ok", "Cancel");
                await Navigation.PopModalAsync(true);
            }
            else
            {
                await DisplayAlert("Error", result.Message, "Ok", "Cancel");
            }
        }
    }
}
