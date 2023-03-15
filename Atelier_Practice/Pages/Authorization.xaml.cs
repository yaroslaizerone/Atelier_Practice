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
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            UserSystem user = new UserSystem();//Создаём объект пользователя
            string login = textLogin.Text.Trim();//Записываем в переменную логин
            string password = textPassword.Text.Trim(); //Записываем в перемненную пароль

            user = AtelerEntityes.GetContext().UserSystem.Where(x => x.Login == login && x.Password == password).FirstOrDefault(); // Параметр, хранящий в себе данные найденного пользователя
            int userСount = AtelerEntityes.GetContext().UserSystem.Where(x => x.Login == login && x.Password == password).Count(); // Поиск количества пользователей с данными параметрами

            if (userСount > 0)
            {
                Аuthorization(user);
            }
            else
            {
                MessageBox.Show("Логин или пароль неверный!");
                textLogin.Text = "";
                textPassword.Text = "";
            }
        }
        public void Аuthorization(UserSystem user)
        {
            MessageBox.Show($"Вы вошли под: {user.PostUser.ToString()}");
            LoadForm(user.PostUser.ToString(), user);
        }
        private void LoadForm(string Role, UserSystem user)
        {
            switch (Role) //В зависимости от роли переходим на соответсвующую странцу
            {
                case "Заказчик":
                    NavigationService.Navigate(new CustomerPanel(user));
                    break;
                case "Дизайнер":
                    NavigationService.Navigate(new CustomerPanel(user));
                    break;
                case "Сотрудник отдела кадров":
                    NavigationService.Navigate(new HRDepartmentEmployee(user));
                    break;
                case "Поставщик":
                    NavigationService.Navigate(new Suppliner(user));
                    break;
                case "Швея":
                    NavigationService.Navigate(new CustomerPanel(user));
                    break;
                case "Раскройщик":
                    NavigationService.Navigate(new CustomerPanel(user));
                    break;
                case "Работник склада":
                    NavigationService.Navigate(new Workermaterial(user));
                    break;
            }
        }

        private void btnRegistr_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistCustomer());
        }
    }
}
