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
    /// Логика взаимодействия для EditCountMaterial.xaml
    /// </summary>
    public partial class EditCountMaterial : Page
    {
        public List<Shipment> ship = new List<Shipment>();
        public EditCountMaterial(List<Shipment> shipments)
        {
            InitializeComponent();
            ship = shipments;
            LViewMaterials.ItemsSource = shipments;
        }

        private void btnCreatepostavka_Click(object sender, RoutedEventArgs e)
        {
            foreach(var item in ship)
            {
                AtelerEntityes.GetContext().Shipment.Add(item);
            }
            AtelerEntityes.GetContext().SaveChanges();
        }

        private void Minus1_Click(object sender, RoutedEventArgs e)
        {
            var selected = LViewMaterials.SelectedItems.Cast<Shipment>().ToArray();
            foreach (var item in selected)
            {
                if (item.CountMaterial >= 0)
                {
                    ship.Remove(item);
                    item.CountMaterial--;
                    ship.Add(item);
                    LViewMaterials.ItemsSource = null;
                    LViewMaterials.ItemsSource = ship;
                }
                else
                    MessageBox.Show("Нельзя указать орицательное количество материала!");
            }
        }

        private void Minus10_Click(object sender, RoutedEventArgs e)
        {
            var selected = LViewMaterials.SelectedItems.Cast<Shipment>().ToArray();
            foreach (var item in selected)
            {
                if (item.CountMaterial >= 0)
                {
                    ship.Remove(item);
                    if (item.CountMaterial - 10 >= 0)
                        item.CountMaterial = item.CountMaterial - 10;
                    else
                        MessageBox.Show("Нельзя заказать отрицательное количество товара!");
                    ship.Add(item);
                    LViewMaterials.ItemsSource = null;
                    LViewMaterials.ItemsSource = ship;
                }
                else
                    MessageBox.Show("Нельзя заказать отрицательное количество товара!");
            }
        }

        private void Minus100_Click(object sender, RoutedEventArgs e)
        {
            var selected = LViewMaterials.SelectedItems.Cast<Shipment>().ToArray();
            foreach (var item in selected)
            {
                if (item.CountMaterial >= 0)
                {
                    ship.Remove(item);
                    if (item.CountMaterial - 100 >= 0)
                        item.CountMaterial = item.CountMaterial - 100;
                    else
                        MessageBox.Show("Нельзя заказать отрицательное количество товара!");
                    ship.Add(item);
                    LViewMaterials.ItemsSource = null;
                    LViewMaterials.ItemsSource = ship;
                }
                else
                    MessageBox.Show("Нельзя заказать отрицательное количество товара!");
            }
        }

        private void Plus1_Click(object sender, RoutedEventArgs e)
        {
            var selected = LViewMaterials.SelectedItems.Cast<Shipment>().ToArray();
            foreach (var item in selected)
            {
                ship.Remove(item);
                item.CountMaterial++;
                ship.Add(item);
                LViewMaterials.ItemsSource = null;
                LViewMaterials.ItemsSource = ship;
            }
        }

        private void Plus10_Click(object sender, RoutedEventArgs e)
        {
            var selected = LViewMaterials.SelectedItems.Cast<Shipment>().ToArray();
            foreach (var item in selected)
            {
                ship.Remove(item);
                item.CountMaterial = item.CountMaterial + 10;
                ship.Add(item);
                LViewMaterials.ItemsSource = null;
                LViewMaterials.ItemsSource = ship;
            }
        }

        private void Plus100_Click(object sender, RoutedEventArgs e)
        {
            var selected = LViewMaterials.SelectedItems.Cast<Shipment>().ToArray();
            foreach (var item in selected)
            {
                ship.Remove(item);
                item.CountMaterial = item.CountMaterial + 100;
                ship.Add(item);
                LViewMaterials.ItemsSource = null;
                LViewMaterials.ItemsSource = ship;
            }
        }
    }
}
