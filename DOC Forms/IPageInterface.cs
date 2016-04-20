using System.IO;
using Microsoft.Office.Interop.Excel;

namespace DOC_Forms
{
    public interface IPageInterface
    {
        /// <summary>
        /// Used to verify if the page has been completely filled by the user
        /// </summary>
        /// <returns></returns>
        bool IsCompleted();


        /// <summary>
        /// The logic underlying the page. This is the controller and model for this view.
        /// </summary>
        IPageLogic Logic { get; set; }
    }
}
