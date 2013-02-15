using System;
using System.Collections.Generic;
using System.Linq;
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

using Controller;

namespace Gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Facade controller;

        public MainWindow()
        {
            InitializeComponent();
            controller = new Facade();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            
            controller.UpdateCashier(42, "Morten Kühnrich", 3000, "51255919");
            controller.CreateCashier("Henning Dyremose", 50000, "123456677");
        }

        private void exit_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void edit_cashiers_click(object sender, RoutedEventArgs e)
        {
            EditCashiers ec = new EditCashiers(controller);

            ec.Show();
        }
    }
}
