// Ignore Spelling: App

using Prism;
using Prism.Ioc;
using SourceCodeStudio.Mobile.Bootstrap;

namespace SourceCodeStudio.Mobile
{
    public partial class App
    {

        public App() : this(null)
        {
        }
        public App(IPlatformInitializer initializer) : base(initializer) { }


        protected override void OnStart()
        {
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDependencies();
            this.SetUpApp();
        }

        protected override void OnInitialized()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}
