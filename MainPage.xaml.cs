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
            QueryLabel.Text = "0";
        }

        private void OnNegateClicked(object sender, EventArgs e)
        {
            if (double.TryParse(QueryLabel.Text, out double result))
            {
                result = -result;
                QueryLabel.Text = result.ToString();
            }
        }

        private void OnPercentClicked(object sender, EventArgs e)
        {
            if (double.TryParse(QueryLabel.Text, out double result))
            {
                result = result / 100;
                QueryLabel.Text = result.ToString();
            }
        }

        private void OnOperatorClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                currentOperator = button.Text;

                if (double.TryParse(ResultLabel.Text, out double parsedNumber))
                {
                    num1 = parsedNumber;
                    ResultLabel.Text = "0";

                    // Update query with the operator
                    QueryLabel.Text += $" {button.Text} ";
                }
                else
                {
                    ResultLabel.Text = "Error";
                }
            }
        }

        private void OnNumberClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (string.IsNullOrEmpty(ResultLabel.Text) || ResultLabel.Text == "0")
                {
                    ResultLabel.Text = button.Text;
                }
                else
                {
                    ResultLabel.Text += button.Text;
                }

                // Update query as well
                QueryLabel.Text += button.Text;
            }
        }

        private void OnDecimalClicked(object sender, EventArgs e)
        {
            if (!QueryLabel.Text.Contains("."))
            {
                QueryLabel.Text += ".";
            }
        }

        private void OnClearClicked(object sender, EventArgs e)
        {
            ResultLabel.Text = "";
            QueryLabel.Text = "";
        }


        private void OnEqualsClicked(object sender, EventArgs e)
        {
            if (num1.HasValue && !string.IsNullOrEmpty(currentOperator))
            {
                if (double.TryParse(ResultLabel.Text, out double parsedNumber))
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

                    // Update the result label with the result
                    ResultLabel.Text = double.IsNaN(result) ? "Error" : result.ToString();

                    // Update the query label to show the full query

                    // Reset state
                    num1 = null;
                    num2 = null;
                    currentOperator = null;
                }
                else
                {
                    ResultLabel.Text = "Error";
                }
            }
        }
    }


}






