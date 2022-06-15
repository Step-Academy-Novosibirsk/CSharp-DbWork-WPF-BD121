using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DatabaseWorkWpf.Models;
using DatabaseWorkWpf.Mvvm.Base;
using DatabaseWorkWpf.Utils;
using DatabaseWorkWpf.ViewModels.Base;

namespace DatabaseWorkWpf.ViewModels;

public class SalesListViewModel : AbstractModelsListViewModel<Sale>
{
    public SalesListViewModel(IWindowManager windowManager, ApplicationContext context) : base(windowManager, context, new ObservableCollection<Sale>(context.Sales?.ToList() ?? new List<Sale>()),new EditSaleViewModel(windowManager, context))
    {
    }

    protected override void UpdateCollection()
    {
        Models = new ObservableCollection<Sale>(Context.Sales?.ToList() ?? new List<Sale>());
        OnPropertyChanged(nameof(Models));
    }
}