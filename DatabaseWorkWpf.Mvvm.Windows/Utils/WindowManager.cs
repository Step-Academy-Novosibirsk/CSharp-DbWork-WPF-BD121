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
        var mainAssembly = Application.Current?.MainWindow?.GetType().Assembly;
        if (mainAssembly == null) return;
        var viewType = ViewLocator.LocateView(typeof(T), mainAssembly);
        var view = viewType?.GetConstructor(Type.EmptyTypes)?.Invoke(Array.Empty<object>());
        if (view is not Window window) return;
        _currentWindow = window;
        if(viewModel!=null)
            window.DataContext = viewModel;
        window.ShowDialog();
    }

    public void Close()
    {
        _currentWindow?.Close();
    }
}