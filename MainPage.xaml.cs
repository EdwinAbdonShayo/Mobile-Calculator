using Microsoft.Maui.Controls;

namespace NumiX
{
    public partial class MainPage : ContentPage
    {
        //int count = 0;

        private double? num1 = null;
        private double? num2 = null;
        private double? dangling = null;
        private string? currentOperator = null;
        private Boolean? operatorClicked = false;


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

                if ( double.TryParse(QueryLabel.Text, out double parsedNumber) && operatorClicked == false )
                {
                    num1 = parsedNumber;
                    ResultLabel.Text = "";
                    operatorClicked = true;

                    // Update query with the operator
                    QueryLabel.Text += $" {button.Text} ";
                }

                else if ( double.TryParse(ResultLabel.Text, out double parsedResult) && operatorClicked == false )
                {
                    num1 = parsedResult;
                    ResultLabel.Text = "";

                    // Update query with the operator
                    QueryLabel.Text += $" {button.Text} ";
                }
                else
                {
                    ResultLabel.Text = "Error hapa";
                }
            }
        }

        private void OnNumberClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (string.IsNullOrEmpty(QueryLabel.Text) || QueryLabel.Text == "0")
                {
                    QueryLabel.Text = button.Text;
                }
                else if ( operatorClicked == true && double.TryParse(button.Text, out double parsedNumber) && num1 != null )
                {
                    
                    dangling = parsedNumber;

                    double result = currentOperator switch
                    {
                        "÷" => dangling == 0 ? double.NaN : num1.Value / dangling.Value,
                        "×" => num1.Value * dangling.Value,
                        "-" => num1.Value - dangling.Value,
                        "+" => num1.Value + dangling.Value,
                        _ => double.NaN,
                    };

                    ResultLabel.Text = double.IsNaN(result) ? "Error Uwiii" : result.ToString();
                    QueryLabel.Text += button.Text;
                }
                else
                {
                    QueryLabel.Text += button.Text;
                }

                // Update query as well
                //ResultLabel.Text += button.Text;
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
                    ResultLabel.Text = double.IsNaN(result) ? "Error 1" : result.ToString();

                    // Update the query label to show the full query

                    // Reset state
                    num1 = null;
                    num2 = null;
                    dangling = null;
                    currentOperator = null;
                    operatorClicked = false;
                }
                else
                {
                    ResultLabel.Text = "Error 2";
                }
            }
        }
    }


}






