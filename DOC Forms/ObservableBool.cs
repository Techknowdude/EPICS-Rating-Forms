﻿using System;
using System.ComponentModel;

namespace DOC_Forms
{
    [Serializable]
    class ObservableBool : ObservableObject
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
    }
}
