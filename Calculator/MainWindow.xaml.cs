using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            int count = 1;


            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Button MyControl1 = new Button();
                    MyControl1.Content = count.ToString();
                    MyControl1.Name = "Button" + count.ToString();

                    Grid.SetColumn(MyControl1, j);
                    Grid.SetRow(MyControl1, i);
                    numberGrid.Children.Add(MyControl1);

                    count++;
                }

            }
            Button btnClr = new Button();
            btnClr.Content = "Clr";
            btnClr.Name = "btnClr";
            btnClr.Click += new RoutedEventHandler(ButtonClr_Click);
            Grid.SetColumn(btnClr, 3);
            Grid.SetRow(btnClr, 4);
            numberGrid.Children.Add(btnClr);
            Button btnDot = new Button();
            btnDot.Content = ".";
            btnDot.Name = "btnDot";
            Grid.SetColumn(btnDot, 0);
            Grid.SetRow(btnDot, 4);
            numberGrid.Children.Add(btnDot);
            Button btn0 = new Button();
            btn0.Content = "0";
            btn0.Name = "btn0";
            Grid.SetColumn(btn0, 1);
            Grid.SetRow(btn0, 4);
            numberGrid.Children.Add(btn0);
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (b.Name != "btnClr")
            {
                if (numberField.Content.ToString() == @"0")
                {
                    numberField.Content = b.Content;
                }
                else
                {
                    numberField.Content = numberField.Content.ToString() + b.Content.ToString();
                }
            }
        }


        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {
            if (numberField.Content.ToString() != @"0")
            {
                if (numberField.Content.ToString().Length > 1)
                {
                    numberField.Content = numberField.Content.ToString().Remove(numberField.Content.ToString().Length - 1, 1);
                } 
                else
                {
                    numberField.Content = "0";
                }
            
            } 
        }

        private void ButtonDiv_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (Char.IsDigit((numberField.Content.ToString()).Last()) == true)
            {
                numberField.Content = numberField.Content.ToString() + "/";
            }
            else
            {
                numberField.Content = numberField.Content.ToString().Remove(numberField.Content.ToString().Length - 1, 1) + "/";
            }
        }
        private void ButtonMul_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (Char.IsDigit((numberField.Content.ToString()).Last()) == true)
            {
                numberField.Content = numberField.Content.ToString() + "*";
            }
            else
            {
                numberField.Content = numberField.Content.ToString().Remove(numberField.Content.ToString().Length - 1, 1) + "*";
            }
        }
        private void ButtonSub_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (Char.IsDigit((numberField.Content.ToString()).Last()) == true)
            {
                numberField.Content = numberField.Content.ToString() + b.Content.ToString();
            }
            else
            {
                numberField.Content = numberField.Content.ToString().Remove(numberField.Content.ToString().Length - 1, 1) + b.Content.ToString();
            }
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (Char.IsDigit((numberField.Content.ToString()).Last()) == true)
            {
                numberField.Content = numberField.Content.ToString() + b.Content.ToString();
            }
            else
            {
                numberField.Content = numberField.Content.ToString().Remove(numberField.Content.ToString().Length - 1, 1) + b.Content.ToString();
            }
        }
        private void ButtonSum_Click(object sender, RoutedEventArgs e)
        {
            if (!Char.IsDigit((numberField.Content.ToString()).Last()))
            {
                numberField.Content = numberField.Content.ToString().Remove(numberField.Content.ToString().Length - 1, 1);
            }
            object results = Convert.ToDouble(new DataTable().Compute(numberField.Content.ToString(), ""));
            resultsField.Content = results;
        }

        private void ButtonClr_Click(object sender, RoutedEventArgs e)
        {
            numberField.Content = "0";
        }
    }


}
