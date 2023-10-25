// Ignore Spelling: App

using SourceCodeStudio.Mobile.Bootstrap;
using System;

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
            await Current.GoToAsync("//LoginPage");
        }
    }
}
