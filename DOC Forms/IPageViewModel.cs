using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Office.Interop.Excel;

namespace DOC_Forms
{
    [Serializable]
    public abstract class IPageViewModel : ObservableObject
    {
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
