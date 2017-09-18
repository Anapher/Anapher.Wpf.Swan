using System.Windows;

namespace Anapher.Wpf.Swan.ViewInterface
{
	/// <summary>
	/// Methods that handle the view
	/// </summary>
    public interface IWindowServiceInterface
    {
		/// <summary>
		/// Get the current topmost window
		/// </summary>
		/// <returns>Return the window</returns>
        IWindow GetCurrentWindow();

		/// <summary>
		/// Show a new window
		/// </summary>
		/// <typeparam name="TViewModel">The view model type of that window</typeparam>
		/// <param name="viewModel">The view model of that window</param>
		/// <returns>Return the window that was opened</returns>
		IWindow Show<TViewModel>(TViewModel viewModel);

	    /// <summary>
	    /// Show a new window
	    /// </summary>
	    /// <typeparam name="TViewModel">The view model type of that window</typeparam>
	    /// <param name="viewModel">The view model of that window</param>
	    /// <param name="title">The title of the window</param>
	    /// <returns>Return the window that was opened</returns>
	    IWindow Show<TViewModel>(TViewModel viewModel, string title);

	    /// <summary>
	    /// Show a new window that is centered on the current topmost window
	    /// </summary>
	    /// <typeparam name="TViewModel">The view model type of that window</typeparam>
	    /// <param name="viewModel">The view model of that window</param>
	    /// <returns>Return the window that was opened</returns>
		IWindow ShowCentered<TViewModel>(TViewModel viewModel);

		/// <summary>
		/// Show a new window that is centered on the current topmost window
		/// </summary>
		/// <typeparam name="TViewModel">The view model type of that window</typeparam>
		/// <param name="viewModel">The view model of that window</param>
		/// <param name="title">The title of the window</param>
		/// <returns>Return the window that was opened</returns>
		IWindow ShowCentered<TViewModel>(TViewModel viewModel, string title);

		/// <summary>
		/// Show a new window as dialog on top of the current topmost window
		/// </summary>
		/// <typeparam name="TViewModel">The view model type of that window</typeparam>
		/// <param name="viewModel">The view model of that window</param>
		/// <returns>Return the dialog result</returns>
		bool? ShowDialog<TViewModel>(TViewModel viewModel);

	    /// <summary>
	    /// Show a new window as dialog
	    /// </summary>
	    /// <typeparam name="TViewModel">The view model type of that window</typeparam>
	    /// <param name="viewModel">The view model of that window</param>
	    /// <param name="callerViewModel">The view model of the window that should be the parent of the dialog</param>
	    /// <returns>Return the dialog result</returns>
	    bool? ShowDialog<TViewModel>(TViewModel viewModel, object callerViewModel);

		/// <summary>
		/// Show a new window as dialog on top of the current topmost window
		/// </summary>
		/// <typeparam name="TViewModel">The view model type of that window</typeparam>
		/// <param name="viewModel">The view model of that window</param>
		/// <param name="title">The title of the window</param>
		/// <returns>Return the dialog result</returns>
		bool? ShowDialog<TViewModel>(TViewModel viewModel, string title);

		/// <summary>
		/// Show a new window as dialog
		/// </summary>
		/// <typeparam name="TViewModel">The view model type of that window</typeparam>
		/// <param name="viewModel">The view model of that window</param>
		/// <param name="title">The title of the window</param>
		/// <param name="callerViewModel">The view model of the window that should be the parent of the dialog</param>
		/// <returns>Return the dialog result</returns>
		bool? ShowDialog<TViewModel>(TViewModel viewModel, string title, object callerViewModel);

		/// <summary>
		/// Show a new dialog (e. g. a file dialog)
		/// </summary>
		/// <typeparam name="T">The type of the parameter of the delegate. For WPF, that must be Window</typeparam>
		/// <param name="showDialogDelegate">The delegate that will open the dialog</param>
		/// <returns>Return the dialog result</returns>
        bool? ShowDialog<T>(ShowDialogDelegate<T> showDialogDelegate) where T : Window;

		/// <summary>
		/// Show a new dialog (e. g. a file dialog)
		/// </summary>
		/// <typeparam name="T">The type of the parameter of the delegate. For WPF, that must be Window</typeparam>
		/// <param name="showDialogDelegate">The delegate that will open the dialog</param>
		/// <param name="callerViewModel">The view model of the window that should be the parent of the dialog</param>
		/// <returns>Return the dialog result</returns>
		bool? ShowDialog<T>(ShowDialogDelegate<T> showDialogDelegate, object callerViewModel) where T : Window;

	    /// <summary>
	    ///     Displays a message box.
	    /// </summary>
	    /// <param name="text">The text to display in the message box.</param>
	    /// <returns>One of the <see cref="MessageBoxResult" /> values</returns>
		MessageBoxResult ShowMessageBox(string text);

	    /// <summary>
	    ///     Displays a message box.
	    /// </summary>
	    /// <param name="text">The text to display in the message box.</param>
	    /// <param name="caption">The text to display in the title bar of the message box.</param>
	    /// <returns>One of the <see cref="MessageBoxResult" /> values</returns>
		MessageBoxResult ShowMessageBox(string text, string caption);

	    /// <summary>
	    ///     Displays a message box.
	    /// </summary>
	    /// <param name="text">The text to display in the message box.</param>
	    /// <param name="caption">The text to display in the title bar of the message box.</param>
	    /// <param name="buttons">
	    ///     One of the <see cref="MessageBoxButton" /> values that specifies which buttons to display in the
	    ///     message box.
	    /// </param>
	    /// <returns>One of the <see cref="MessageBoxResult" /> values</returns>
		MessageBoxResult ShowMessageBox(string text, string caption, MessageBoxButton buttons);

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
	    /// <returns>One of the <see cref="MessageBoxResult" /> values</returns>
		MessageBoxResult ShowMessageBox(string text, string caption, MessageBoxButton buttons,
            MessageBoxImage icon);

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
	    /// <returns>One of the <see cref="MessageBoxResult" /> values</returns>
		MessageBoxResult ShowMessageBox(string text, string caption, MessageBoxButton buttons,
            MessageBoxImage icon, MessageBoxResult defResult);

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

		/// <summary>
		///     Displays a message box.
		/// </summary>
		/// <param name="text">The text to display in the message box.</param>
		/// <param name="callerViewModel">The view model of the message box that should be the parent.</param>
		/// <returns>One of the <see cref="MessageBoxResult" /> values</returns>
		MessageBoxResult ShowMessageBox(string text, object callerViewModel);

		/// <summary>
		///     Displays a message box.
		/// </summary>
		/// <param name="text">The text to display in the message box.</param>
		/// <param name="caption">The text to display in the title bar of the message box.</param>
		/// <param name="callerViewModel">The view model of the message box that should be the parent.</param>
		/// <returns>One of the <see cref="MessageBoxResult" /> values</returns>
		MessageBoxResult ShowMessageBox(string text, string caption, object callerViewModel);

		/// <summary>
		///     Displays a message box.
		/// </summary>
		/// <param name="text">The text to display in the message box.</param>
		/// <param name="caption">The text to display in the title bar of the message box.</param>
		/// <param name="buttons">
		///     One of the <see cref="MessageBoxButton" /> values that specifies which buttons to display in the
		///     message box.
		/// </param>
		/// <param name="callerViewModel">The view model of the message box that should be the parent.</param>
		/// <returns>One of the <see cref="MessageBoxResult" /> values</returns>
		MessageBoxResult ShowMessageBox(string text, string caption, MessageBoxButton buttons, object callerViewModel);

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
		/// <param name="callerViewModel">The view model of the message box that should be the parent.</param>
		/// <returns>One of the <see cref="MessageBoxResult" /> values</returns>
		MessageBoxResult ShowMessageBox(string text, string caption, MessageBoxButton buttons,
            MessageBoxImage icon, object callerViewModel);

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
		/// <param name="callerViewModel">The view model of the message box that should be the parent.</param>
		/// <returns>One of the <see cref="MessageBoxResult" /> values</returns>
		MessageBoxResult ShowMessageBox(string text, string caption, MessageBoxButton buttons,
            MessageBoxImage icon, MessageBoxResult defResult, object callerViewModel);

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
		/// <param name="callerViewModel">The view model of the message box that should be the parent.</param>
		/// <returns>One of the <see cref="MessageBoxResult" /> values</returns>
		MessageBoxResult ShowMessageBox(string text, string caption, MessageBoxButton buttons,
            MessageBoxImage icon, MessageBoxResult defResult, MessageBoxOptions options, object callerViewModel);
    }

    /// <summary>
    ///     Can be any dialog method
    /// </summary>
    /// <param name="window">The owner window</param>
    /// <returns>Return the result of the dialog</returns>
    public delegate bool? ShowDialogDelegate<in T>(T window) where T : Window;
}