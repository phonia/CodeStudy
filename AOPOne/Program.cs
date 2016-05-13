using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOPOne
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer()
            .AddNewExtension<Interception>()
            .RegisterType<IApplicationService, ApplicationService>();
            container.Configure<Interception>()
                .SetInterceptorFor<IApplicationService>(new InterfaceInterceptor());
            IApplicationService app = container.Resolve<IApplicationService>();
            app.Do();
            
        }
    }


    public interface IApplicationService
    {
        [ILog]
        void Do();
    }

    public class ApplicationService : IApplicationService
    {
        public void Do()
        {
            Console.Write("do!/n");
        }
    }

    public class ILogAttribute : HandlerAttribute
    {

        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return (ICallHandler)container.Resolve<ILogInterceptor>();
        }

        public void Do()
        {
            Console.Write("Log!/n");
        }
    }

    public class ILogInterceptor : ICallHandler
    {
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            String className = input.MethodBase.DeclaringType.Name;
            var attrs = input.MethodBase.GetCustomAttributes(false);
            if (attrs != null)
            {
                foreach (var node in attrs)
                {
                    if (node is ILogAttribute)
                    {
                        (node as ILogAttribute).Do();
                    }
                }
            }
            return getNext()(input, getNext);
        }

        public int Order { get; set; }
    }
}
