using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MyCatsDemo.Services.Interfaces;

namespace MyCatsDemo.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected INavigationService NavigationService;

        public BaseViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }


        public virtual string Title => string.Empty;


        private bool _isBusy = false;

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected async Task ExecuteService(Func<Task> action, Action<Exception> onFailure)
        {
            try
            {
                await action();
            }
            catch (Exception e)
            {
                // TODO: Handle failure
                onFailure(e);
            }
        }


        public virtual void OnPageAppearingAsync()
        {

        }
    }
}
