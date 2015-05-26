using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Voystock
{
	/// <summary>
	/// Interaction logic for NumbericBox.xaml
	/// </summary>
	public partial class NumbericBox : UserControl
	{
		public NumbericBox()
		{
			InitializeComponent();
		}

		[Description("Test text displayed in the textbox"), Category("Data")]
        public int Text
        {
            get { return (int)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(int), typeof(NumbericBox), new PropertyMetadata(0));



        [DefaultValue(100), Category("Data")]
		public int MaxValue
		{
			get { return (int)GetValue(MaxValueProperty); }
			set { SetValue(MaxValueProperty, value); }
		}

		// Using a DependencyProperty as the backing store for MaxValue.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty MaxValueProperty =
			DependencyProperty.Register("MaxValue", typeof(int), typeof(NumbericBox), new PropertyMetadata(100));



		[DefaultValue(0), Category("Data")]
		public int MinValue
		{
			get { return (int)GetValue(MinValueProperty); }
			set { SetValue(MinValueProperty, value); }
		}

		// Using a DependencyProperty as the backing store for MinValue.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty MinValueProperty =
			DependencyProperty.Register("MinValue", typeof(int), typeof(NumbericBox), new PropertyMetadata(0));

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            if (e.Property.Name == "Text")
            {
                TextBox.Text = Math.Max(Math.Min(this.Text, MaxValue), MinValue).ToString();
            }
            base.OnPropertyChanged(e);
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			if (!char.IsDigit(e.Text, e.Text.Length - 1))
			{
				e.Handled = true;
			}
		}

		private void TextBox_TextInput(object sender, TextCompositionEventArgs e)
		{
			ValidateValue();
		}

		private void TextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			ValidateValue();
		}

		private int ValidateValue()
		{
			int value;
			if (int.TryParse(TextBox.Text, out value))
			{
				TextBox.Text = Math.Max(Math.Min(value, MaxValue), MinValue).ToString();
                this.Text = value;
			}
			else
			{
				value = MinValue;
				TextBox.Text = value.ToString();
			}
			return value;
		}

		private void TextBox_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Tab)
			{
				e.Handled = true;
				return;
			}

			if (e.Key == Key.Enter)
			{
				ValidateValue();

				TraversalRequest tRequest = new TraversalRequest(FocusNavigationDirection.Next);
				UIElement keyboardFocus = Keyboard.FocusedElement as UIElement;

				if (keyboardFocus != null)
				{
					keyboardFocus.MoveFocus(tRequest);
				}

				e.Handled = true;
			}
		}
	}
}
