using System;
using System.Collections.ObjectModel;
using DatabaseWorkWpf.Mvvm.Base;
using DatabaseWorkWpf.Mvvm.Commands;
using DatabaseWorkWpf.Utils;

namespace DatabaseWorkWpf.ViewModels.Base;

public abstract class AbstractModelsListViewModel<T> : AbstractViewModel where T : ICloneable
{
    #region Protected fields
    protected readonly ApplicationContext Context;
    
    #endregion
    #region Private fields

    private readonly IWindowManager _windowManager;
    private readonly AbstractModelEditorViewModel<T> _editorViewModel;

    #endregion
   

    #region Public properties
    public ObservableCollection<T> Models { get; set; }
    public  T? SelectedModel { get; set; }

    #endregion
    
    #region Constructors
    protected AbstractModelsListViewModel(IWindowManager windowManager, ApplicationContext context, ObservableCollection<T> models, AbstractModelEditorViewModel<T> editorViewModel)
    {
        Context = context;
        Models = models;
        _windowManager = windowManager;
        _editorViewModel = editorViewModel;
    }

    #endregion

    #region Private methods

    private void Remove()
    {
        if (SelectedModel == null)
            return;
        Context.Remove(SelectedModel);
        Context.SaveChanges();
        Models.Remove(SelectedModel);
        OnPropertyChanged(nameof(Models));
    }
    private void Add()
    {
        _windowManager.ShowDialog(_editorViewModel);
        if (!_editorViewModel.HasSaved) return;
        var model = _editorViewModel.Model;
        if (model != null)
            Context.Add(model);
        Context.SaveChanges();
        UpdateCollection();
    }
    private void EditUser()
    {
        if(SelectedModel ==null)
            return;
        _editorViewModel.Model = (T)SelectedModel.Clone();
        _windowManager.ShowDialog(_editorViewModel);
        var model = _editorViewModel.Model;
        CopyModel(model);
        Context.Update(SelectedModel);
        Context.SaveChanges();
        UpdateCollection();

    }

    private void CopyModel(T model)
    {
        foreach (var property in typeof(T).GetProperties())
            property.SetValue(SelectedModel, property.GetValue(model));
    }
    
    #endregion

    #region Protected methods

    protected abstract void UpdateCollection();

    #endregion

    #region Commands

    public ActionCommand RemoveCommand => new(Remove);
    public ActionCommand EditCommand => new(EditUser);
    public ActionCommand AddCommand => new(Add);

    #endregion

    
}