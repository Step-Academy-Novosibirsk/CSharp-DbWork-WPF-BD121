using System;
using System.Windows;
using DatabaseWorkWpf.Mvvm.Base;
using DatabaseWorkWpf.Mvvm.Utils;

namespace DatabaseWorkWpf.Mvvm.Windows.Utils;

public class WindowManager : IWindowManager
{
    private Window? _currentWindow;

    public WindowManager()
    {
        _currentWindow = Application.Current.MainWindow;
    }
    public void ShowDialog<T>(T viewModel)
    {
        if (viewModel == null)
            return;
        var mainAssembly = Application.Current?.MainWindow?.GetType().Assembly;
        if (mainAssembly == null) return;
        var viewType = ViewLocator.LocateView(viewModel.GetType(), mainAssembly);
        var view = viewType?.GetConstructor(Type.EmptyTypes)?.Invoke(Array.Empty<object>());
        if (view is not Window window) return;
        _currentWindow = window;
        window.DataContext = viewModel;
        window.ShowDialog();
    }

    public void Close()
    {
        _currentWindow?.Close();
    }
}