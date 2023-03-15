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
    /// Логика взаимодействия для Workermaterial.xaml
    /// </summary>
    public partial class Workermaterial : Page
    {
        List<Materials> materialsList = new List<Materials>();
        public Workermaterial(UserSystem userSystem)
        {
            InitializeComponent();
            LViewMaterials.ItemsSource = AtelerEntityes.GetContext().Materials.ToList();
            materialsList = AtelerEntityes.GetContext().Materials.ToList();
            if (userSystem.ID_Post == 6)
            {
                btnAddMaterial.Visibility = Visibility.Hidden;
            }
        }


        private void Minus1_Click(object sender, RoutedEventArgs e)
        {
            var selected = LViewMaterials.SelectedItems.Cast<Materials>().ToArray();
            foreach (Materials item in selected)
            {
                if (item.CountOnStok >= 0)
                {
                    materialsList.Remove(item);
                    item.CountOnStok--;
                    materialsList.Add(item);
                    LViewMaterials.ItemsSource = null;
                    LViewMaterials.ItemsSource = materialsList;
                }
                else
                    MessageBox.Show("Нельзя указать орицательное количество материала!");
            }
        }

        private void Minus10_Click(object sender, RoutedEventArgs e)
        {
            var selected = LViewMaterials.SelectedItems.Cast<Materials>().ToArray();
            foreach (Materials item in selected)
            {
                if (item.CountOnStok >= 0)
                {
                    materialsList.Remove(item);
                    if (item.CountOnStok - 10 >= 0)
                        item.CountOnStok = item.CountOnStok - 10;
                    else
                        MessageBox.Show("Нельзя заказать отрицательное количество товара!");
                    materialsList.Add(item);
                    LViewMaterials.ItemsSource = null;
                    LViewMaterials.ItemsSource = materialsList;
                }
                else
                    MessageBox.Show("Нельзя заказать отрицательное количество товара!");
            }
        }
        private void Minus100_Click(object sender, RoutedEventArgs e)
        {
            var selected = LViewMaterials.SelectedItems.Cast<Materials>().ToArray();
            foreach (Materials item in selected)
            {
                if (item.CountOnStok >= 0)
                {
                    materialsList.Remove(item);
                    if (item.CountOnStok - 100 >= 0)
                        item.CountOnStok = item.CountOnStok - 100;
                    else
                        MessageBox.Show("Нельзя указать орицательное количество материала!");
                    materialsList.Add(item);
                    LViewMaterials.ItemsSource = null;
                    LViewMaterials.ItemsSource = materialsList;
                }
                else
                    MessageBox.Show("Нельзя указать орицательное количество материала!");
            }
        }

        private void Plus1_Click(object sender, RoutedEventArgs e)
        {
            var selected = LViewMaterials.SelectedItems.Cast<Materials>().ToArray();
            foreach (Materials item in selected)
            {
                materialsList.Remove(item);
                item.CountOnStok++;
                materialsList.Add(item);
                LViewMaterials.ItemsSource = null;
                LViewMaterials.ItemsSource = materialsList;
            }
        }
        private void Plus10_Click(object sender, RoutedEventArgs e)
        {
            var selected = LViewMaterials.SelectedItems.Cast<Materials>().ToArray();
            foreach (Materials item in selected)
            {
                materialsList.Remove(item);
                item.CountOnStok= item.CountOnStok + 10;
                materialsList.Add(item);
                LViewMaterials.ItemsSource = null;
                LViewMaterials.ItemsSource = materialsList;
            }
        }

        private void Plus100_Click(object sender, RoutedEventArgs e)
        {
            var selected = LViewMaterials.SelectedItems.Cast<Materials>().ToArray();
            foreach (Materials item in selected)
            {
                materialsList.Remove(item);
                item.CountOnStok = item.CountOnStok + 100;
                materialsList.Add(item);
                LViewMaterials.ItemsSource = null;
                LViewMaterials.ItemsSource = materialsList;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in materialsList)
            {
                AtelerEntityes.GetContext().SaveChanges();         
            }
            MessageBox.Show("Изменения применены!");
        }

        private void btnAddMaterial_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddMaterial());
        }
    }
}
