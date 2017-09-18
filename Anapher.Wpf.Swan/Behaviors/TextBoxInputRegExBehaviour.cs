﻿using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace Anapher.Wpf.Swan.Behaviors
{
	/// <summary>
	///     Regular expression for Textbox with properties:
	///     <see cref="RegularExpression" />,
	///     <see cref="MaxLength" />,
	///     <see cref="EmptyValue" />.
	/// </summary>
	public class TextBoxInputRegExBehaviour : Behavior<TextBox>
	{
		public static readonly DependencyProperty RegularExpressionProperty =
			DependencyProperty.Register("RegularExpression", typeof(string), typeof(TextBoxInputRegExBehaviour),
				new FrameworkPropertyMetadata(".*"));

		public static readonly DependencyProperty MaxLengthProperty =
			DependencyProperty.Register("MaxLength", typeof(int), typeof(TextBoxInputRegExBehaviour),
				new FrameworkPropertyMetadata(int.MinValue));

		public static readonly DependencyProperty EmptyValueProperty =
			DependencyProperty.Register("EmptyValue", typeof(string), typeof(TextBoxInputRegExBehaviour), null);

		public string RegularExpression
		{
			get => (string) GetValue(RegularExpressionProperty);
			set => SetValue(RegularExpressionProperty, value);
		}

		public int MaxLength
		{
			get => (int) GetValue(MaxLengthProperty);
			set => SetValue(MaxLengthProperty, value);
		}

		public string EmptyValue
		{
			get => (string) GetValue(EmptyValueProperty);
			set => SetValue(EmptyValueProperty, value);
		}

		/// <summary>
		///     Attach our behaviour. Add event handlers
		/// </summary>
		protected override void OnAttached()
		{
			base.OnAttached();

			AssociatedObject.PreviewTextInput += PreviewTextInputHandler;
			AssociatedObject.PreviewKeyDown += PreviewKeyDownHandler;
			DataObject.AddPastingHandler(AssociatedObject, PastingHandler);
		}

		/// <summary>
		///     Deattach our behaviour. remove event handlers
		/// </summary>
		protected override void OnDetaching()
		{
			base.OnDetaching();

			AssociatedObject.PreviewTextInput -= PreviewTextInputHandler;
			AssociatedObject.PreviewKeyDown -= PreviewKeyDownHandler;
			DataObject.RemovePastingHandler(AssociatedObject, PastingHandler);
		}

		private void PreviewTextInputHandler(object sender, TextCompositionEventArgs e)
		{
			string text;
			if (AssociatedObject.Text.Length < AssociatedObject.CaretIndex)
			{
				text = AssociatedObject.Text;
			}
			else
			{
				//  Remaining text after removing selected text.
				string remainingTextAfterRemoveSelection;

				text = TreatSelectedText(out remainingTextAfterRemoveSelection)
					? remainingTextAfterRemoveSelection.Insert(AssociatedObject.SelectionStart, e.Text)
					: AssociatedObject.Text.Insert(AssociatedObject.CaretIndex, e.Text);
			}

			e.Handled = !ValidateText(text);
		}

		/// <summary>
		///     PreviewKeyDown event handler
		/// </summary>
		private void PreviewKeyDownHandler(object sender, KeyEventArgs e)
		{
			if (string.IsNullOrEmpty(EmptyValue))
				return;

			string text = null;

			// Handle the Backspace key
			if (e.Key == Key.Back)
			{
				if (!TreatSelectedText(out text))
					if (AssociatedObject.SelectionStart > 0)
						text = AssociatedObject.Text.Remove(AssociatedObject.SelectionStart - 1, 1);
			}
			// Handle the Delete key
			else if (e.Key == Key.Delete)
			{
				// If text was selected, delete it
				if (!TreatSelectedText(out text) && AssociatedObject.Text.Length > AssociatedObject.SelectionStart)
					text = AssociatedObject.Text.Remove(AssociatedObject.SelectionStart, 1);
			}

			if (text == string.Empty)
			{
				AssociatedObject.Text = EmptyValue;
				if (e.Key == Key.Back)
					AssociatedObject.SelectionStart++;
				e.Handled = true;
			}
		}

		private void PastingHandler(object sender, DataObjectPastingEventArgs e)
		{
			if (e.DataObject.GetDataPresent(DataFormats.Text))
			{
				var text = Convert.ToString(e.DataObject.GetData(DataFormats.Text));

				if (!ValidateText(text))
					e.CancelCommand();
			}
			else
			{
				e.CancelCommand();
			}
		}

		/// <summary>
		///     Validate certain text by our regular expression and text length conditions
		/// </summary>
		/// <param name="text"> Text for validation </param>
		/// <returns> True - valid, False - invalid </returns>
		private bool ValidateText(string text)
		{
			return new Regex(RegularExpression, RegexOptions.IgnoreCase).IsMatch(text) &&
			       (MaxLength == int.MinValue || text.Length <= MaxLength);
		}

		/// <summary>
		///     Handle text selection
		/// </summary>
		/// <returns>true if the character was successfully removed; otherwise, false. </returns>
		private bool TreatSelectedText(out string text)
		{
			text = null;
			if (AssociatedObject.SelectionLength <= 0)
				return false;

			var length = AssociatedObject.Text.Length;
			if (AssociatedObject.SelectionStart >= length)
				return true;

			if (AssociatedObject.SelectionStart + AssociatedObject.SelectionLength >= length)
				AssociatedObject.SelectionLength = length - AssociatedObject.SelectionStart;

			text = AssociatedObject.Text.Remove(AssociatedObject.SelectionStart, AssociatedObject.SelectionLength);
			return true;
		}
	}
}