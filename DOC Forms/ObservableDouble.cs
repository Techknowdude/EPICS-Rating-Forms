using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOC_Forms
{
    public class ObservableDouble : ObservableObject
    {
        private double _val;

        public double Val
        {
            get { return _val; }
            set
            {
                _val = value;
                RaisePropertyChangedEvent("Val");
            }
        }

        public ObservableDouble(double val = 0)
        {
            Val = val;
        }

        public ObservableDouble(PropertyChangedEventHandler listener, double val = 0) : base(listener)
        {
            Val = val;
        }

        public static implicit operator double (ObservableDouble observableDouble)
        {
            return observableDouble.Val;
        }
    }
}
