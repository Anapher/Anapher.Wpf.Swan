using System;
using System.ComponentModel;
using System.Windows;
using Anapher.Wpf.Swan.ViewInterface;

namespace Anapher.Wpf.Swan
{
	public class WpfWindow : IWindow
	{
		public WpfWindow(Window window)
		{
			Window = window;
		}

		public Window Window { get; }

		public event EventHandler Closed
		{
			add => Window.Closed += value;
			remove => Window.Closed -= value;
		}

		public event CancelEventHandler Closing
		{
		    add => Window.Closing += value;
		    remove => Window.Closing -= value;
		}

		public void Close()
		{
			Window.Close();
		}

		public bool Activate()
		{
		    return Window.Activate();
		}

	    public MessageBoxResult ShowMessageBox(string text, string caption, MessageBoxButton buttons,
	        MessageBoxImage icon, MessageBoxResult defResult, MessageBoxOptions options)
	    {
	        return MessageBoxEx.Show(Window, text, caption, buttons, icon, defResult, options);
	    }

	    public WindowState WindowState
		{
			get => Window.WindowState;
			set => Window.WindowState = value;
		}
	}
}