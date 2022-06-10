using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DatabaseWorkWpf.Models;
using DatabaseWorkWpf.Mvvm.Base;
using DatabaseWorkWpf.Utils;
using DatabaseWorkWpf.ViewModels.Base;

namespace DatabaseWorkWpf.ViewModels;

public class ClientsListViewModel : AbstractModelsListViewModel<Client>
{
    #region Constructors
    public ClientsListViewModel(IWindowManager windowManager, ApplicationContext context) : base(windowManager, context, new ObservableCollection<Client>(context.Clients?.ToList() ?? new List<Client>()), new EditClientViewModel(windowManager))
    {
        
    }
    
    #endregion

    #region AbstractModelsList overrides
    protected override void UpdateCollection()
    {
        Models = new ObservableCollection<Client>(Context.Clients?.ToList() ?? new List<Client>());
        OnPropertyChanged(nameof(Models));
    }
    
    #endregion


}