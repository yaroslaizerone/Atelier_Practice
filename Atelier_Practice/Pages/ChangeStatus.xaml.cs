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
    /// Логика взаимодействия для ChangeStatus.xaml
    /// </summary>
    public partial class ChangeStatus : Page
    {
        UserSystem userS = new UserSystem();
        public ChangeStatus(UserSystem userSystem)
        {
            userS = userSystem;
            InitializeComponent();
            LViewOrders.ItemsSource = AtelerEntityes.GetContext().Orders.ToList();
        }

        private void btnChengeStatus_Click(object sender, RoutedEventArgs e)
        {
            Orders orders = LViewOrders.SelectedItem as Orders;
            NavigationService.Navigate(new OrderWork(orders, userS));
        }

        private void btnWotchVikrou_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new WorkVikroi());
        }

        private void btnAddWikroi_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new WorkVikroi());
        }
    }
}
