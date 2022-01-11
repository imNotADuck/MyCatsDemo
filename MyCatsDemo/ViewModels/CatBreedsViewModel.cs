using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MyCatsDemo.Api.UseCases;
using MyCatsDemo.Models.Cat;
using MyCatsDemo.Services.Interfaces;
using Xamarin.Forms;

namespace MyCatsDemo.ViewModels
{
    public class CatBreedsViewModel : BaseViewModel
    {
        public CatBreedsViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public override string Title => "Bunch of cats";

        private readonly IGetAllBreedsUseCase _getAllBreedsUseCase;
        private ObservableCollection<CatBreedItem> _items;
        private bool _firstLoading = true;
        private ICommand _refreshCommand;
        public CatBreedsViewModel(IGetAllBreedsUseCase getAllBreedsUseCase, INavigationService navigationService) : base(navigationService)
        {
            _getAllBreedsUseCase = getAllBreedsUseCase;
        }

        public ObservableCollection<CatBreedItem> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        public ICommand RefreshCommand
        {
            get => _refreshCommand;
            set
            {
                _refreshCommand = value;
                OnPropertyChanged(nameof(RefreshCommand));
            }
        }

        public async Task RefreshData()
        {
            await ExecuteService(async () =>
            {
                IsBusy = true;
                Items = new ObservableCollection<CatBreedItem>(await _getAllBreedsUseCase.Execute(null));
                IsBusy = false;
            },
            (exception) =>
            {
                IsBusy = false;
            });
        }

        public override async void OnPageAppearingAsync()
        {
            base.OnPageAppearingAsync();

            var navigationPage = Application.Current.MainPage as NavigationPage;
            navigationPage.BarBackgroundColor = Color.FromHex("#324c56");
            navigationPage.BarTextColor = Color.White;

            if (_firstLoading)
            {
                await RefreshData();
                RefreshCommand = new Command(async () => await RefreshData());
                _firstLoading = false;
            }
        }
    }
}
