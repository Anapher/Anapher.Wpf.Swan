using System;
using System.Collections.Generic;
using System.Windows;
using Anapher.Wpf.Swan.ViewInterface;

namespace Anapher.Wpf.Swan
{
	/// <summary>
	///     An <see cref="IWindowServiceInterface" /> implementation for WPF
	/// </summary>
	public class WpfWindowServiceInterface : IWindowServiceInterface
	{
		private readonly Dictionary<object, Window> _allWindows;
		private readonly Stack<Window> _windowStack;
		private readonly Dictionary<Type, IWindowViewModel> _windowViewModels;

		public WpfWindowServiceInterface()
		{
			_windowViewModels = new Dictionary<Type, IWindowViewModel>();
			_windowStack = new Stack<Window>();
			_allWindows = new Dictionary<object, Window>();
		}

		public IWindow GetCurrentWindow()
		{
			return new WpfWindow(_windowStack.Peek());
		}

		public IWindow Show<TViewModel>(TViewModel viewModel)
		{
			var windowViewModel = _windowViewModels[typeof(TViewModel)];
			var window = windowViewModel.GetWindow();
			window.DataContext = viewModel;
			window.Show();
			AddWindow(viewModel, window);

			return new WpfWindow(window);
		}

		public IWindow Show<TViewModel>(TViewModel viewModel, string title)
		{
			var windowViewModel = _windowViewModels[typeof(TViewModel)];
			var window = windowViewModel.GetWindow();
			window.DataContext = viewModel;
			window.Title = title;
			window.Show();
			AddWindow(viewModel, window);

			return new WpfWindow(window);
		}

		public IWindow ShowCentered<TViewModel>(TViewModel viewModel)
		{
			var windowViewModel = _windowViewModels[typeof(TViewModel)];
			var window = windowViewModel.GetWindow();
			window.DataContext = viewModel;
			window.CenterOnWindow(_windowStack.Peek());
			window.Show();
			AddWindow(viewModel, window);

			return new WpfWindow(window);
		}

		public IWindow ShowCentered<TViewModel>(TViewModel viewModel, string title)
		{
			var windowViewModel = _windowViewModels[typeof(TViewModel)];
			var window = windowViewModel.GetWindow();
			window.DataContext = viewModel;
			window.Title = title;
			window.CenterOnWindow(_windowStack.Peek());
			window.Show();
			AddWindow(viewModel, window);

			return new WpfWindow(window);
		}

		public bool? ShowDialog<TViewModel>(TViewModel viewModel)
		{
			return ShowDialog(viewModel, null);
		}

		public bool? ShowDialog<TViewModel>(TViewModel viewModel, object callerViewModel)
		{
			var windowViewModel = _windowViewModels[typeof(TViewModel)];
			var window = windowViewModel.GetWindow();
			window.DataContext = viewModel;
			window.Owner = GetViewModelWindowOrCurrent(callerViewModel);
			_windowStack.Push(window);
			AddWindow(viewModel, window);

			try
			{
				return window.ShowDialog();
			}
			finally
			{
				_windowStack.Pop();
			}
		}

		public bool? ShowDialog<TViewModel>(TViewModel viewModel, string title)
		{
			return ShowDialog(viewModel, title, null);
		}

		public bool? ShowDialog<TViewModel>(TViewModel viewModel, string title, object callerViewModel)
		{
			var windowViewModel = _windowViewModels[typeof(TViewModel)];
			var window = windowViewModel.GetWindow();
			window.DataContext = viewModel;
			window.Owner = GetViewModelWindowOrCurrent(callerViewModel);
			window.Title = title;
			_windowStack.Push(window);
			AddWindow(viewModel, window);

			try
			{
				return window.ShowDialog();
			}
			finally
			{
				_windowStack.Pop();
			}
		}

		public bool? ShowDialog<T>(ShowDialogDelegate<T> showDialogDelegate) where T : Window
		{
			return ShowDialog(showDialogDelegate, null);
		}

		public bool? ShowDialog<T>(ShowDialogDelegate<T> showDialogDelegate, object callerViewModel) where T : Window
		{
			var window = GetViewModelWindowOrCurrent(callerViewModel) as T;
			return showDialogDelegate(window);
		}

		public MessageBoxResult ShowMessageBox(string text)
		{
			return ShowMessageBox(text, (object) null);
		}

		public MessageBoxResult ShowMessageBox(string text, string caption)
		{
			return ShowMessageBox(text, caption, null);
		}

		public MessageBoxResult ShowMessageBox(string text, string caption, MessageBoxButton buttons)
		{
			return ShowMessageBox(text, caption, buttons, null);
		}

		public MessageBoxResult ShowMessageBox(string text, string caption, MessageBoxButton buttons,
			MessageBoxImage icon)
		{
			return ShowMessageBox(text, caption, buttons, icon, null);
		}

		public MessageBoxResult ShowMessageBox(string text, string caption, MessageBoxButton buttons,
			MessageBoxImage icon, MessageBoxResult defResult)
		{
			return ShowMessageBox(text, caption, buttons, icon, defResult, null);
		}

		public MessageBoxResult ShowMessageBox(string text, string caption, MessageBoxButton buttons,
			MessageBoxImage icon, MessageBoxResult defResult, MessageBoxOptions options)
		{
			return ShowMessageBox(text, caption, buttons, icon, defResult, options, null);
		}

		public MessageBoxResult ShowMessageBox(string text, object viewModel)
		{
			return MessageBoxEx.Show(GetViewModelWindowOrCurrent(viewModel), text);
		}

		public MessageBoxResult ShowMessageBox(string text, string caption, object viewModel)
		{
			return MessageBoxEx.Show(GetViewModelWindowOrCurrent(viewModel), text, caption);
		}

		public MessageBoxResult ShowMessageBox(string text, string caption, MessageBoxButton buttons, object viewModel)
		{
			return MessageBoxEx.Show(GetViewModelWindowOrCurrent(viewModel), text, caption,
				buttons);
		}

		public MessageBoxResult ShowMessageBox(string text, string caption, MessageBoxButton buttons,
			MessageBoxImage icon, object viewModel)
		{
			return MessageBoxEx.Show(GetViewModelWindowOrCurrent(viewModel), text, caption,
				buttons, icon);
		}

		public MessageBoxResult ShowMessageBox(string text, string caption, MessageBoxButton buttons,
			MessageBoxImage icon, MessageBoxResult defResult, object viewModel)
		{
			return MessageBoxEx.Show(GetViewModelWindowOrCurrent(viewModel), text, caption,
				buttons, icon,
				defResult);
		}

		public MessageBoxResult ShowMessageBox(string text, string caption, MessageBoxButton buttons,
			MessageBoxImage icon, MessageBoxResult defResult, MessageBoxOptions options, object viewModel)
		{
			return MessageBoxEx.Show(GetViewModelWindowOrCurrent(viewModel), text, caption,
				buttons, icon,
				defResult,
				options);
		}

		/// <summary>
		///     Register the main window (that must be called after the main window is opened, the main window will be retrived
		///     from <code>Application.Current.MainWindow</code>)
		/// </summary>
		public void RegisterMainWindow()
		{
			var window = Application.Current.MainWindow;
			_windowStack.Push(window);
			window.Closed += (sender, args) =>
			{
				if (_windowStack.Peek() == window)
					_windowStack.Pop();
			};
		}

		/// <summary>
		///     Register a new window and bind it to a view model
		/// </summary>
		/// <typeparam name="TWindow">The window</typeparam>
		/// <typeparam name="TViewModel">The view model of the <see cref="TWindow" /></typeparam>
		public void RegisterWindow<TWindow, TViewModel>() where TWindow : Window, new()
		{
			_windowViewModels.Add(typeof(TViewModel), new WindowViewModel<TWindow>());
		}

		private Window GetViewModelWindowOrCurrent(object viewModel)
		{
			if (viewModel == null || !_allWindows.TryGetValue(viewModel, out var window))
				return _windowStack.Count > 0 ? _windowStack.Peek() : null;

			return window;
		}

		private void AddWindow(object viewModel, Window window)
		{
			_allWindows.Add(viewModel, window);
			window.Closed += (sender, args) => _allWindows.Remove(viewModel);
		}

		private interface IWindowViewModel
		{
			Window GetWindow();
		}

		private class WindowViewModel<TWindow> : IWindowViewModel where TWindow : Window, new()
		{
			public Window GetWindow()
			{
				return new TWindow();
			}
		}
	}
}