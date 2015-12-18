using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatePattern
{
    /*
     * 状态模式——允许一个对象在其内部状态改变时自动改变其行为，对象看起来就像是改变了它的类。
     * http://www.cnblogs.com/zhili/p/StatePattern.html
     * 在以下情况下可以考虑使用状态者模式。
     * 当一个对象状态转换的条件表达式过于复杂时可以使用状态者模式。把状态的判断逻辑转移到表示不同状态的一系列类中，可以把复杂的判断逻辑简单化。
     * 当一个对象行为取决于它的状态，并且它需要在运行时刻根据状态改变它的行为时，就可以考虑使用状态者模式。
     * 
     * 
     * 
     *  状态模式与职责链模式的区别：
     *  状态模式是让各个状态对象自己知道其下一个处理的对象是谁，即在编译时便设定好了的；
     *  而职责链模式中的各个对象并不指定其下一个处理的对象到底是谁，只有在客户端才设定。
     *  责任链模式和状态模式的区别在于，前者注重责任的传递，并且责任链由客户端进行配置，后者注重对象状态的转换，这个转换过程对客户端是不可见的
     * **/
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
