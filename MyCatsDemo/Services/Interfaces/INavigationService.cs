using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyCatsDemo.Services.Interfaces
{
    public interface INavigationService
    {
        Task PushPage(Page page);
    };

}
