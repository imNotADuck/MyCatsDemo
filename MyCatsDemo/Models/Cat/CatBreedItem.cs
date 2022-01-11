using System;
using System.Windows.Input;
using MyCatsDemo.Configuration;
using MyCatsDemo.Services.Interfaces;
using MyCatsDemo.Views;
using Xamarin.Forms;

namespace MyCatsDemo.Models.Cat
{
    public class CatBreedItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public ICommand OnCatClickedCommand => new Command(OnCatClicked);

        private void OnCatClicked()
        {
            IoCContainer.Resolve<INavigationService>().PushPage(new MyCatDetailPage(Id));
        }
    }
}
