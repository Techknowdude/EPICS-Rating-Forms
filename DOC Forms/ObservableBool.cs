using System;

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
    }
}
