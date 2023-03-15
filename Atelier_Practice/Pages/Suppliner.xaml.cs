using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для Suppliner.xaml
    /// </summary>
    public partial class Suppliner : Page
    {
        public List<Materials> materials = new List<Materials>();
        public List<Shipment> shipment = new List<Shipment>();
        public UserSystem useruserSystemuser = new UserSystem();
        public Suppliner(UserSystem userSystem)
        {
            InitializeComponent();
            LViewMaterials.ItemsSource = AtelerEntityes.GetContext().Materials.ToList();
            useruserSystemuser = userSystem;
        }
        private void btnCreatePostavka_Click(object sender, RoutedEventArgs e)
        {   
            var id = AtelerEntityes.GetContext().Suppliner.Where(x => x.ID_User == useruserSystemuser.ID_User).FirstOrDefault();
            foreach(var item in materials)
            {
                shipment.Add(new Shipment { 
                   ID_Materials = item.ID_Materials,
                   ID_Suppliner = Convert.ToInt32(id),
                   DateShipment = dpDateDevel.SelectedDate.Value,
                   CountMaterial = 1
                });
            }
            NavigationService.Navigate(new EditCountMaterial(shipment));
        }

        private void btnAddInSup_Click(object sender, RoutedEventArgs e)
        {
            if(materials.Count() >= 0 && materials.IndexOf(LViewMaterials.SelectedItem as Materials) == -1) // Проверка на наличие повторения в списке
            {
                btnCreatePostavka.Visibility = Visibility.Visible;
                materials.Add(LViewMaterials.SelectedItem as Materials);
            }
            else
            {
                MessageBox.Show("Такой материал уже уже есть в вашей поставке!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
