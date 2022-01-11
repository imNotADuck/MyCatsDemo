using MyCatsDemo.Configuration;
using MyCatsDemo.ViewModels;

namespace MyCatsDemo.Views
{
    public partial class MyCatDetailPage
    {
        private string _catId;

        public MyCatDetailPage(string catId)
        {
            _catId = catId;
            (ViewModel as CatDetailViewModel).setCatId(catId);

            InitializeComponent();
        }

        protected override CatDetailViewModel BuildViewModel()
        {
            return IoCContainer.Resolve<CatDetailViewModel>();
        }

    }
}
