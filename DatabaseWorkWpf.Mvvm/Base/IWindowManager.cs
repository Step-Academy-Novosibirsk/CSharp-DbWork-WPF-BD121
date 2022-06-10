namespace DatabaseWorkWpf.Mvvm.Base;

public interface IWindowManager
{
    void ShowDialog<T>(T viewModel);
    void Close();
}