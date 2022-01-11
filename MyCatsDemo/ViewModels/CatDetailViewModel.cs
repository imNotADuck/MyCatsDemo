using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using MyCatsDemo.Api.UseCases;
using MyCatsDemo.Models.Cat;
using MyCatsDemo.Services.Interfaces;
using Xamarin.Forms;

namespace MyCatsDemo.ViewModels
{
    public class CatDetailViewModel : BaseViewModel
    {
        private string _catId;
        private CatBreedDetail _cat;
        private readonly IGetBreedByIdUseCase _getBreedByIdUseCase;
        private bool _isLoadingError;
        private ICommand _refreshCommand;
        private bool _firstLoading = true;

        public bool LoadingError
        {
            get => _isLoadingError;
            set
            {
                _isLoadingError = value;
                OnPropertyChanged(nameof(LoadingError));
            }
        }

        public CatBreedDetail Cat
        {
            get => _cat;
            set
            {
                _cat = value;
                OnPropertyChanged(nameof(Cat));
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

        public CatDetailViewModel(IGetBreedByIdUseCase getBreedByIdUseCase,
            INavigationService navigationService) : base(navigationService)
        {
            _getBreedByIdUseCase = getBreedByIdUseCase;
        }

        public void setCatId(string catId)
        {
            _catId = catId;
        }

        public async Task LoadData()
        {
            await ExecuteService(async () =>
            {
                LoadingError = false;
                IsBusy = true;
                Cat = await _getBreedByIdUseCase.Execute(new IGetBreedByIdUseCase.Param()
                {
                    CatId = _catId
                });
                IsBusy = false;
            }, (exception) =>
            {
                //Can show UI indicate failure here
                LoadingError = true;
                IsBusy = false;
            });
        }

        public override void OnPageAppearingAsync()
        {
            base.OnPageAppearingAsync();
            LoadData().ContinueWith(task =>
            {
                RefreshCommand = new Command(async () => await LoadData());
            });
        }
    }
}
