using BusinessObject;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WPFApp
{
    public partial class ProductWindow : Window
    {
        ProductService productService;

        public ProductWindow()
        {
            InitializeComponent();
            productService = new ProductService();
            DisplayAllProducts();
        }

        private void DisplayAllProducts()
        {
            List<Products> products = productService.GetAllProducts();
            lvProducts.ItemsSource = products;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var product = new Products
            {
                ProductName = txtProductName.Text,
                SupplierID = int.Parse(txtSupplierID.Text),
                CategoryID = int.Parse(txtCategoryID.Text),
                QuantityPerUnit = txtQuantityPerUnit.Text,
                UnitPrice = decimal.Parse(txtUnitPrice.Text),
                UnitsInStock = int.Parse(txtUnitsInStock.Text),
                UnitsOnOrder = int.Parse(txtUnitsOnOrder.Text),
                ReorderLevel = int.Parse(txtReorderLevel.Text),
                Discontinued = chkDiscontinued.IsChecked == true
            };

            productService.AddProducts(product);
            DisplayAllProducts();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = lvProducts.SelectedItem as Products;
            if (selectedProduct == null)
            {
                MessageBox.Show("Please select a product to edit.");
                return;
            }

            // Cập nhật thông tin
            selectedProduct.ProductName = txtProductName.Text;
            selectedProduct.SupplierID = int.Parse(txtSupplierID.Text);
            selectedProduct.CategoryID = int.Parse(txtCategoryID.Text);
            selectedProduct.QuantityPerUnit = txtQuantityPerUnit.Text;
            selectedProduct.UnitPrice = decimal.Parse(txtUnitPrice.Text);
            selectedProduct.UnitsInStock = int.Parse(txtUnitsInStock.Text);
            selectedProduct.UnitsOnOrder = int.Parse(txtUnitsOnOrder.Text);
            selectedProduct.ReorderLevel = int.Parse(txtReorderLevel.Text);
            selectedProduct.Discontinued = chkDiscontinued.IsChecked == true;

            productService.UpdateProducts(selectedProduct);
            DisplayAllProducts();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = lvProducts.SelectedItem as Products;
            if (selectedProduct == null)
            {
                MessageBox.Show("Please select a product to delete.");
                return;
            }

            int productId = selectedProduct.ProductID;

            if (MessageBox.Show("Are you sure you want to delete this product?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    productService.DeleteProducts(productId);
                    MessageBox.Show("Product deleted successfully.");
                    DisplayAllProducts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cannot delete product. It may be referenced in orders.\n" + ex.Message,
                        "Delete Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            string keyword = txtSearch.Text.ToLower();

            var allProducts = productService.GetAllProducts();

            var result = allProducts
                .Where(p => p.ProductName != null && p.ProductName.ToLower().Contains(keyword))
                .ToList();

            lvProducts.ItemsSource = result;
        }
    }
}
