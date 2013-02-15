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
using System.Windows.Shapes;

namespace Gui
{
    /// <summary>
    /// Interaction logic for EditCashiers.xaml
    /// </summary>
    public partial class EditCashiers : Window
    {
        private Controller.Facade controller;

        public EditCashiers()
        {
            InitializeComponent();
        }

        public EditCashiers(Controller.Facade controller)
        {
            // TODO: Complete member initialization
            this.controller = controller;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("test");
            dataGridCashier.ItemsSource = controller.LoadCashiers();
        }
    }
}
