using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для RowForEmp.xaml
    /// </summary>
    public partial class RowForEmp : Page
    {
        public int access;
        public Employee Tempemployee;
        public RowForEmp(Employee employee, int i)
        {
            InitializeComponent();
            DataContext = employee;
            Tempemployee = employee;
            access = i;
            cmbPost.ItemsSource = AtelerEntityes.GetContext().Post.ToList();
            try
            {
                if (employee != null)
                {
                    cmbPost.SelectedIndex = employee.IdPost - 1;
                    tbLogin.Text = employee.LoginUser;
                    tbPassword.Text = employee.PasswordUser;
                    tbName.Text = employee.NameEmployee;
                    tbSurname.Text = employee.SurnameEmployee;
                    tbMidlename.Text = employee.PatronicEmployee;
                    tbPasport.Text = employee.PasportData;
                    tbHome.Text = employee.AddresEmployee;
                    tbDateBith.Text = employee.Datebirth;
                    tbPhone.Text = employee.PhoneNumber;
                    switch (i)
                    {
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            cmbPost.IsReadOnly = true;
                            tbName.IsReadOnly = true;
                            tbSurname.IsReadOnly = true;
                            tbMidlename.IsReadOnly = true;
                            tbPasport.IsReadOnly = true;
                            tbHome.IsReadOnly = true;
                            tbDateBith.IsReadOnly = true;
                            tbPhone.IsReadOnly = true;
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (access == 1)
                {
                    UserSystem adduser = new UserSystem()
                    {
                        ID_User = AtelerEntityes.GetContext().UserSystem.OrderByDescending(x => x.ID_User).First().ID_User + 1,
                        ID_Post = cmbPost.SelectedIndex + 1,
                        Login = tbLogin.Text.ToString(),
                        Password = tbPassword.Text.ToString()
                    };
                    Employee addEmoloyee = new Employee()
                    {
                        ID_Employee = AtelerEntityes.GetContext().Employee.OrderByDescending(x => x.ID_Employee).First().ID_Employee + 1,
                        ID_User = adduser.ID_User,
                        SurnameEmployee = tbSurname.Text,
                        NameEmployee = tbName.Text,
                        PatronicEmployee = tbMidlename.Text,
                        PhoneNumber = tbPhone.Text,
                        PasportData = tbPasport.Text,
                        AddresEmployee = tbHome.Text,
                        Datebirth = tbDateBith.Text
                    };
                    AtelerEntityes.GetContext().UserSystem.Add(adduser);
                    AtelerEntityes.GetContext().Employee.Add(addEmoloyee);
                    AtelerEntityes.GetContext().SaveChanges();
                    MessageBox.Show("Запись успешно добавленна!");
                }
                else if (access == 2)
                {
                    UserSystem user = new UserSystem();
                    user = AtelerEntityes.GetContext().UserSystem.Where(x => x.ID_User == Tempemployee.ID_User).FirstOrDefault();
                    user.ID_Post = cmbPost.SelectedIndex + 1;
                    user.Login = tbLogin.Text;
                    user.Password = tbPassword.Text;
                    Tempemployee.SurnameEmployee = tbSurname.Text;
                    Tempemployee.NameEmployee = tbName.Text;
                    Tempemployee.PatronicEmployee = tbMidlename.Text;
                    Tempemployee.PhoneNumber = tbPhone.Text;
                    Tempemployee.PasportData = tbPasport.Text;
                    Tempemployee.AddresEmployee = tbHome.Text;
                    Tempemployee.Datebirth = tbDateBith.Text;
                    AtelerEntityes.GetContext().SaveChanges();
                    MessageBox.Show("Запись успешно изменена!");
                }
                else
                {
                    UserSystem adduser = AtelerEntityes.GetContext().UserSystem.Where(x => x.ID_User == Tempemployee.ID_User).FirstOrDefault();
                    adduser.ID_Post = cmbPost.SelectedIndex + 1;
                    adduser.Login = tbLogin.Text.ToString();
                    adduser.Password = tbPassword.Text.ToString();
                    AtelerEntityes.GetContext().SaveChanges();
                    MessageBox.Show("Запись успешно добавленна!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString()); 
            }     
        }
    }
}
