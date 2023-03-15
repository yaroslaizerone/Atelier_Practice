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
    /// Логика взаимодействия для Customer.xaml
    /// </summary>
    public partial class CustomerPanel : Page
    {
        public Customer CustomerUser = new Customer();
        public UserSystem userSys = new UserSystem();
        public CustomerPanel(UserSystem userSystem)
        {
            InitializeComponent();
            if(userSystem.ID_Post != 1)
            {
                var orders = AtelerEntityes.GetContext().Orders.ToList();
                textFullName.Text = "Сотрудник Ателье";
                LViewOrders.ItemsSource = orders;
            }
            else
            {
                btnCreateOrder.Visibility = Visibility.Visible;
                textFullName.Text = Users(userSystem);
                var orders = AtelerEntityes.GetContext().Orders.Where(x => x.ID_Customer == CustomerUser.ID_Customer).ToList(); // Обращаемся к таблице с товарами и получаем список
                LViewOrders.ItemsSource = orders;
            }
            userSys = userSystem;
            if (userSystem.ID_Post == 6)
            {
                btnMaterWork.Visibility= Visibility.Visible;;
            }
            if (userSystem.ID_Post == 1 || userSystem.ID_Post == 2 || userSystem.ID_Post == 5 || userSystem.ID_Post == 6)
            {
                btnChangeSt.Visibility = Visibility.Visible;
            }
            if (userSystem.ID_Post == 2)
            { 
                btnOrderWork.Visibility = Visibility.Visible;
            }
            if (userSystem.ID_Post == 1 || userSystem.ID_Post == 2)
            {
                btnCreateOrder.Visibility = Visibility.Visible;
            }
        }
        public string Users(UserSystem userSystem)//Метод для вывода ФИО пользователя
        {
            CustomerUser = AtelerEntityes.GetContext().Customer.Where(x => x.ID_User == userSystem.ID_User).FirstOrDefault();
            string fullname = CustomerUser.SurnameCustomer.ToString() + " " + CustomerUser.NameCustomer.ToString() + " " + CustomerUser.PatronicCustomer.ToString();
            return textFullName.Text = fullname;
        }

        private void btnWatchOrder_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OrderWork(LViewOrders.SelectedItem as Orders, userSys));
        }

        private void btnCreateOrder_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CeateOrder());
        }

        private void btnChangeSt_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ChangeStatus(userSys));
        }

        private void btnMaterWork_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Workermaterial(userSys));
        }

        private void btnOrderWork_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ChangeStatus(userSys));
        }
    }
}
