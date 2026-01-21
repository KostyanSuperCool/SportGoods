using Microsoft.EntityFrameworkCore;
using SportGoods.NewFolder1;
using SportGoods.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SportGoods
{
    public partial class FormProducts : Form
    {
        public User CurrentUser { get; private set; }

        public bool IsGuest { get; private set; }



        public FormProducts(User user, bool guest)
        {
            InitializeComponent();

            var colPhoto = new DataGridViewImageColumn();
            colPhoto.Name = "colPhoto";
            colPhoto.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colPhoto.Width = 200;
            colPhoto.FillWeight = 30;

            var colInfo = new DataGridViewImageColumn();
            colInfo.Name = "colInfo";
            colInfo.FillWeight = 60;
            colInfo.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            var colDiscount = new DataGridViewImageColumn();
            colDiscount.Name = "colDiscount";
            colDiscount.FillWeight = 10;
            colDiscount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvProducts.Columns.AddRange(
            [
                colPhoto, colInfo, colDiscount
            ]);

            CurrentUser = user;
            IsGuest = guest;

            lblUserName.Text = IsGuest ? "Гость" : CurrentUser.UserName;

            LoadProducts();
        }

        private void LoadProducts()
        {
            try
            {
                using (var db = new ShopSportingKiselevContext())
                {
                    var products = db.Products
                        .Include(i => i.CategoryProduct)
                        .Include(i => i.Manufacturer)
                        .Include(i => i.Supplier)
                        .Include(i => i.UnitOfMeasurement)
                        .ToList();

                    dgvProducts.SuspendLayout();
                    dgvProducts.Rows.Clear();

                    foreach (var product in products)
                    {
                        int rowIndex = dgvProducts.Rows.Count;
                        var row = dgvProducts.Rows[rowIndex];

                        row.Cells["colPhoto"].Value = LoadProductImage(product.Image);

                        row.Cells["colInfo"].Value = FormatProductInfo(product);

                        row.Cells["colDiscount"].Value = $"{product.Discount}";
                        row.Cells["colDiscount"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        ApplyRowStyles(row, product);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void ApplyRowStyles(DataGridViewRow row, Product product)
        {
            if (product.Discount > 15)
            {
                row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("");
            }
        }

        private string FormatProductInfo(Product product)
        {
            string priceText;

            if(product.Discount>0)
            {
                decimal finalPrice = product.Price * (100 - product.Discount) / 100;
                priceText = $"Цена: {product.Price:C}->{finalPrice}";
            }
            else
            {
                priceText = $"Цена: {product.Price:C}";
            }

            return $"{product.CategoryProduct.Category} | {product.ProductName}" + Environment.NewLine +
                $"Описание товара: {product.Description}" + Environment.NewLine +
                $"Производитель: {product.Manufacturer.ManufacturerProduct}" + Environment.NewLine +
                $"Поставщик: {product.Supplier.SupplierProduct}" + Environment.NewLine +
                $"Цена: {product.Price}" + Environment.NewLine +
                $"Единица измерения: {product.UnitOfMeasurement}" + Environment.NewLine +
                $"Количетсво на складе: {product.CountOnStock}";
        }

        private Image LoadProductImage(string photoUrl)
        {
            if(!String.IsNullOrEmpty(photoUrl) && System.IO.File.Exists(photoUrl))
            {
                return Image.FromFile(photoUrl);
            }

            return Resources.picture;
        }
    }
}
