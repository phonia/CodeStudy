using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Observer
{
    /// <summary>
    /// 
    /// </summary>
    public class BankAcountOne
    {
        private List<IObserverOne> _observerOneList = null;

        public void Add(IObserverOne observer)
        {
            if (_observerOneList == null) _observerOneList = new List<IObserverOne>();
            if (observer == null) return;
            _observerOneList.Add(observer);
        }

        public void Remove(IObserverOne observer)
        {
            if (_observerOneList == null || _observerOneList.Count <= 0||observer==null) return;
            if (_observerOneList.Contains(observer)) _observerOneList.Remove(observer);
        }

        public void Withdraw(int money)
        {
            if (_observerOneList == null || _observerOneList.Count <= 0) return;
            foreach (IObserverOne item in _observerOneList)
            {
                item.Update(this);
            }
        }
    }

    public interface IObserverOne
    {
        void Update(BankAcountOne bankAcount);
    }

    public class IObserverOT : IObserverOne
    {
        public void Update(BankAcountOne bankAcount)
        {
            Console.Write("IObserverOT");
        }
    }

    public class IObserverOO : IObserverOne
    {
        public void Update(BankAcountOne bankAcount)
        {
            Console.Write("IObserverOO");
        }
    }
}
