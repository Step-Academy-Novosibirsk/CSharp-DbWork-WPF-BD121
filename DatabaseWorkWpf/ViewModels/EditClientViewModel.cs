using DatabaseWorkWpf.Models;
using DatabaseWorkWpf.Mvvm.Base;
using DatabaseWorkWpf.ViewModels.Base;

namespace DatabaseWorkWpf.ViewModels;

public class EditClientViewModel : AbstractModelEditorViewModel<Client>
{
    public EditClientViewModel(IWindowManager windowManager) : base(windowManager)
    {
        Model = new Client();
    }
}