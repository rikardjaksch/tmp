using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System.Windows;
using wpf_windsor.ViewModels;
using wpf_windsor.Views;
using wpf_windsor.Windsor;

namespace wpf_windsor
{
    public partial class App : Application
    {
        private static readonly WindsorContainer container = new WindsorContainer();

        public App()
        {
            ConfigureContainer();
        }

        private void ConfigureContainer()
        {
            container.AddFacility<ViewRegistrationFacility>();

            container.Register(Component.For<IWindsorContainer>().Instance(container));
            container.Register(Component.For<IViewFactory>().ImplementedBy<WindsorViewFactory>());

            // Register all implementations that are based from IView as as their main interface
            container.Register(Classes.FromThisAssembly()
                .BasedOn<IView>()
                .WithService.FromInterface()
                .Configure(c => c.LifeStyle.Is(LifestyleType.Transient)));

            // Register all view model implementations that are based on IViewModel
            container.Register(Classes.FromThisAssembly()
                .BasedOn<IViewModel>()
                .Configure(c => c.LifeStyle.Is(LifestyleType.Transient)));
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var viewFactory = container.Resolve<IViewFactory>();
            var mainView = viewFactory.CreateView<IMainView>();
            mainView.ShowDialog();
        }
    }
}
