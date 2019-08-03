using DebDeepDa.Essentials;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace DebDeepDa
{
    public partial class MainPage : ContentPage
    {
        CacheInterface cache;
        MyModel LoginUser;

        public MainPage()
        {
            InitializeComponent();
            cache = new Cache();
            LoginUser = new MyModel();
        }

        async Task CallData(string u, string p)
        {
            bool UserFlag = false;

            if (cache != null)
            {
                if (cache.get(AllKeyStrings.LoginDetails) == null)
                    await getAndaddInCache();
            }
            List<MyModel> myModel = (List<MyModel>)cache.get(AllKeyStrings.LoginDetails);
            myModel.ForEach((model) => 
            {
                if (model.Username == u)
                {
                    UserFlag = true;
                    if (model.Pass == p)
                    {
                        LoginUser = model;
                    }
                }
            });
        }

        private async Task getAndaddInCache()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("http://10.0.0.19:8081/rit");
            if (response.IsSuccessStatusCode)
            {
                List<MyModel> myModel = JsonConvert.DeserializeObject<List<MyModel>>(GetHttpResponse(response));
                cache.add(AllKeyStrings.LoginDetails, myModel);
            }
        }

        string GetHttpResponse(HttpResponseMessage httpResponseMessage)
        {
            return httpResponseMessage.Content.ReadAsStringAsync().Result;
        }

        private async void LoginAsync(object sender, EventArgs e)
        {
            Roles roles = new Roles();
            await CallData(Uname.Text, Pass.Text);
            if(LoginUser != null)
                roles = (Roles)Enum.Parse(typeof(Roles), LoginUser.Role);
            switch (roles)
            {
                case Roles.Customer:
                    App.Current.MainPage.DisplayAlert("Success", String.Format("{0}{1}", "Welcome Customer ", LoginUser.Username), "ok");
                    Navigation.PushAsync(new NavigationPage(new ProfilePage()));
                    break;

                case Roles.Doctor:
                    App.Current.MainPage.DisplayAlert("Success", String.Format("{0}{1}", "Welcome Doctor ", LoginUser.Username), "ok");
                    Navigation.PushAsync(new NavigationPage(new ProfilePage()));
                    break;

                default:
                    App.Current.MainPage.DisplayAlert("Fail", "Who the hell are You", "ok");
                    break;
            }
        }
    }
}
