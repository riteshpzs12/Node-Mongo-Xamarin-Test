using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DebDeepDa
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //Demo();
        }

        async void HOLA(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("http://192.168.1.27:8081/rit");
            if (response.IsSuccessStatusCode)
            {
                List<MyModel> myModel = JsonConvert.DeserializeObject<List<MyModel>>(GetHttpResponse(response));
                App.Current.MainPage.DisplayAlert(myModel[0].Username, myModel[0].Imagesrc, myModel[0].Pass);
            }
        }

        string GetHttpResponse(HttpResponseMessage httpResponseMessage)
        {
            return httpResponseMessage.Content.ReadAsStringAsync().Result;
        }
    }
}
