using appcenubbroyler.Model;
using appcenubbroyler.Provider;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace appcenubbroyler.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewPage1 : ContentPage
    {
        readonly ServiceManager manager = new ServiceManager();
       

      
        public ListViewPage1()
        {
            //BindingContext = users;
            InitializeComponent();

            LoadData();
        }
        private void onNew(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Insert());
        }

        private void onRefresh(object sender, EventArgs e)
        {
            LoadData();
        }
        private async void LoadData()
        {
            this.IsBusy = true;
            try
            {
                List<Users> users = new List<Users>();
                //await Task.Delay(1000);
                users = await manager.GetAll();
                lstStudents.BindingContext = users;
                
            }
            finally
            {
                this.IsBusy = false;
            }
        }
        private void onSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView lstView = (ListView)sender;
            if (e.SelectedItem != null)
            {
                var selectedStudent = (Users)e.SelectedItem;
                Navigation.PushAsync(new DetailPage(selectedStudent));
            }

            lstView.SelectedItem = null;
        }

        private async void onDelete(object sender, EventArgs e)
        {

            MenuItem menuItem = (MenuItem)sender;
            Users selectedUser = (Users)menuItem.CommandParameter;
            bool isOk = await DisplayAlert("", "Silməyə əminsinizmi?", "Bəli", "Xeyr");
            if (isOk)
            {
                await manager.Delete(selectedUser);
                //users.Remove(selectedUser);
                //LoadData();
            }
        }

    }
}
