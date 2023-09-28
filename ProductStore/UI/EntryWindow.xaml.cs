using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProductStore.UI;
using System.Windows;
using ProductStore.DBEntities;
using ProductStore.UC;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProductStore.UI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class EntryWindow : Window
    {
        public EntryWindow()
        {
            InitializeComponent();
            var allTypes = ProductStoreEntities.GetContext().Types.ToList();
            allTypes.Insert(0, new DBEntities.Type
            {
                Name = "Все типы"
            }
            );
            cmbBoxGoodsType.ItemsSource = allTypes;
            UpdateSource();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void UpdateSource()
        {
            var currentSource = ProductStoreEntities.GetContext().Goods.ToList();

            currentSource = currentSource.Where(p => p.Name.ToLower().Contains(txtBoxSearch.Text.ToLower())).ToList();

            if (cmbBoxGoodsType.SelectedIndex == 0)
            {

            }
            if (cmbBoxGoodsType.SelectedIndex >= 1)
                currentSource = currentSource.Where(p => p.IdType.Equals(cmbBoxGoodsType.SelectedIndex)).ToList();

            Goods3.Goods2.ItemsSource = currentSource;
        }
        private void txtBoxSearch_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            UpdateSource();
        }

        private void cmbBoxGoodsType_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            UpdateSource();
        }
    }
}
