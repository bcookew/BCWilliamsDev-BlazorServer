namespace BCWilliamsDev.UI.Services.UI.Interfaces
{
    public interface IContactFormService
    {
        bool FormIsOpen { get; set; }
        event EventHandler? OnFormIsOpenChanged;
    }
}
