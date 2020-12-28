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
    public partial class ListViewPage1 : ContentPage
    {
        readonly ServiceManager manager = new ServiceManager();
       
        public ListViewPage1()
        {
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
             
                await Task.Delay(1000);
                var collection = await manager.GetAll();
                lstStudents.BindingContext = collection;
                
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


       
    }
}
