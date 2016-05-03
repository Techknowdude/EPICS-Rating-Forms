using System;
using System.ComponentModel;

namespace DOC_Forms
{
    [Serializable]
    public class ObservableBool : ObservableObject
    {
        private bool _val;

        public bool Val
        {
            get { return _val; }
            set
            {
                _val = value;
                RaisePropertyChangedEvent("Val");
            }
        }

        public ObservableBool(bool val = false)
        {
            Val = val;
        }

        public ObservableBool(PropertyChangedEventHandler listener, bool val = false) : base(listener)
        {
            Val = val;
        }

        public static implicit operator bool(ObservableBool observableBool) 
        {
            return observableBool.Val;
        }

        public void AddListener(PropertyChangedEventHandler listener)
        {
            base.PropertyChanged += listener;
        }
        public void RemoveListener(PropertyChangedEventHandler listener)
        {
            base.PropertyChanged -= listener;
        }
    }
}
