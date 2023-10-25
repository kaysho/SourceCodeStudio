using SourceCodeStudio.Mobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace SourceCodeStudio.Mobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}