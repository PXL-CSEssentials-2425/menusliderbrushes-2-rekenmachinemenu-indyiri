using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace H9Oef2RekenmachineMenu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private double number1;
        private double number2;

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            number1TextBox.Clear();
            number2TextBox.Clear();
            resultTextBox.Clear();
            number1TextBox.Focus();
        }

        private void divideButton_Click(object sender, RoutedEventArgs e)
        {
            if (ReadNumbers(number1TextBox.Text, number2TextBox.Text))
            {
                if (number2 != 0)
                {
                    Calculate(number1, number2, default);
                }
                else
                {
                    resultTextBox.Text = "Cannot divide by zero";
                }
            }
            else
            {
                resultTextBox.Text = "Input moeten getallen zijn!";
            }
        }

        private bool ReadNumbers(string inputNumber1, string inputNumber2)
        {
            bool isInputNumber1Valid = double.TryParse(inputNumber1, out number1);
            bool isInputNumber2Valid = double.TryParse(inputNumber2, out number2);

            return isInputNumber1Valid && isInputNumber2Valid;
        }

        private void Calculate(double number1, double number2, char sign)
        {
            double result;

            switch (sign)
            {
                case '+':
                    result = number1 + number2;
                    break;
                case '-':
                    result = number1 - number2;
                    break;
                case '*':
                    result = number1 * number2;
                    break;
                default:
                    result = number1 / number2;
                    break;
            }

            resultTextBox.Text = result.ToString();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (ReadNumbers(number1TextBox.Text, number2TextBox.Text))
            {
                if (button == addButton)
                {
                    Calculate(number1, number2, '+');
                }
                else if (button == minusButton)
                {
                    Calculate(number1, number2, '-');
                }
                else if (button == multiplyButton)
                {
                    Calculate(number1, number2, '*');
                }
                else if (button == divideButton)
                {
                    if (number2 != 0)
                    {
                        Calculate(number1, number2, default);
                    }
                    else
                    {
                        resultTextBox.Text = "Cannot divide by zero";
                    }
                }
            }
            else
            {
                resultTextBox.Text = "Input moeten getallen zijn!";
            }
        }

        private void closeMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void calculateMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}