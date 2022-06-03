using DatabaseWorkWpf.Commands;
using DatabaseWorkWpf.ViewModels.Base;
using DatabaseWorkWpf.Views;

namespace DatabaseWorkWpf.ViewModels;

public class MainWindowViewModel : AbstractViewModel
{
    #region Commands

    public ActionCommand OpenClientsCommand => new(OpenClients);
    
    #endregion

    #region Private Methods

    private void OpenClients()
    {
        var clientsListView = new ClientsListView();
        clientsListView.ShowDialog();
    }
    

    #endregion
    
}