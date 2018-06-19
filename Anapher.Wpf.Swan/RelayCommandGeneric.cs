using System;
using System.Windows.Input;

namespace Anapher.Wpf.Swan
{
	/// <summary>
	///     A generic command whose sole purpose is to relay its functionality to other objects by invoking delegates. The
	///     default
	///     return value for the CanExecute method is 'true'.
	/// </summary>
	/// <remarks></remarks>
	/// <example>
	///     <code>
	/// private RelayCommand&lt;string&gt; _testCommand;
	/// 
	/// public RelayCommand&lt;string&gt; TestCommand
	/// {
	///     get
	///     {
	///         return _testCommand ?? (_testCommand = new RelayCommand&lt;string&gt;(parameter =>
	///         {
	/// 
	///         }));
	///      }
	/// }
	///  </code>
	/// </example>
	public class RelayCommand<T> : ICommand
	{
		public delegate void ExecuteDelegate(T parameter);

		private readonly Func<T, bool> _canExecute;
		private readonly ExecuteDelegate _execute;

		public RelayCommand(ExecuteDelegate execute)
			: this(execute, null)
		{
		}

		public RelayCommand(ExecuteDelegate execute, Func<T, bool> canExecute)
		{
			_execute = execute ?? throw new ArgumentNullException(nameof(execute));
			_canExecute = canExecute;
		}

		public event EventHandler CanExecuteChanged
		{
			add
			{
				if (_canExecute != null)
					CommandManager.RequerySuggested += value;
			}
			remove
			{
				if (_canExecute != null)
					CommandManager.RequerySuggested -= value;
			}
		}

		public bool CanExecute(object parameter)
		{
			return _canExecute == null || _canExecute.Invoke((T) parameter);
		}

		void ICommand.Execute(object parameter)
		{
			_execute.Invoke((T) parameter);
		}

		public void Execute(T parameter)
		{
			_execute.Invoke(parameter);
		}
	}
}