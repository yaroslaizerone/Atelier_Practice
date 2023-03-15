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
    /// Логика взаимодействия для RegistCustomer.xaml
    /// </summary>
    public partial class RegistCustomer : Page
    {
        public RegistCustomer()
        {
            InitializeComponent();
        }


        private void btnRegist_Click(object sender, RoutedEventArgs e)
        {
            CheckTextbox();
        }
        public void CheckTextbox()
        {
            if (tbNameCustomer.Text == "" || tbSurnameCustomer.Text == "" || tbPatronycCustomer.Text == "" || tbPhoneNumber.Text == "" || tbLoginCustomer.Text == "" || tbPasswordCustomer.Text == "" || tbRepitPassword.Text == "")
            {
                MessageBox.Show("Необходимо заполнить все поля!");
            }
            else if (tbPasswordCustomer.Text != tbRepitPassword.Text)
            {
                MessageBox.Show("Введённые пароли не совпадают!");
            }
            else
            {
                try
                {
                    UserSystem adduser = new UserSystem()
                    {
                        ID_User = AtelerEntityes.GetContext().UserSystem.OrderByDescending(x => x.ID_User).First().ID_User + 1,
                        ID_Post = 1,
                        Login = tbLoginCustomer.Text.ToString(),
                        Password = tbPasswordCustomer.Text.ToString()
                    };
                    Customer addcust= new Customer() 
                    {
                      ID_Customer = AtelerEntityes.GetContext().Customer.OrderByDescending(x => x.ID_Customer).First().ID_Customer + 1,
                      ID_User= adduser.ID_User,
                      NameCustomer = tbNameCustomer.Text.ToString(),
                      SurnameCustomer = tbSurnameCustomer.Text.ToString(),
                      PatronicCustomer = tbPatronycCustomer.Text.ToString(),
                      PhoneCustomer = tbPhoneNumber.Text.ToString()
                    };
                    AtelerEntityes.GetContext().UserSystem.Add(adduser); //Передаём добавленные данные в таблицу
                    AtelerEntityes.GetContext().Customer.Add(addcust); //Передаём добавленные данные в таблицу
                    AtelerEntityes.GetContext().SaveChanges();//Сохраняем записи в БД
                    MessageBox.Show("Запись успешно добавлена!");
                }
                catch
                {
                    MessageBox.Show("Не удалось добавить пользователя");
                }
            }
        }
    }
}
