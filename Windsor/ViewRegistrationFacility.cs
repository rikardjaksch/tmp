using Castle.MicroKernel;
using Castle.MicroKernel.Facilities;
using wpf_windsor.Views;

namespace wpf_windsor.Windsor
{
    public class ViewRegistrationFacility : AbstractFacility
    {
        protected override void Init()
        {
            Kernel.ComponentModelCreated += Kernel_ComponentModelCreated;
        }

        private void Kernel_ComponentModelCreated(Castle.Core.ComponentModel model)
        {
            var isView = typeof(IView).IsAssignableFrom(model.Implementation);
            if (!isView) return;

            if (model.CustomComponentActivator == null)
                model.CustomComponentActivator = typeof(ViewComponentActivator);
        }
    }
}
