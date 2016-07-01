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
                var one=unityContainer.Resolve<IInjectConstructInterface>();
                Assert.IsTrue((one as ObjectInheritFromConstructorInterface).UserName.Equals("hy"));
                unityContainer.RegisterType<ObjectInheritFromConstructorInterface>(
                    "Instance", new InjectionConstructor("hy", "polan")
                    );
                Assert.IsTrue(((ObjectInheritFromConstructorInterface)unityContainer.Resolve<ObjectInheritFromConstructorInterface>("Instance")).UserName.Equals("hy"));
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
                Assert.IsTrue(obj.UserName.Equals("polan"));
            }
        }
        
        
        [TestMethod]
        public void CanConfigureContainerToInjectSpecificValuesIntoAnArray()
        {
            ILogger logger2 = new SpecialLogger();

            IUnityContainer container = new UnityContainer()
                .RegisterType<TypeWithArrayConstructorParameter>(
                new InjectionConstructor(
                    new ResolvedArrayParameter<ILogger>(
                        new ResolvedParameter<ILogger>("log1"),
                        typeof (ILogger),
                        logger2)))
                .RegisterType<ILogger, SpecialLogger>()
                .RegisterType<ILogger, SpecialLogger>("log1");

            TypeWithArrayConstructorParameter result = container.Resolve<TypeWithArrayConstructorParameter>();

            Assert.AreEqual(3, result.loggers.Length);
            Assert.IsInstanceOfType(result.loggers[0], typeof (SpecialLogger));
            Assert.IsInstanceOfType(result.loggers[1], typeof (SpecialLogger));
            Assert.AreSame(logger2, result.loggers[2]);
        }

        [TestMethod]
        public void ContainerAutomaticallyResolvesAllWhenInjectingArrays()
        {
            ILogger[] expected = new ILogger[] { new SpecialLogger(), new SpecialLogger() };
            IUnityContainer container = new UnityContainer()
                .RegisterInstance("one", expected[0])
                .RegisterInstance("two", expected[1]);

            TypeWithArrayConstructorParameter result = container.Resolve<TypeWithArrayConstructorParameter>();

            CollectionAssert.AreEqual(expected, result.loggers);
        }

        [TestMethod]
        public void CanConfigureContainerToCallConstructorWithArrayParameterWithNonGenericVersion()
        {
            ILogger o1 = new SpecialLogger();
            ILogger o2 = new SpecialLogger();

            IUnityContainer container = new UnityContainer()
                .RegisterType<TypeWithArrayConstructorParameter>(
                new InjectionConstructor(typeof(ILogger[])))
                .RegisterInstance<ILogger>("o1", o1)
                .RegisterInstance<ILogger>("o2", o2);

            TypeWithArrayConstructorParameter resolved = container.Resolve<TypeWithArrayConstructorParameter>();

            Assert.IsNotNull(resolved.loggers);
            Assert.AreEqual(2, resolved.loggers.Length);
            Assert.AreSame(o1, resolved.loggers[0]);
            Assert.AreSame(o2, resolved.loggers[1]);
        }

        //InjectionParameterr用于注册非Container参数 与 ResolvedParameter相对
        [TestMethod]
        public void CanCallNonGenericConstructorOnOpenGenericType()
        {
            IUnityContainer container = new UnityContainer()
                .RegisterType(typeof(ClassWithOneGenericParameter<>),
                        new InjectionConstructor("Fiddle", new InjectionParameter<object>("someValue")));

            ClassWithOneGenericParameter<User> result = container.Resolve<ClassWithOneGenericParameter<User>>();

            Assert.IsNull(result.InjectedValue);
        }

        //不是很明白 大概是为Interceptor做准备的
        [TestMethod]
        public void CanGetConfigurationInterfaceFromExtension()
        {
            MockContainerExtension extension = new MockContainerExtension();
            IUnityContainer container = new UnityContainer()
                .AddExtension(extension);

            IMockConfiguration config = container.Configure<IMockConfiguration>();

            Assert.AreSame(extension, config);
            Assert.AreSame(container, config.Container);
        }
    }
}
