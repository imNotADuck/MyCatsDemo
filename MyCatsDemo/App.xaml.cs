using System;
using System.Net.Http;
using MyCatsDemo.Api.Service;
using MyCatsDemo.Api.UseCases;
using MyCatsDemo.Configuration;
using MyCatsDemo.Services.Interfaces;
using MyCatsDemo.Services.Navigation;
using MyCatsDemo.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyCatsDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            RegisterDependency();
            SetupHttpClient();

            MainPage = new NavigationPage(new MyCatsPage());

        }

        protected override void OnStart()
        {

        }

        private void SetupHttpClient()
        {
            var catService = new HttpClient()
            {
                BaseAddress = new Uri(Urls.BASE_URL)
            };

            catService.DefaultRequestHeaders.Add("x-api-key", Urls.API_KEY);

            IoCContainer.Resolve<IHttpClientProvider>()
                .SetHttpClient(CatService.KEY, catService);
        }

        public void RegisterDependency()
        {
            IoCContainer.RegisterSingleton<INavigationService, NavigationService>();
            IoCContainer.RegisterSingleton<IHttpClientProvider, HttpClientProvider>();

            IoCContainer.RegisterType<ICatService, CatService>();

            IoCContainer.RegisterType<IGetAllBreedsUseCase, GetAllBreedsUseCase>();
            IoCContainer.RegisterType<IGetBreedByIdUseCase, GetBreedByIdUseCase>();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
