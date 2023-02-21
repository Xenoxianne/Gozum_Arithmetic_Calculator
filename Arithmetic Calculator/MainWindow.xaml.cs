/*
	* Name: Denise Julianne S. Gozum
	* Section: BSCS 3-1N
	* Basic Calculator using WPF
*/

using System;
using System.Windows;
using System.Windows.Controls;

namespace Arithmetic_Calculator
{

	public partial class MainWindow : Window
	{
		int check = 0;

		public MainWindow()
		{
			InitializeComponent();
		}

		private double GetNumber(TextBox inputNum)
		{
			if (string.IsNullOrEmpty(inputNum.Text))
			{
				MessageBox.Show("You haven't entered a valid number in this text box!", "Error");
				inputNum.Focus();
				check = 1;
				return 0;
			}
			else
			{
				try
				{
					double num = Convert.ToDouble(inputNum.Text);
					return num;
				}
				catch
				{
					MessageBox.Show("Integer/Float values only!", "Error");
					inputNum.Focus();
					check = 1;
					return 0;
				}
			}
		}

		private void Button_Click(object operation, RoutedEventArgs e)
		{
			double num1 = GetNumber(this.txtnum1), num2 = 0;
			if (check == 0)
			{
				num2 = GetNumber(this.txtnum2);

				if (num2 != 0)
				{
					double answer = 0;

					string button = (operation as Button).Name.ToString();
					switch (button)
					{
						case "add":
							answer = num1 + num2;
							break;
						case "subtract":
							answer = num1 - num2;
							break;
						case "multiply":
							answer = num1 * num2;
							break;
						case "divide":
							answer = num1 / num2;
							break;
					}
					answerlbl.Content = "The answer is " + answer.ToString("#,##0.00");
					Height = 320;
					answerlbl.Visibility = Visibility.Visible;
				}
			}
			check = 0;
		}
	}
}
