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
    /// Логика взаимодействия для HRDepartmentEmployee.xaml
    /// </summary>
    public partial class HRDepartmentEmployee : Page
    {
        public HRDepartmentEmployee(UserSystem userSystem)
        {
            InitializeComponent();
            var Employeers = AtelerEntityes.GetContext().Employee.ToList();
            LViewEmployee.ItemsSource = Employeers;
            Employee EmployeeEditor = AtelerEntityes.GetContext().Employee.Where(x => x.ID_User == userSystem.ID_User).FirstOrDefault();
            textFullName.Text = EmployeeEditor.SurnameEmployee.ToString() + " " + EmployeeEditor.NameEmployee.ToString() + " " + EmployeeEditor.PatronicEmployee.ToString();
        }

        private void btnUpdata_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RowForEmp(LViewEmployee.SelectedItem as Employee, 2));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Employee Emp;
            Emp = LViewEmployee.SelectedItem as Employee;
            if (MessageBox.Show($"Вы действительно хотите удалить сотрудника номер {Emp.ID_Employee}?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {   UserSystem us = AtelerEntityes.GetContext().UserSystem.Where(x=> x.ID_User == Emp.ID_User).FirstOrDefault();
                    AtelerEntityes.GetContext().Employee.Remove(Emp);
                    AtelerEntityes.GetContext().UserSystem.Remove(us);
                    AtelerEntityes.GetContext().SaveChanges();
                    MessageBox.Show("Запись удалена!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                NavigationService.GoBack();
            }
        }

        private void btnCreateEmp_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RowForEmp(null, 1));
        }

        private void btnCreateUser_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RowForEmp(LViewEmployee.SelectedItem as Employee, 3));
        }
    }
}
