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

		public event CancelEventHandler Closing;


		public void Close()
		{
			Window.Close();
		}

		public void Activate()
		{
			Window.Activate();
		}

		public WindowState WindowState
		{
			get => Window.WindowState;
			set => Window.WindowState = value;
		}
	}
}