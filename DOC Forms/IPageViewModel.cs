using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DOC_Forms
{
    [Serializable]
    public abstract class IPageViewModel : ObservableObject
    {
        private bool _pageComplete;

        public bool PageComplete
        {
            get { return _pageComplete; }
            internal set
            {
                _pageComplete = value;
                RaisePropertyChangedEvent();
            }
        }

        protected IPageViewModel()
        {
            PageComplete = false;
        }

        /// <summary>
        /// Used to save a form as a file. May be used to save partial forms
        /// </summary>
        /// <returns>true on a successful save. Any errors will cause it to return false</returns>
        public virtual bool Save(Stream stream, BinaryFormatter formatter)
        {
            try
            {
                formatter.Serialize(stream,this);
            }
            catch (Exception e )
            {
                Console.WriteLine(e);
                return false;
            }
            return true;
        }
    }
}
