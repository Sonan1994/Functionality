using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using Funcionality.Services.Navigation;
using TinyIoC;
using Xamarin.Forms;
using ZXing.Common.Detector;
using ZXing.QrCode.Internal;

namespace Funcionality.ViewModels.Base
{
    public static class ViewModelLocator
    {
        private static TinyIoCContainer _container;

        public static readonly BindableProperty AutoWireViewModelProperty = 
            BindableProperty.Create("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), default(bool), propertyChanged: OnAutoWireViewModelChanged);

        public static bool GetAutoWireViewModel(BindableObject bindable)
        {
            return (bool)bindable.GetValue(AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(BindableObject bindable, bool value)
        {
            bindable.SetValue(AutoWireViewModelProperty, value);
        }

        static ViewModelLocator()
        {
            _container = new TinyIoCContainer();

            //ViewModels

            _container.Register<QrCodeViewModel>();
            _container.Register<MasterDetailPageMenuItem>();

            //Services -- singletons

            _container.Register<INavigationService, NavigationService>();
        }

        public static T Resolve<T>() where T : class
        {
            return _container.Resolve<T>();
        }

        //Bindable is view where AutoWireViewModel is invoked
        private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is Element view))
                return;

            Type viewType = view.GetType();
            string viewName = viewType.FullName.Replace(".Views", ".ViewModels");
            string viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            string viewModelName = $"{viewName}Model, {viewAssemblyName}";

            Type viewModelType = Type.GetType(viewModelName);
            if (viewModelType == null)
                return;

            var viewModel = _container.Resolve(viewModelType);
            view.BindingContext = viewModel;
        }
    }
}
