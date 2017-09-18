using System;
using System.ComponentModel;

namespace Anapher.ViewInterface
{
	/// <summary>
	///     Represents a simple window
	/// </summary>
	public interface IWindow
	{
		/// <summary>
		///     Get/set the current window state
		/// </summary>
		WindowState WindowState { get; set; }

		/// <summary>
		///     The closed event of the window
		/// </summary>
		event EventHandler Closed;

		/// <summary>
		///     The closing event of the window
		/// </summary>
		event CancelEventHandler Closing;

		/// <summary>
		///     Close the window
		/// </summary>
		void Close();

		/// <summary>
		///     Activate the window
		/// </summary>
		void Activate();
	}

	/// <summary>
	///     The state of a window
	/// </summary>
	public enum WindowState
	{
		/// <summary>
		///     Default size
		/// </summary>
		Normal = 0,

		/// <summary>
		///     Minimized
		/// </summary>
		Minimized = 1, // WS_MINIMIZE

		/// <summary>
		///     Maximized
		/// </summary>
		Maximized = 2 // WS_MAXIMIZE
	}
}