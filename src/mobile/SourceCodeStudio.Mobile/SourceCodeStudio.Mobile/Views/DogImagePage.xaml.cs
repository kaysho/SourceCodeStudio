using SourceCodeStudio.Mobile.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SourceCodeStudio.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DogImagePage : ContentPage
    {

        private DogImageViewModel vm;
        public DogImagePage()
        {
            InitializeComponent();
            vm = BindingContext as DogImageViewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.FetchImageCommand.Execute(this);
        }
    }
}