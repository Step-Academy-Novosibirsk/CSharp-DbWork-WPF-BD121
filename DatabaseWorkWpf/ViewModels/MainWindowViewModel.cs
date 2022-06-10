using DatabaseWorkWpf.Mvvm.Commands;
using DatabaseWorkWpf.Mvvm.Base;
using DatabaseWorkWpf.Mvvm.Windows.Utils;
using DatabaseWorkWpf.Utils;

namespace DatabaseWorkWpf.ViewModels;

public class MainWindowViewModel : AbstractViewModel
{
    #region Commands

    public ActionCommand OpenClientsCommand => new(OpenClients);
    public ActionCommand OpenManagersCommand => new ActionCommand(OpenManagers);
    
    #endregion

    #region Private fields

    private readonly IWindowManager _windowManager;
    private readonly ClientsListViewModel _clientsListViewModel;
    private readonly ApplicationContext _context;
    private readonly ManagersListViewModel _managersListViewModel;

    #endregion

    #region Constructors

    public MainWindowViewModel()
    {
        _windowManager = new WindowManager();
        _context = new ApplicationContext();
        _clientsListViewModel = new ClientsListViewModel(_windowManager,_context);
        _managersListViewModel = new ManagersListViewModel(_windowManager, _context);

    }

    #endregion

    #region Private Methods

    private void OpenClients() => _windowManager.ShowDialog(_clientsListViewModel);
    private void OpenManagers() => _windowManager.ShowDialog(_managersListViewModel);


    #endregion

}