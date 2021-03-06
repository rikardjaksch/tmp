﻿using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.ComponentActivator;
using Castle.MicroKernel.Context;
using System.Linq;
using System.Windows;
using wpf_windsor.ViewModels;

namespace wpf_windsor.Windsor
{
    public class ViewComponentActivator : DefaultComponentActivator
    {
        public ViewComponentActivator(ComponentModel model, IKernelInternal kernel, ComponentInstanceDelegate onCreation, ComponentInstanceDelegate onDestruction) 
            : base(model, kernel, onCreation, onDestruction)
        {
        }

        protected override object CreateInstance(CreationContext context, ConstructorCandidate constructor, object[] arguments)
        {
            var component = base.CreateInstance(context, constructor, arguments);
            AssignViewModel(component, arguments);
            return component;
        }

        private void AssignViewModel(object component, object[] arguments)
        {
            var frameworkElement = component as FrameworkElement;
            if (frameworkElement == null || arguments == null)
            {
                return;
            }

            var vm = arguments.Where(a => a is IViewModel).FirstOrDefault();
            if (vm != null)
            {
                frameworkElement.DataContext = vm;
            }
        }
    }
}
