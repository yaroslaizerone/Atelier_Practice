using Microsoft.Win32;
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
    /// Логика взаимодействия для WorkVikroi.xaml
    /// </summary>
    public partial class WorkVikroi : Page
    {
        public WorkVikroi()
        {
            InitializeComponent();
        }

        private void btnChengeVikrou_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Окно для выбора раскройки");
            OpenFileDialog GetImageDialog = new OpenFileDialog(); // Открытие диалогового окна
            GetImageDialog.Filter = "Файлы изображений: (*.png,*.jpg,*.jpeg)| *.png;*.jpg;*.jpeg"; // Фильтр типов файлов
            GetImageDialog.InitialDirectory = "F:\\ярослав\\коды\\еу\\Atelier_Practice\\Atelier_Practice\\Resource\\"; // Путь к папке ресурсов проекта
        }

        private void btnAddVikrou_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Окно для добавления раскройки");
            OpenFileDialog GetImageDialog = new OpenFileDialog(); // Открытие диалогового окна
            GetImageDialog.Filter = "Файлы изображений: (*.png,*.jpg,*.jpeg)| *.png;*.jpg;*.jpeg"; // Фильтр типов файлов
            GetImageDialog.InitialDirectory = "C:\\Users\\kolpa\\OneDrive"; // Путь к папке ресурсов проекта
        }
    }
}
