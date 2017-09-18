using System.ComponentModel;

namespace Anapher.Wpf.Swan.ViewInterface
{
	/// <summary>
	///     The interface to the view
	/// </summary>
	public static class WindowServiceInterface
	{
		/// <summary>
		///     Get the current interface set from the view
		/// </summary>
		public static IWindowServiceInterface Current { get; private set; }

		/// <summary>
		///     Initialize the view interface. This method must be called from the view
		/// </summary>
		/// <param name="windowServiceInterface"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void Initialize(IWindowServiceInterface windowServiceInterface)
		{
			Current = windowServiceInterface;
		}
	}
}