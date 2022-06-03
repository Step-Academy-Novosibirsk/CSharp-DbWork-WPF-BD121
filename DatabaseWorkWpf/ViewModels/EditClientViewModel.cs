using DatabaseWorkWpf.Commands;
using DatabaseWorkWpf.EventArgs;
using DatabaseWorkWpf.Models;
using DatabaseWorkWpf.ViewModels.Base;

namespace DatabaseWorkWpf.ViewModels;

public class EditClientViewModel : AbstractViewModel
{
    public Client? Client { get; set; }

    public EditClientViewModel()
    {
        Client = new Client();
    }
    public bool HasSaved { get; set; }

    #region Commands

    public ActionCommand SaveCommand => new(Save);
    public ActionCommand CloseCommand => new(Close);

    #endregion

    #region Constructors

    public EditClientViewModel(Client? client=null)
    {
        Client = client;
    }

    #endregion

    #region Private Methods

    private void Save()
    {
        HasSaved = true;
        Close();
    }

    private void Close() => Closed?.Invoke(this, new CloseEventArgs());
    #endregion

    #region Events

    public event CloseEventHandeler? Closed;

    #endregion
}