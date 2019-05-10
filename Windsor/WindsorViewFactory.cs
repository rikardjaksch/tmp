using Castle.Windsor;
using wpf_windsor.Views;

namespace wpf_windsor.Windsor
{
    public class WindsorViewFactory : IViewFactory
    {
        private readonly IWindsorContainer container;

        public WindsorViewFactory(IWindsorContainer container)
        {
            this.container = container;
        }

        public T CreateView<T>() where T : IView
        {
            return container.Resolve<T>();
        }
    }
}
