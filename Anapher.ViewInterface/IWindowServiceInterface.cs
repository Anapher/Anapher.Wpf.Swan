using System;

namespace Anapher.ViewInterface
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
        bool? ShowDialog<T>(ShowDialogDelegate<T> showDialogDelegate) where T : class;

		/// <summary>
		/// Show a new dialog (e. g. a file dialog)
		/// </summary>
		/// <typeparam name="T">The type of the parameter of the delegate. For WPF, that must be Window</typeparam>
		/// <param name="showDialogDelegate">The delegate that will open the dialog</param>
		/// <param name="callerViewModel">The view model of the window that should be the parent of the dialog</param>
		/// <returns>Return the dialog result</returns>
		bool? ShowDialog<T>(ShowDialogDelegate<T> showDialogDelegate, object callerViewModel) where T : class;

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
    public delegate bool? ShowDialogDelegate<in T>(T window);

	/// <devdoc>
	///    <para>
	///       Specifies identifiers to
	///       indicate the return value of a dialog box.
	///    </para>
	/// </devdoc>
	/// <ExternalAPI/> 
	public enum MessageBoxResult
	{

		/// <devdoc>
		///    <para>
		///       
		///       Nothing is returned from the dialog box. This
		///       means that the modal dialog continues running.
		///       
		///    </para>
		/// </devdoc>
		/// <ExternalAPI/> 
		None = 0,

		/// <devdoc>
		///    <para>
		///       The
		///       dialog box return value is
		///       OK (usually sent from a button labeled OK).
		///       
		///    </para>
		/// </devdoc>
		/// <ExternalAPI/> 
		OK = 1,

		/// <devdoc>
		///    <para>
		///       The
		///       dialog box return value is Cancel (usually sent
		///       from a button labeled Cancel).
		///       
		///    </para>
		/// </devdoc>
		/// <ExternalAPI/> 
		Cancel = 2,

		/// <devdoc>
		///    <para>
		///       The dialog box return value is
		///       Yes (usually sent from a button labeled Yes).
		///       
		///    </para>
		/// </devdoc>
		/// <ExternalAPI/> 
		Yes = 6,

		/// <devdoc>
		///    <para>
		///       The dialog box return value is
		///       No (usually sent from a button labeled No).
		///       
		///    </para>
		/// </devdoc>
		/// <ExternalAPI/> 
		No = 7,

		// NOTE: if you add or remove any values in this enum, be sure to update MessageBox.IsValidMessageBoxResult()
	}
	/// <devdoc>
	///    <para>[To be supplied.]</para>
	/// </devdoc>
	[Flags]
	public enum MessageBoxOptions
	{
		/// <devdoc>
		///     <para>
		///         Specifies that all default options should be used.
		///     </para>
		/// </devdoc>
		/// <ExternalApi />
		None = 0x00000000,

		/// <devdoc>
		///    <para>
		///       Specifies that the message box is displayed on the active desktop. 
		///    </para>
		/// </devdoc>
		/// <ExternalAPI/> 
		ServiceNotification = 0x00200000,

		/// <devdoc>
		///    <para>
		///       Specifies that the message box is displayed on the active desktop. 
		///    </para>
		/// </devdoc>
		/// <ExternalAPI/> 
		DefaultDesktopOnly = 0x00020000,

		/// <devdoc>
		///    <para>
		///       Specifies that the message box text is right-aligned.
		///    </para>
		/// </devdoc>
		/// <ExternalAPI/> 
		RightAlign = 0x00080000,

		/// <devdoc>
		///    <para>
		///       Specifies that the message box text is displayed with Rtl reading order.
		///    </para>
		/// </devdoc>
		/// <ExternalAPI/> 
		RtlReading = 0x00100000,
	}
	/// <devdoc>
	///    <para>[To be supplied.]</para>
	/// </devdoc>
	public enum MessageBoxImage
	{
		/// <devdoc>
		///    <para>
		///       Specifies that the
		///       message box contain no symbols. 
		///    </para>
		/// </devdoc>
		/// <ExternalAPI/> 
		None = 0,

		/// <devdoc>
		///    <para>
		///       Specifies that the
		///       message box contains a
		///       hand symbol. 
		///    </para>
		/// </devdoc>
		/// <ExternalAPI/> 
		Hand = 0x00000010,

		/// <devdoc>
		///    <para>
		///       Specifies
		///       that the message
		///       box contains a question
		///       mark symbol. 
		///    </para>
		/// </devdoc>
		/// <ExternalAPI/> 
		Question = 0x00000020,

		/// <devdoc>
		///    <para>
		///       Specifies that the
		///       message box contains an
		///       exclamation symbol. 
		///    </para>
		/// </devdoc>
		/// <ExternalAPI/> 
		Exclamation = 0x00000030,

		/// <devdoc>
		///    <para>
		///       Specifies that the
		///       message box contains an
		///       asterisk symbol. 
		///    </para>
		/// </devdoc>
		/// <ExternalAPI/> 
		Asterisk = 0x00000040,

		/// <devdoc>
		///    <para>
		///       Specifies that the message box contains a hand icon. This field is
		///       constant.
		///    </para>
		/// </devdoc>
		/// <ExternalAPI/> 
		Stop = Hand,

		/// <devdoc>
		///    <para>
		///       Specifies that the
		///       message box contains a
		///       hand icon. 
		///    </para>
		/// </devdoc>
		/// <ExternalAPI/> 
		Error = Hand,

		/// <devdoc>
		///    <para>
		///       Specifies that the message box contains an exclamation icon. 
		///    </para>
		/// </devdoc>
		/// <ExternalAPI/> 
		Warning = Exclamation,

		/// <devdoc>
		///    <para>
		///       Specifies that the
		///       message box contains an
		///       asterisk icon. 
		///    </para>
		/// </devdoc>
		/// <ExternalAPI/> 
		Information = Asterisk,

		// NOTE: if you add or remove any values in this enum, be sure to update MessageBox.IsValidMessageBoxIcon()    
	}
	/// <devdoc>
	///    <para>[To be supplied.]</para>
	/// </devdoc>
	public enum MessageBoxButton
	{
		/// <devdoc>
		///    <para>
		///       Specifies that the
		///       message box contains an OK button. This field is
		///       constant.
		///    </para>
		/// </devdoc>
		OK = 0x00000000,

		/// <devdoc>
		///    <para>
		///       Specifies that the
		///       message box contains OK and Cancel button. This field
		///       is
		///       constant.
		///    </para>
		/// </devdoc>
		OKCancel = 0x00000001,

		/// <devdoc>
		///    <para>
		///       Specifies that the
		///       message box contains Yes, No, and Cancel button. This
		///       field is
		///       constant.
		///    </para>
		/// </devdoc>
		YesNoCancel = 0x00000003,

		/// <devdoc>
		///    <para>
		///       Specifies that the
		///       message box contains Yes and No button. This field is
		///       constant.
		///    </para>
		/// </devdoc>
		YesNo = 0x00000004,

		// NOTE: if you add or remove any values in this enum, be sure to update MessageBox.IsValidMessageBoxButton()
	}
}