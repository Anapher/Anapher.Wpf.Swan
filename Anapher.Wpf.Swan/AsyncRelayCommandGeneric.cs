using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Anapher.Wpf.Swan
{
    /// <summary>
    ///     A command whose sole purpose is to relay its functionality to other objects by invoking delegates. The default
    ///     return value for the CanExecute method is 'true' when the command is not executing.
    /// </summary>
    public class AsyncRelayCommand<T> : ICommand
    {
        public delegate Task ExecuteDelegate(T parameter);

        private readonly Func<T, bool> _canExecute;

        private readonly ExecuteDelegate _execute;
        private bool _isRunning;

        public AsyncRelayCommand(ExecuteDelegate execute) : this(execute, null)
        {
        }

        public AsyncRelayCommand(ExecuteDelegate execute, Func<T, bool> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler Executing;

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (_canExecute != null)
                    CommandManager.RequerySuggested += value;
                Executing += value;
            }
            remove
            {
                if (_canExecute != null)
                    CommandManager.RequerySuggested -= value;
                Executing -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return !_isRunning && (_canExecute == null || _canExecute((T) parameter));
        }

        public async void Execute(object parameter)
        {
            _isRunning = true;
            Executing?.Invoke(this, EventArgs.Empty);

            await _execute((T) parameter);

            _isRunning = false;
            Executing?.Invoke(this, EventArgs.Empty);
        }
    }
}