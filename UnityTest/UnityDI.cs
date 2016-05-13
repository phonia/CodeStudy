using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.Unity;
using UnityStudy;

namespace UnityTest
{
    /// <summary>
    /// UnityDI 的摘要说明
    /// </summary>
    [TestClass]
    public class UnityDI
    {
        public UnityDI()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，该上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        //
        // 编写测试时，可以使用以下附加特性:
        //
        // 在运行类中的第一个测试之前使用 ClassInitialize 运行代码
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在运行每个测试之前，使用 TestInitialize 来运行代码
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // 在每个测试运行完之后，使用 TestCleanup 来运行代码
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void RegisteringInterfaceMappingToConcreteType()
        {
            using (IUnityContainer unityContainer = new UnityContainer())
            {
                unityContainer.RegisterType<IService, ObjectInheritFromIService>();
                unityContainer.RegisterType<IService, ObjectInheritFromIService>("Service");

                Assert.IsNotNull(unityContainer.Resolve<IService>());
                Assert.IsNotNull(unityContainer.Resolve<IService>("Service"));
            }
        }

        [TestMethod]
        public void RegisteringClassMappingToInheritType()
        {
            using (IUnityContainer unityContainer = new UnityContainer())
            {
                unityContainer.RegisterType<ObjectInheritFromIService, ObjectInheritInheritFormService>();
                Assert.IsNotNull(unityContainer.Resolve<ObjectInheritFromIService>());
            }
        }

        [TestMethod]
        public void RegisteringNamedType()
        {
            using (IUnityContainer unityContainer = new UnityContainer())
            {
                unityContainer.RegisterType(typeof(ObjectInheritFromIService), "Service");
                Assert.IsNotNull(unityContainer.Resolve<ObjectInheritFromIService>("Service"));
            }
        }

        [TestMethod]
        public void RegisteringInstanceOfInterfaceOrType()
        {
            using (var unityContainer = new UnityContainer())
            {
                ObjectInheritFromIService one = new ObjectInheritFromIService();
                ObjectInheritFromIService two = new ObjectInheritFromIService();
                unityContainer.RegisterInstance<IService>("One",one);
                unityContainer.RegisterInstance<ObjectInheritFromIService>("Two", two);
                Assert.IsNotNull(unityContainer.Resolve<IService>("One"));
                Assert.IsNotNull(unityContainer.Resolve<ObjectInheritFromIService>("Two"));
            }
        }

        [TestMethod]
        public void RegisteringInjectConstructor()
        {
            using (var unityContainer = new UnityContainer())
            {
                unityContainer.RegisterType<IInjectConstructInterface, ObjectInheritFromConstructorInterface>(
                        new InjectionConstructor("hy","polan")
                    );
                Assert.IsTrue(((ObjectInheritFromConstructorInterface)unityContainer.Resolve<IInjectConstructInterface>()).UserName.Equals("hy"));
                unityContainer.RegisterType<ObjectInheritFromConstructorInterface>(
                    "Instance", new InjectionConstructor("hy", "polan")
                    );
                Assert.IsTrue(((ObjectInheritFromConstructorInterface)unityContainer.Resolve<ObjectInheritFromConstructorInterface>("Instacne")).UserName.Equals("hy"));
            }
        }

        [TestMethod]
        public void RegisteringInjectProperty()
        {
            using (var unityContainer = new UnityContainer())
            {
                unityContainer.RegisterType<ObjectInheritFromInjectPropertyInterface>(
                    new InjectionProperty("UserName","hy")
                    );
                Assert.IsTrue(unityContainer.Resolve<ObjectInheritFromInjectPropertyInterface>().UserName.Equals("hy"));
            }
        }

        [TestMethod]
        public void RegisteringInejctionMethod()
        {
            using (var unityContainer = new UnityContainer())
            {
                unityContainer.RegisterType<ObjectWithInjectionMehtod>(
                    new InjectionMethod("SetName","hy")
                    );
                var obj = unityContainer.Resolve<ObjectWithInjectionMehtod>();
                Assert.IsTrue(unityContainer.Resolve<ObjectWithInjectionMehtod>().UserName.Equals("hy"));
                obj.SetName("polan");
                Assert.IsTrue(unityContainer.Resolve<ObjectWithInjectionMehtod>().UserName.Equals("polan"));
            }
        }
    }
}
