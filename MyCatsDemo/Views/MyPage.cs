using System;
using MyCatsDemo.ViewModels;
using Xamarin.Forms;

namespace MyCatsDemo.Views
{
    public abstract class MyPage<TViewModel> : ContentPage where TViewModel : BaseViewModel
    {
        public TViewModel ViewModel { get; private set; }

        public MyPage()
        {
            BindingContext = ViewModel = BuildViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModel.OnPageAppearingAsync();
        }

        protected abstract TViewModel BuildViewModel();
    }
}
