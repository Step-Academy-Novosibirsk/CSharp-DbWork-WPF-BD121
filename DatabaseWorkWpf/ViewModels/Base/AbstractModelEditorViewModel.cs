using DatabaseWorkWpf.Mvvm.Base;
using DatabaseWorkWpf.Mvvm.Commands;

namespace DatabaseWorkWpf.ViewModels.Base;

public abstract class AbstractModelEditorViewModel<T> : AbstractViewModel
{
    #region Public properties

    public T? Model { get; set; }
    public bool HasSaved { get; set; }

    #endregion

    #region Private fields

    private readonly IWindowManager _windowManager;

    #endregion

    #region Constructors
    protected AbstractModelEditorViewModel(IWindowManager windowManager)
    {
        _windowManager = windowManager;
    }

    #endregion
    

    #region Private Methods

    private void Save()
    {
        HasSaved = true;
        Close();
    }

    private void Close() => _windowManager.Close();

    #endregion
    #region Commands

    public ActionCommand SaveCommand => new(Save);
    public ActionCommand CloseCommand => new(Close);

    #endregion

    
}