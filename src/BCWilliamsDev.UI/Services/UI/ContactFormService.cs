using BCWilliamsDev.UI.Services.UI.Interfaces;

namespace BCWilliamsDev.UI.Services.UI
{
    public class ContactFormService : IContactFormService
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
