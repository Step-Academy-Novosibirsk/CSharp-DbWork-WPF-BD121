using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DatabaseWorkWpf.Commands;
using DatabaseWorkWpf.Models;
using DatabaseWorkWpf.Utils;
using DatabaseWorkWpf.ViewModels.Base;
using DatabaseWorkWpf.Views;

namespace DatabaseWorkWpf.ViewModels;

public class ClientsListViewModel : AbstractViewModel
{
    private readonly ApplicationContext _context;

    #region Public properties
    public ObservableCollection<Client> Clients { get; set; }
    public  Client? SelectedClient { get; set; }

    #endregion
    
    #region Constructors
    public ClientsListViewModel()
    {
        _context = new ApplicationContext();
        Clients = new ObservableCollection<Client>(_context.Clients?.ToList() ?? new List<Client>());
    }
    
    #endregion

    #region Commands

    public ActionCommand AddCommand => new(AddUser);
    public ActionCommand EditCommand => new(EditUser);
    public ActionCommand RemoveCommand => new(RemoveUser);

    #endregion

    #region Private methods
    private void RemoveUser()
    {
        if (SelectedClient == null)
            return;
        _context.Clients?.Remove(SelectedClient);
        _context.SaveChanges();
        Clients.Remove(SelectedClient);
        OnPropertyChanged(nameof(Clients));
    }
    private void EditUser()
    {
        if (SelectedClient == null)
            return;
        var viewmodel = new EditClientViewModel(SelectedClient.Clone() as Client);
        var editClient = new EditClientView(viewmodel);
         
        editClient.ShowDialog();
        if (!(editClient.DataContext as EditClientViewModel)!.HasSaved) return;
        var client = (editClient.DataContext as EditClientViewModel)?.Client;
        SelectedClient.Address = client?.Address;
        SelectedClient.Email = client?.Email;
        SelectedClient.Phone = client?.Phone;
        SelectedClient.Name = client?.Name;
        _context.Clients?.Update(SelectedClient);
        _context.SaveChanges();
        Clients = new ObservableCollection<Client>(_context.Clients?.ToList() ?? new List<Client>());
        OnPropertyChanged(nameof(Clients));
    }
    private void AddUser()
    {
        var viewmodel = new EditClientViewModel();
        var editClient = new EditClientView(viewmodel);
        editClient.ShowDialog();
        if (!(editClient.DataContext as EditClientViewModel)!.HasSaved) return;
        if (editClient.DataContext == null) return;
        var client = (editClient.DataContext as EditClientViewModel)?.Client;
        if (client != null)
            _context.Clients?.Add(client);
        _context.SaveChanges();
        Clients = new ObservableCollection<Client>(_context.Clients?.ToList() ?? new List<Client>());
        OnPropertyChanged(nameof(Clients));
    }
    #endregion
    
}