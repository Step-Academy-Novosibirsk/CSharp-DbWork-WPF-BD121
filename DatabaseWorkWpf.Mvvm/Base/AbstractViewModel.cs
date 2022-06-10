using System.ComponentModel;
using System.Runtime.CompilerServices;
using DatabaseWorkWpf.Mvvm.Utils;

namespace DatabaseWorkWpf.Mvvm.Base;

public class AbstractViewModel : INotifyPropertyChanged
{
    #region PropertyChanged realization
    public event PropertyChangedEventHandler? PropertyChanged;
    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    #endregion
    
}