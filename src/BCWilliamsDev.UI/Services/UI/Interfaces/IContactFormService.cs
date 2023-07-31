namespace BCWilliamsDev.UI.Services.UI.Interfaces
{
    public interface IContactFormService
    {
        bool FormIsOpen();
        event EventHandler? OnFormIsOpenChanged;
    }
}
