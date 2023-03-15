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
    /// Логика взаимодействия для AddMaterial.xaml
    /// </summary>
    public partial class AddMaterial : Page
    {
        public AddMaterial()
        {
            InitializeComponent();
            cmbTypeMat.ItemsSource = AtelerEntityes.GetContext().TypeMaterial.ToList();
            cmbUnit.ItemsSource = AtelerEntityes.GetContext().Uints.ToList();
        }

        private void SaveMaterial_Click(object sender, RoutedEventArgs e)
        {
            if(cmbTypeMat.SelectedIndex == -1 || cmbUnit.SelectedIndex == -1 || tbCostOfUnit.Text == "" || tbGarant.Text == "" || tbNameMat.Text == "")
            {
                MessageBox.Show("Не все поля заполнены!");
            }
            else
            {
                Materials materials = new Materials()
                {
                    ID_Materials = AtelerEntityes.GetContext().Materials.OrderByDescending(x => x.ID_Materials).First().ID_Materials + 1,
                    ID_Unit = cmbUnit.SelectedIndex + 1,
                    ID_TypeMaterial = cmbTypeMat.SelectedIndex + 1,
                    NameMaterial = tbNameMat.Text,
                    Warranty = tbGarant.Text,
                    CostOfUnit = Convert.ToDecimal(tbCostOfUnit.Text),
                    CountOnStok = 0
                };
                AtelerEntityes.GetContext().Materials.Add(materials); //Передаём добавленные данные в таблицу
                AtelerEntityes.GetContext().SaveChanges();//Сохраняем записи в БД
                MessageBox.Show("Новый материал добавлен в систему!");
            }
        }
    }
}
