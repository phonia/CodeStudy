using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityStudy
{
    public class MockContainerExtension : UnityContainerExtension, IMockConfiguration
    {
        private bool initializeWasCalled = false;

        public bool InitializeWasCalled
        {
            get { return initializeWasCalled; }
        }

        public new ExtensionContext Context
        {
            get { return base.Context; }
        }

        protected override void Initialize()
        {
            initializeWasCalled = true;
        }
    }

    public interface IMockConfiguration : IUnityContainerExtensionConfigurator
    {

    }

}
