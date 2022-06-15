using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DatabaseWorkWpf.Models;
using DatabaseWorkWpf.Mvvm.Base;
using DatabaseWorkWpf.Utils;
using DatabaseWorkWpf.ViewModels.Base;

namespace DatabaseWorkWpf.ViewModels;

public class ManagersListViewModel : AbstractModelsListViewModel<Manager>
{
    public ManagersListViewModel(IWindowManager windowManager, ApplicationContext context) : base(windowManager, context, new ObservableCollection<Manager>(context.Managers?.ToList() ?? new List<Manager>()),new EditManagerViewModel(windowManager))
    {
    }

    protected override void UpdateCollection()
    {
        Models = new ObservableCollection<Manager>(Context.Managers?.ToList() ?? new List<Manager>());
        OnPropertyChanged(nameof(Models));
    }
        

}