using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProductStore.DBEntities;
using System.Windows;
using System.Windows.Controls;
using ProductStore.UC;
using ProductStore.UI;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProductStore.UI
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            var allTypes = ProductStoreEntities.GetContext().Types.ToList();
            allTypes.Insert(0, new DBEntities.Type
            {
                Name = "Все типы"
            });
            cmbBoxGoodsType.ItemsSource = allTypes;
            UpdateSource();
        }

        private void UpdateSource()
        {
            var currentSource = ProductStoreEntities.GetContext().Goods.ToList();

            currentSource = currentSource.Where(p => p.Name.ToLower().Contains(txtBoxSearch.Text.ToLower())).ToList();

            if (cmbBoxGoodsType.SelectedIndex == 0)
                currentSource = currentSource;

            if (cmbBoxGoodsType.SelectedIndex >= 1)
                currentSource = currentSource.Where(p => p.IdType.Equals(cmbBoxGoodsType.SelectedIndex)).ToList();

            Goods3.Goods2.ItemsSource = currentSource;

        }

        private void cmbBoxGoodsType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateSource();
        }

        private void txtBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateSource();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Good goodForRemove = Goods3.Goods2.SelectedItem as Good;
            try
            {
                ProductStoreEntities.GetContext().Goods.Remove(goodForRemove);
                ProductStoreEntities.GetContext().SaveChanges();
                UpdateSource();
            }
            catch
            {
                MessageBox.Show("Ошибка при удалении");
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Good selectedGood = Goods3.Goods2.SelectedItem as Good;
            if(selectedGood == null)
            {
                MessageBox.Show("Проеб");
                return;
            }
            AddEditWindow addEditWindow = new AddEditWindow(selectedGood);
            addEditWindow.ShowDialog();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEditWindow addEditWindow = new AddEditWindow(null);
            addEditWindow.ShowDialog();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
