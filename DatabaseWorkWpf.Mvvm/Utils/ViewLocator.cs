using System.Reflection;

namespace DatabaseWorkWpf.Mvvm.Utils;

public static class ViewLocator
{
    public static Type? LocateView(Type viewModel, Assembly mainAssembly)
    {
        var viewTypeName = viewModel.FullName?.Replace("ViewModel", "View");
        if (viewTypeName == null)
            return null;
        var viewType = mainAssembly.GetType(viewTypeName);
        return viewType;
    }
}