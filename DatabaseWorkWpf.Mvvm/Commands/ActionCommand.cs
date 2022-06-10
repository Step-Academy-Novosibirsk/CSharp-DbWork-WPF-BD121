using System;
using System.Windows.Input;

namespace DatabaseWorkWpf.Mvvm.Commands;

public class ActionCommand : ICommand
{
    public bool CanExecute(object? parameter) => true;
    private readonly Action _executeAction;

    public ActionCommand(Action executeAction)
    {
        _executeAction = executeAction;
    }


    public void Execute(object? parameter) => _executeAction.Invoke();


    public event EventHandler? CanExecuteChanged;
}