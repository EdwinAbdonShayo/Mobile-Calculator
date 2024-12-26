using Microsoft.Maui.Controls;

namespace NumiX
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
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
                ResultEntry.Text = count.ToString();
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
            //if (sender is Button button)
            //{
            //    if (double.TryParse(ResultEntry.Text, out double result))
            //    {
            //        result = result;
            //        ResultEntry.Text = "0";
            //    }
            //}
        }

        private void OnNumberClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (ResultEntry.Text == "0")
            {
                ResultEntry.Text = button.Text;
            }
            else
            {
                ResultEntry.Text += button.Text;
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
            if (double.TryParse(ResultEntry.Text, out double result))
            {
                ResultEntry.Text = result.ToString();
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
