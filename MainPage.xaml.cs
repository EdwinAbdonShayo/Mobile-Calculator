using Microsoft.Maui.Controls;

namespace NumiX
{
    public partial class MainPage : ContentPage
    {
        //int count = 0;

        private double? num1 = null;
        private double? num2 = null;
        private string? currentOperator = null;

        public MainPage()
        {
            InitializeComponent();
        }
        private void OnCounterClicked(object sender, EventArgs e)
        {
            ResultEntry.Text = "0";
        }

        private void OnNegateClicked(object sender, EventArgs e)
        {
            if (double.TryParse(ResultEntry.Text, out double result))
            {
                result = -result;
                ResultEntry.Text = result.ToString();
            }
        }

        private void OnPercentClicked(object sender, EventArgs e)
        {
            if (double.TryParse(ResultEntry.Text, out double result))
            {
                result = result / 100;
                ResultEntry.Text = result.ToString();
            }
        }

        private void OnOperatorClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                currentOperator = button.Text;
                if (double.TryParse(ResultEntry.Text, out double parsedNumber))
                {
                    num1 = parsedNumber;
                    ResultEntry.Text = "0";
                }
                else
                {
                    ResultEntry.Text = "Error";
                }
            }
        }

        private void OnNumberClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (string.IsNullOrEmpty(ResultEntry.Text) || ResultEntry.Text == "0")
                {
                    ResultEntry.Text = button.Text;
                }
                else
                {
                    ResultEntry.Text += button.Text;
                }
            }
        }

        private void OnDecimalClicked(object sender, EventArgs e)
        {
            if (!ResultEntry.Text.Contains("."))
            {
                ResultEntry.Text += ".";
            }
        }

        private void OnClearClicked(object sender, EventArgs e)
        {
            ResultEntry.Text = "0";
        }

        private void OnEqualsClicked(object sender, EventArgs e)
        {
            if (num1.HasValue && !string.IsNullOrEmpty(currentOperator))
            {
                if (double.TryParse(ResultEntry.Text, out double parsedNumber))
                {
                    num2 = parsedNumber;

                    double result = currentOperator switch
                    {
                        "÷" => num2 == 0 ? double.NaN : num1.Value / num2.Value,
                        "×" => num1.Value * num2.Value,
                        "-" => num1.Value - num2.Value,
                        "+" => num1.Value + num2.Value,
                        _ => double.NaN,
                    };

                    ResultEntry.Text = double.IsNaN(result) ? "Error" : result.ToString();
                    num1 = null;
                    num2 = null;
                    currentOperator = null;
                }
                else
                {
                    ResultEntry.Text = "Error";
                }
            }
                
        }
    }


}









//namespace NumiX
//{
//    public partial class MainPage : ContentPage
//    {
//        int count = 0;

//        public MainPage()
//        {
//            InitializeComponent();
//        }

//        private void OnCounterClicked(object sender, EventArgs e)
//        {
//            count++;

//            if (count == 1)
//                CounterBtn.Text = $"Clicked {count} time";
//            else
//                CounterBtn.Text = $"Clicked {count} times";

//            SemanticScreenReader.Announce(CounterBtn.Text);
//        }
//    }

//}
