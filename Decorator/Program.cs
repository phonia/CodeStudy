using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Decorator
{
    /*
     * 装饰者模式：
     * 意图：动态的给类型添加额外的职责
     * 设计原则：1、多用组合，少用继承；2、对扩展开放，对修改封闭
     * 要点：1、装饰者与被装饰者继承同一个超类或接口；2、可以用一个或多个装饰者包装一个对象；3、装饰者可以在对象的行为之前或之后添加额外的行为；
     *      4、对象可以在任何时候被装饰，所以是动态的；5、装饰者模式中使用继承(接口)的关键是想达到装饰者和被装饰者类型匹配，而不是获得其行为；
     * 效果以及实现原则：1、Component类在Decorator模式中充当抽象接口的角色，不应该去实现具体的行为。
     *                      而且Decorator类对于Component类应该透明，换言之Component类无需知道Decorator类，Decorator类是从外部来扩展Component类的功能；
     *                  2、Decorator类在接口上表现为is-a Component的继承关系，即Decorator类继承了Component类所具有的接口；
     *                      但在实现上又表现为has-a Component的组合关系，即Decorator类又使用了另外一个Component类；
     *                      我们可以使用一个或者多个Decorator对象来“装饰”一个Component对象，且装饰后的对象仍然是一个Component对象。
     *                  3、Decortor模式并非解决“多子类衍生的多继承”问题，Decorator模式的应用要点在于解决“主体类在多个方向上的扩展功能”——是为“装饰”的含义；
     *                  4、对于Decorator模式在实际中的运用可以很灵活。
     *                      如果只有一个ConcreteComponent类而没有抽象的Component类，那么Decorator类可以是ConcreteComponent的一个子类。
     *                  5、由于使用装饰模式，可以比使用继承关系需要较少数目的类。使用较少的类，当然使设计比较易于进行。
     *                      但是，在另一方面，使用装饰模式会产生比使用继承关系更多的对象。更多的对象会使得查错变得困难，特别是这些对象看上去都很相像。
     * 
     * **/
    class Program
    {
        static void Main(string[] args)
        {

            ILog dblog = new DBLog();
            ILog priorityLog = new PriorityLogWrapper(dblog);
            priorityLog.Write();
            Console.Read();
        }
    }
}
