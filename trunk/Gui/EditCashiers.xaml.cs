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
using Interfaces;

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
            dataGridCashier.ItemsSource = controller.LoadCashiers();
        }

        private void dataGridCashier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            controller.actualCashier = (ICashier)dataGridCashier.CurrentItem; 
        }

        private void buttonDeleteCashier_Click(object sender, RoutedEventArgs e)
        {


            if (controller.actualCashier != null)
            {
                controller.DeleteCashier(controller.actualCashier);
                dataGridCashier.ItemsSource = null;
                dataGridCashier.ItemsSource = controller.LoadCashiers();
            }
            //dataGridCashier.Items.Refresh();
            
        }
    }
}
