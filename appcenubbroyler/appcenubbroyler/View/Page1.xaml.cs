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
    public partial class Page1 : ContentPage
    {
        readonly ServiceManager manager = new ServiceManager();
        public Page1()
        {
            LoadData();
            InitializeComponent();
            
        }
        private async void LoadData()
        {
      
                List<Users> users = new List<Users>();
                //await Task.Delay(1000);
                users = await manager.GetAll();
                lstStudents.BindingContext = users;

           
        }
    }
}