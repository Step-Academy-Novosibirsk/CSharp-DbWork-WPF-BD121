using System.Collections.Generic;
using System.Linq;
using DatabaseWorkWpf.Models;
using DatabaseWorkWpf.Mvvm.Base;
using DatabaseWorkWpf.Utils;
using DatabaseWorkWpf.ViewModels.Base;

namespace DatabaseWorkWpf.ViewModels;

public class EditSaleViewModel : AbstractModelEditorViewModel<Sale>
{
    public List<Client>? Clients { get;  }
    public List<Manager>? Managers { get;  }
    public EditSaleViewModel(IWindowManager windowManager, ApplicationContext context) : base(windowManager)
    {
        Clients = context.Clients?.ToList();
        Managers = context.Managers?.ToList();
        Model = new Sale();
    }
}