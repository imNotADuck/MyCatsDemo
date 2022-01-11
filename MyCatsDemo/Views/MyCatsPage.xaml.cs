using System;
using System.Collections.Generic;
using MyCatsDemo.Configuration;
using MyCatsDemo.ViewModels;
using Xamarin.Forms;

namespace MyCatsDemo.Views
{
    public partial class MyCatsPage
    {

        public MyCatsPage()
        {
            InitializeComponent();
        }

        protected override CatBreedsViewModel BuildViewModel()
        {
            return IoCContainer.Resolve<CatBreedsViewModel>();
        }

        
    }
}
