using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Observer
{
    public class BankAcountT
    {
        private List<IObserverT> _observerTList = null;

        public void Add(IObserverT obserser)
        {
            if (_observerTList == null) _observerTList = new List<IObserverT>();
            if (obserser == null) return;
            _observerTList.Add(obserser);
        }

        public void Withdraw(int money)
        {
            if (_observerTList == null || _observerTList.Count <= 0) return;
            foreach (IObserverT item in _observerTList)
            {
                item.Update();
            }
        }
    }

    public interface IObserverT
    {
        void Update();
    }

    public class ObserverTO : IObserverT
    {
        private BankAcountT _bankAcountT = null;
        public ObserverTO(BankAcountT bat)
        {
            _bankAcountT = bat;
        }
        public void Update()
        {
            if (_bankAcountT == null) return;
            Console.Write("ObserverTO");
        }
    }
}
