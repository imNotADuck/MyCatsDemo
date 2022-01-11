using System;
using System.Collections;
using System.Collections.Generic;
using MyCatsDemo.DataTemplates;
using MyCatsDemo.ViewModels;
using Xamarin.Forms;

namespace MyCatsDemo.Views
{
    public partial class MyCollectionView : ILoading
    {
        public static readonly BindableProperty RealItemsSourceProperty =
            BindableProperty.Create(
                nameof(RealItemsSource),
                typeof(IEnumerable),
                typeof(MyCollectionView),
                defaultValue: null,
                propertyChanged: OnRealItemsSourceChanged);

        public static readonly BindableProperty IsLoadingProperty =
            BindableProperty.Create(
                nameof(IsLoading),
                typeof(bool),
                typeof(MyCollectionView),
                propertyChanged: IsLoadingPropertyChanged);

        public static readonly BindableProperty SkeletonViewNumberProperty =
            BindableProperty.Create(
                nameof(SkeletonViewNumber),
                typeof(int),
                typeof(MyCollectionView),
                defaultValue: 3);

        public MyCollectionView()
        {
            InitializeComponent();
        }

        public IEnumerable FinalItemsSource
        {
            get
            {
                if (IsLoading)
                {
                    var list = new List<LoadingSkeletonViewModel>();
                    for (int i = 0; i < SkeletonViewNumber; i++)
                    {
                        list.Add(new LoadingSkeletonViewModel());
                    }

                    return list;
                }
                else
                {
                    return RealItemsSource;
                }
            }
        }

        public IEnumerable RealItemsSource
        {
            get => (IEnumerable)GetValue(RealItemsSourceProperty);
            set
            {
                SetValue(RealItemsSourceProperty, value);
            }
        }

        public bool IsLoading
        {
            get => (bool)GetValue(IsLoadingProperty);
            set
            {
                SetValue(IsLoadingProperty, value);
            }
        }

        public int SkeletonViewNumber
        {
            get => (int)GetValue(SkeletonViewNumberProperty);
            set
            {
                SetValue(SkeletonViewNumberProperty, value);
            }
        }

        private static void OnRealItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var casted = (MyCollectionView)bindable;

            if (newValue != oldValue)
            {
                casted.OnPropertyChanged(nameof(FinalItemsSource));
            }
        }

        private static void IsLoadingPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var casted = (MyCollectionView)bindable;

            if (!newValue.Equals(oldValue))
            {
                casted.OnPropertyChanged(nameof(FinalItemsSource));
            }
        }
    }
}
