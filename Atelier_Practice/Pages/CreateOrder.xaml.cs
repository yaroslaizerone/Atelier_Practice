using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Atelier_Practice.Pages
{
    /// <summary>
    /// Логика взаимодействия для CeateOrder.xaml
    /// </summary>
    public partial class CeateOrder : Page
    {
        public CeateOrder()
        {
            InitializeComponent();
        }

        private void btnUpdateOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnOrder_Copy_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Выводится страница, на которой дизайнер заполняет поля и добавляет новую модель.");
        }
    }
}
