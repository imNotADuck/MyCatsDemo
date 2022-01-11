using Xamarin.Forms;

namespace MyCatsDemo.DataTemplates
{
    public class ShimmerDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Skeleton { get; set; }

        public DataTemplate Content { get; set; }

        protected sealed override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (container is ILoading loadingView && loadingView.IsLoading)
            {
                return Skeleton;
            }
            else if (item is ILoading loadingModel && loadingModel.IsLoading)
            {
                return Skeleton;
            }
            else
            {
                return GetContentTemplate(item, container);
            }
        }

        protected virtual DataTemplate GetContentTemplate(object item, BindableObject container)
        {
            return Content;
        }
    }
}
