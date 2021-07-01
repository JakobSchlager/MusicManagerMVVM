using System;
using System.Windows.Input;

namespace MVVM.Tools
{
  public class RelayCommand<T> : ICommand
  {
    private readonly Action<T> _execute;
    private readonly Predicate<T> _canExecute;

    public RelayCommand(Action<T> execute) : this(execute, null) { }

    public RelayCommand(Action<T> execute, Predicate<T> canExecute)
    {
      _execute = execute ?? throw new ArgumentNullException(nameof(execute));
      _canExecute = canExecute;
    }

    public void Execute(object parameter) => _execute((T)parameter);
    public bool CanExecute(object parameter) => _canExecute == null || _canExecute((T)parameter);

    public event EventHandler CanExecuteChanged
    {
      add => CommandManager.RequerySuggested += value;
      remove => CommandManager.RequerySuggested -= value;
    }

  }
}
