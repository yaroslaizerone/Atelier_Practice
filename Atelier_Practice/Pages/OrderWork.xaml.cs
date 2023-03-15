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
    /// Логика взаимодействия для OrderWork.xaml
    /// </summary>
    public partial class OrderWork : Page
    {   
        Orders orders = new Orders();
        public OrderWork(Orders SelectOrder, UserSystem userSystem)
        {
            InitializeComponent();
            DataContext = SelectOrder;
            orders = SelectOrder;
            cmbStatus.ItemsSource = AtelerEntityes.GetContext().StatusOrder.ToList();
            LViewProduct.ItemsSource = AtelerEntityes.GetContext().OrderProduct.Where(x => x.ID_Order == SelectOrder.ID_Order).ToList();
            IdOrd.Text = SelectOrder.ID_Order.ToString();
            cmbStatus.SelectedIndex = SelectOrder.ID_StatusOrder - 1;
            Customer customer = AtelerEntityes.GetContext().Customer.Where(x => x.ID_Customer == SelectOrder.ID_Customer).FirstOrDefault();
            CustFull.Text = customer.SurnameCustomer.ToString() +" "+ customer.NameCustomer.ToString() + " " + customer.PatronicCustomer.ToString() + " ";
            DateCreate.Text = SelectOrder.DateOrder.ToString("dd.MM.yyyy");
            Datefit.Text = SelectOrder.DateFitting.ToString("dd.MM.yyyy");
            PraseOrder.Text = SelectOrder.Price.ToString();
            PrepayOrder.Text = SelectOrder.Prepayment.ToString();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                orders.ID_StatusOrder = cmbStatus.SelectedIndex + 1;
                AtelerEntityes.GetContext().SaveChanges();//Сохранение в БД
                MessageBox.Show("Статус заказа был изменён!");
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }  
        }
    }
}
