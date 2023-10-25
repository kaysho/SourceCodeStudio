// Ignore Spelling: App

using SourceCodeStudio.Mobile.Bootstrap;
using System;
using Xamarin.Forms;

namespace SourceCodeStudio.Mobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            InitializeRoutes();
        }
        private void InitializeRoutes()
        {
            AppContainer.RegisterPages();
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
