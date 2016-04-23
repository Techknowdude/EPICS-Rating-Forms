using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Microsoft.Office.Interop.Excel;
using Page = System.Windows.Controls.Page;

namespace DOC_Forms
{
    public class EpicsRatingFormLogic : IEpicForm
    {
        private List<IPageLogic> _pages;
        private EpicsRatingFormA _controlWindow;

        public List<IPageLogic> Pages
        {
            get { return _pages; }
            set { _pages = value; }
        }

        /// <summary>
        /// Factory
        /// </summary>
        /// <param name="pages"></param>
        /// <param name="epicsRatingFormA"></param>
        /// <returns></returns>
        public static EpicsRatingFormLogic Create(List<IPageInterface> pages, EpicsRatingFormA epicsRatingFormA)
        {
            return new EpicsRatingFormLogic(pages,epicsRatingFormA);
        }

        /// <summary>
        /// Private ctor for factory
        /// </summary>
        /// <param name="pages"></param>
        /// <param name="epicsRatingFormA"></param>
        private EpicsRatingFormLogic(List<IPageInterface> pages, EpicsRatingFormA epicsRatingFormA)
        {
            _pages = new List<IPageLogic>();
            _controlWindow = epicsRatingFormA;
            for (int i = 0; i < pages.Count; ++i)
            {
                _pages.Add(pages[i].Logic);
            }
        }

        public void ExportToExcel(Worksheet worksheet)
        {
            int currentRow = 1;
            foreach (var pageLogic in Pages)
            {
                currentRow = pageLogic.ExportToExcel(worksheet, currentRow);
            }
        }
    }
}
