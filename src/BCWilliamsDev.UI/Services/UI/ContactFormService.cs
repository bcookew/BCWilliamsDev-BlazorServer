namespace BCWilliamsDev.UI.Services.UI
{
    public class ContactFormService
    {
        private bool _formIsOpen = false;
        public bool FormIsOpen
        {
            get => _formIsOpen;
            set
            {
                _formIsOpen = value;
                OnChange();
            }
        }
        public event EventHandler? OnFormIsOpenChanged;

        private void OnChange()
        {
            EventHandler? changeEvent = OnFormIsOpenChanged;

            if (changeEvent != null)
            {
                changeEvent(this, EventArgs.Empty);
            }
        }

    }
}
