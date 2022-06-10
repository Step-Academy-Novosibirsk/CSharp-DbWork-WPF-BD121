using DatabaseWorkWpf.Models;
using DatabaseWorkWpf.Mvvm.Base;
using DatabaseWorkWpf.ViewModels.Base;

namespace DatabaseWorkWpf.ViewModels;

public class EditManagerViewModel : AbstractModelEditorViewModel<Manager>
{
    public EditManagerViewModel(IWindowManager windowManager) : base(windowManager)
    {
        Model = new Manager();
    }
}