using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Office.Interop.Excel;

namespace DOC_Forms
{
    public class EpicsRatingFormLogic : IEpicForm
    {
        private List<IPageViewModel> _pages;

        public List<IPageViewModel> Pages
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
            return new EpicsRatingFormLogic(pages);
        }

        /// <summary>
        /// Private ctor for factory
        /// </summary>
        /// <param name="pages"></param>
        /// <param name="epicsRatingFormA"></param>
        private EpicsRatingFormLogic(List<IPageInterface> pages)
        {
            _pages = new List<IPageViewModel>();
            for (int i = 0; i < pages.Count; ++i)
            {
                _pages.Add(pages[i].ViewModel);
            }
        }

        //public void ExportToExcel(Worksheet worksheet)
        //{
        //    int currentRow = 1;
        //    foreach (var pageLogic in Pages)
        //    {
        //        currentRow = pageLogic.ExportToExcel(worksheet, currentRow);
        //    }
        //}

        public IEnumerable GetPages()
        {
            return Pages;
        }

        public bool IsCompleted()
        {
            return Pages.All(page => page.PageComplete);
        }
    }
}
