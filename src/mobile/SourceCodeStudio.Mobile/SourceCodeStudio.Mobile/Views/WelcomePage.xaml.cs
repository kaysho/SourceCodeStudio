using SourceCodeStudio.Mobile.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SourceCodeStudio.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {

        private WelcomeViewModel vm;
        public WelcomePage()
        {
            InitializeComponent();
            vm = BindingContext as WelcomeViewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.LocationCommand.Execute(this);
        }

        protected override void OnDisappearing()
        {
            if (vm.cts != null && !vm.cts.IsCancellationRequested)
                vm.cts.Cancel();
            base.OnDisappearing();
        }
    }
}