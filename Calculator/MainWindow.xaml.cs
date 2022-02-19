using System;
using System.Windows;
using System.Windows.Controls;

namespace Calculator
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

        public string Display { get; set; }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            label.Content = "0";
            Display = "";
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            string text = label.Content.ToString();

            if (text.Length <= 1)
            {
                label.Content = "0";
                Display = "";
            }
            else
            {
                label.Content = text.Remove(text.Length - 1, 1);
                Display = label.Content.ToString();
            }
        }

        private void btnSqrt_Click(object sender, RoutedEventArgs e)
        {
            if (label.Content.ToString() == "0")
                MessageBox.Show("Error");
            else
            {
                var result = Math.Sqrt(double.Parse(Display));
                label.Content = result;
            }
            
        }

        private void btnSqr_Click(object sender, RoutedEventArgs e)
        {
            Display = "";
            label.Content = "0";

        }
        private void numberClick(object sender, RoutedEventArgs e)
        {
            DisplayWriter((sender as Button).Content.ToString());
        }

        private void btnMultiplication_Click(object sender, RoutedEventArgs e)
        {
            char last = label.Content.ToString()[label.Content.ToString().Length - 1];
            InspectionLast(last, "*");
        }
       
        private void btnSeparation_Click(object sender, RoutedEventArgs e)
        {
            char last = label.Content.ToString()[label.Content.ToString().Length - 1];
            string s = (sender as Button).Content.ToString();
            InspectionLast(last, s);
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            char last = label.Content.ToString()[label.Content.ToString().Length - 1];
            string s = (sender as Button).Content.ToString();
            InspectionLast(last, s);
        }

        private void btnPoint_Click(object sender, RoutedEventArgs e)
        {
            char last = label.Content.ToString()[label.Content.ToString().Length - 1];
            string s = (sender as Button).Content.ToString();
            InspectionLast(last, s);
        }

        private void btnEquals_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Display = Evaluate(Display).ToString();
                label.Content = Display;
            }
            catch
            {
                label.Content = "0";
            }
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            char last = label.Content.ToString()[label.Content.ToString().Length - 1];
            string s = (sender as Button).Content.ToString();
            InspectionLast(last, s);
        }

        private static double Evaluate(string expression)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add("expression", string.Empty.GetType(), expression);
            System.Data.DataRow row = table.NewRow();
            table.Rows.Add(row);
            return double.Parse((string)row["expression"]);
        }

        private void DisplayWriter(string sender)
        {   
            Display += sender;
            label.Content = Display;
        }

        private void InspectionLast(char last, string sender)
        {
            if (last == '+' || last == '-' || last == '*' || last == '/' || last == '.')
            {
                Display = label.Content.ToString();
                label.Content = Display;
            }
            else if (last == '0')
            {
                label.Content = label.Content + sender;
                Display = label.Content.ToString();
            }
            else
                DisplayWriter(sender);
        }
    }
}
