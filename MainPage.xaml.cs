using System.Linq;
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
        private int? operatorCount = null;
        private string? danglingText = null;


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
                    operatorCount = 1;

                    // Update query with the operator
                    QueryLabel.Text += $" {button.Text} ";
                }

                else if ( double.TryParse(ResultLabel.Text, out double parsedResult) && operatorClicked == true )
                {

                    num1 = parsedResult;
                    ResultLabel.Text = "";
                    operatorCount += 1;
                    danglingText = "";

                    // Update query with the operator
                    QueryLabel.Text += $" {button.Text} ";

                    ResultLabel.Text = "";
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
                else if ( operatorClicked == true && num1 != null )
                {

                    danglingText += button.Text;
                    double.TryParse(danglingText, out double parsedNumber);
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
            dangling = null;
            danglingText = null;
            currentOperator = null;
            operatorClicked = false;
        }


        private void OnEqualsClicked(object sender, EventArgs e)
        {

            QueryLabel.Text = ResultLabel.Text;
            ResultLabel.Text = "";
            double.TryParse(QueryLabel.Text, out double parsedNum);
            num1 = parsedNum;
            num2 = null;
            dangling = null;
            currentOperator = null;
            operatorClicked = false;
        
        }
    }


}






