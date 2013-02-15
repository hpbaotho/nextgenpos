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
            //dgv.CellEndEdit += new DataGridViewCellEventHandler(onEndEdit); 
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
            ICashier c = (ICashier)dataGridCashier.CurrentItem;

            if (c != null)
            {

                controller.actualCashier = c;
                textBoxName.Text = c.Name;
                textBoxSalery.Text = c.Salery.ToString();
                textBoxTelephone.Text = c.Telephone;
            }
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

        private void dataGridCashier_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {   
            MessageBox.Show("Find passende event " );
        }

        private void dataGridCashier_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            //MessageBox.Show(((ICashier)dataGridCashier.SelectedItem).Name);
        }

        private void dataGridCashier_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            MessageBox.Show("YOUHOU" + ((ICashier)dataGridCashier.SelectedItem).Name + e.Row);
        }

        private void dataGridCashier_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void buttonCorrectCashier_Click(object sender, RoutedEventArgs e)
        {
        
            controller.UpdateCashier(controller.actualCashier.Cashier_id,
                textBoxName.Text,
                Decimal.Parse(textBoxSalery.Text),
                textBoxTelephone.Text);

            dataGridCashier.ItemsSource = controller.LoadCashiers();
        }
        
    }
}
