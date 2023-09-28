using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ProductStore.DBEntities;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProductStore.UI
{
    /// <summary>
    /// Логика взаимодействия для AddEditWindow.xaml
    /// </summary>
    public partial class AddEditWindow : Window
    {
        private Good currentGood = new Good();
        public AddEditWindow(Good selectedGood)
        {
            InitializeComponent();
            if (selectedGood != null)
                currentGood = selectedGood;
            DataContext = currentGood;
            cmbBoxType.ItemsSource = ProductStoreEntities.GetContext().Types.ToList();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (currentGood.Id == 0)
                ProductStoreEntities.GetContext().Goods.Add(currentGood);
            try
            {
                ProductStoreEntities.GetContext().SaveChanges();
                MessageBox.Show("Сохранено!");
            }
            catch
            {
                MessageBox.Show("При сохранении возникла ошибка!");
            }
        }
    }
}
