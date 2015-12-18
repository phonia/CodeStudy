using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Decorator
{
    /// <summary>
    /// Component
    /// </summary>
    public interface ILog
    {
        void Write();
    }

    /// <summary>
    /// Concrete Component
    /// </summary>
    public class DBLog : ILog
    {
        public void Write()
        {
            Console.Write(" DBLog: ");
        }
    }

    /// <summary>
    /// Decorator
    /// </summary>
    public abstract class LogWrapper : ILog
    {
        private ILog _log = null;

        public LogWrapper(ILog log)
        {
            this._log = log;
        }

        public virtual void Write()
        {
            this._log.Write();
        }
    }

    /// <summary>
    /// Concrete Decorator
    /// </summary>
    public class PriorityLogWrapper : LogWrapper
    {
        public PriorityLogWrapper(ILog log)
            : base(log)
        { }

        public override void Write()
        {
            SetPriority();
            base.Write();
        }

        void SetPriority()
        {
            Console.Write("SetPriority");
        }
    }
}
