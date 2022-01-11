using System;
using MyCatsDemo.DataTemplates;

namespace MyCatsDemo.ViewModels
{
    public class LoadingSkeletonViewModel : ILoading
    {
        public bool IsLoading { get; } = true;
    }
}
