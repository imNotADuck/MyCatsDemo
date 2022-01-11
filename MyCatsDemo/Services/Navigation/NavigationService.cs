using System;
using System.Threading.Tasks;
using MyCatsDemo.Services.Interfaces;
using Xamarin.Forms;

namespace MyCatsDemo.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        public async Task PushPage(Page page)
        {
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }
    }
}
