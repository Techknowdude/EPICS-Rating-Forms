namespace DOC_Forms
{
    public interface IPageInterface
    {
        /// <summary>
        /// The logic underlying the page. This is the controller and model for this view.
        /// </summary>
        IPageViewModel ViewModel { get; set; }

        void SetViewModel(IPageViewModel model);
    }
}
