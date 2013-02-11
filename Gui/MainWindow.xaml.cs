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
using Interfaces;

namespace Gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Facade controller;
        private NyFacade controller;
        private DBFacadeSalesLineItem dbfSalesLineItem;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //controller = new Facade();
            //controller.CreateCustomer("Søren", "Pedersen", "Odensevej", "5000");

            controller = new NyFacade();
            
            dbfSalesLineItem = new DBFacadeSalesLineItem(controller.dbconn);
            dbfSalesLineItem.CreateSalesLineItem(12, 1, 1);

            controller.CloseDB();
        }
    }
}
