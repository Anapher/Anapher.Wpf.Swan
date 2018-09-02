using System;
using System.ComponentModel;
using System.Windows;

namespace Anapher.Wpf.Swan.ViewInterface
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
		bool Activate();

	    /// <summary>
	    ///     Displays a message box.
	    /// </summary>
	    /// <param name="text">The text to display in the message box.</param>
	    /// <param name="caption">The text to display in the title bar of the message box.</param>
	    /// <param name="buttons">
	    ///     One of the <see cref="MessageBoxButton" /> values that specifies which buttons to display in the
	    ///     message box.
	    /// </param>
	    /// <param name="icon">
	    ///     One of the <see cref="MessageBoxImage" /> values that specifies which icon to display in the message
	    ///     box.
	    /// </param>
	    /// <param name="defResult">
	    ///     One of the <see cref="MessageBoxResult" /> values that specifies the default button for the
	    ///     message box.
	    /// </param>
	    /// <param name="options">
	    ///     One of the <see cref="MessageBoxOptions" /> values that specifies which display and association
	    ///     options will be used for the message box. You may pass in 0 if you wish to use the defaults.
	    /// </param>
	    /// <returns>One of the <see cref="MessageBoxResult" /> values</returns>
	    MessageBoxResult ShowMessageBox(string text, string caption, MessageBoxButton buttons,
	        MessageBoxImage icon, MessageBoxResult defResult, MessageBoxOptions options);
	}
}