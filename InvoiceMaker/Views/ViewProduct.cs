using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoiceMaker
{
    public partial class ViewProduct : Form
    {
        ListView productList = new ListView();

        public ViewProduct()
        {
            InitializeComponent();
            AddButtons();
            productList.Size = new Size(900, 500);
            productList.Location = new Point(50, 100);
            
            productList.Columns.Add("Item Number", 80, HorizontalAlignment.Left);
            productList.Columns.Add("Description", 275, HorizontalAlignment.Left);
            productList.Columns.Add("Carton Pack", -2, HorizontalAlignment.Left);
            productList.Columns.Add("Warehouse Location", -2, HorizontalAlignment.Left);
            productList.Columns.Add("Cost", 80, HorizontalAlignment.Left);
            productList.Columns.Add("Selling Price", 80, HorizontalAlignment.Left);
            productList.Columns.Add("UPC", -2, HorizontalAlignment.Left);
            productList.Columns.Add("Special Note", -2, HorizontalAlignment.Left);

            productList.GridLines = true;
            productList.Scrollable = true;
            productList.FullRowSelect = true;
            productList.View = System.Windows.Forms.View.Details;
            productList.DoubleClick += ProductList_DoubleClick;

            this.Controls.Add(productList);

            List<Product> list = ProductDatabase.SearchProductsByItemNo("");
            foreach (Product p in list)
            {
                productList.Items.Add(new ListViewItem(new String[] { p.ItemNo, p.ItemDesc, p.PerCarton.ToString(), p.Location, p.Cost.ToString("0.00"), p.SellPrice.ToString("0.00"), p.UPC.ToString(), p.SpecialNotes }));
            }
        }

        private void ProductList_UpdateRow(int rowIndex, String itemNo)
        {
            Product prod = ProductDatabase.SearchProductByItemNo(itemNo);
            productList.Items.RemoveAt(rowIndex);
            productList.Items.Insert(rowIndex, new ListViewItem(new String[] { prod.ItemNo, prod.ItemDesc, prod.PerCarton.ToString(), prod.Location, prod.Cost.ToString("0.00"), prod.SellPrice.ToString("0.00"), prod.UPC.ToString(), prod.SpecialNotes }));
        }

        private void ProductList_DoubleClick(object sender, EventArgs e)
        {
            //MessageBox.Show(productList.SelectedItems[0].SubItems[0].Text);
            ProductForm productForm = new ProductForm(productList.SelectedItems[0].SubItems[0].Text,
                productList.SelectedItems[0].SubItems[1].Text,
                productList.SelectedItems[0].SubItems[2].Text,
                productList.SelectedItems[0].SubItems[3].Text,
                productList.SelectedItems[0].SubItems[4].Text, 
                productList.SelectedItems[0].SubItems[5].Text,
                productList.SelectedItems[0].SubItems[6].Text,
                productList.SelectedItems[0].SubItems[7].Text);
            productForm.Font = new Font(productForm.Font.Name, productForm.Font.Size + 1, productForm.Font.Style);
            if (productForm.ShowDialog() == DialogResult.OK)
            {
                //RefreshView();
                ProductList_UpdateRow(productList.SelectedIndices[0], productList.SelectedItems[0].SubItems[0].Text);
            }
        }

        private void CancelProduct_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ModProduct_Click(object sender, EventArgs e)
        {
            Debug.Print("Mod Product");
            if(productList.SelectedItems.Count == 1)
            {
                ProductForm productForm = new ProductForm(productList.SelectedItems[0].SubItems[0].Text,
                    productList.SelectedItems[0].SubItems[1].Text,
                    productList.SelectedItems[0].SubItems[2].Text,
                    productList.SelectedItems[0].SubItems[3].Text,
                    productList.SelectedItems[0].SubItems[4].Text,
                    productList.SelectedItems[0].SubItems[5].Text,
                    productList.SelectedItems[0].SubItems[6].Text,
                    productList.SelectedItems[0].SubItems[7].Text);
                productForm.Font = new Font(productForm.Font.Name, productForm.Font.Size + 1, productForm.Font.Style);
                if( productForm.ShowDialog() == DialogResult.OK)
                {
                    ProductList_UpdateRow(productList.SelectedIndices[0], productList.SelectedItems[0].SubItems[0].Text);
                }
            }
            
        }

        private void DeleteProduct_Click(object sender, EventArgs e)
        {
            if (productList.SelectedItems.Count > 0)
            {
                var confirmResult = MessageBox.Show("Are you sure you want to Delete these item(s)?",
                                                 "Confirm Delete!!",
                                                 MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    foreach (ListViewItem l in productList.SelectedItems)
                    {
                        ProductDatabase.DeleteProductByItemNo(l.SubItems[0].Text);
                    }
                    RefreshView();
                }
                else
                {
                    // If 'No', do something here.
                }
            }
        }

        private void AddButtons()
        {
            // 
            // CancelProduct
            // 
            this.CancelProduct.Location = new System.Drawing.Point(300, 610);
            this.CancelProduct.Name = "CancelProduct";
            this.CancelProduct.Size = new System.Drawing.Size(100, 30);
            this.CancelProduct.TabIndex = 8;
            this.CancelProduct.Text = "Cancel";
            this.CancelProduct.UseVisualStyleBackColor = true;
            this.CancelProduct.Click += new System.EventHandler(this.CancelProduct_Click);
            // 
            // ModProduct
            // 
            this.ModProduct.Location = new System.Drawing.Point(450, 610);
            this.ModProduct.Name = "ModProduct";
            this.ModProduct.Size = new System.Drawing.Size(100, 30);
            this.ModProduct.TabIndex = 6;
            this.ModProduct.Text = "Modify";
            this.ModProduct.UseVisualStyleBackColor = true;
            this.ModProduct.Click += new System.EventHandler(this.ModProduct_Click);
            // 
            // DeleteProduct
            // 
            this.DeleteProduct.Location = new System.Drawing.Point(600, 610);
            this.DeleteProduct.Name = "DeleteProduct";
            this.DeleteProduct.Size = new System.Drawing.Size(100, 30);
            this.DeleteProduct.TabIndex = 7;
            this.DeleteProduct.Text = "Delete";
            this.DeleteProduct.UseVisualStyleBackColor = true;
            this.DeleteProduct.Click += new System.EventHandler(this.DeleteProduct_Click);
            
        }

        private void productTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox s = (TextBox)sender;
            if (s.Text.Length >= 3)
            {
                RefreshView();
            }
        }
        

        private void RefreshView()
        {
            foreach (ListViewItem lvItem in productList.Items)
            {
                productList.Items.Remove(lvItem);
            }
            List<Product> list;
            if (productTextBox.Text.Length == 0)
            {
                list = ProductDatabase.SearchProductsByItemNo("");
            }
            else
            {
                list = ProductDatabase.SearchProductsByItemNo(productTextBox.Text);
                list.AddRange(ProductDatabase.SearchProductsByDesc(productTextBox.Text));
                
            }
            foreach (Product p in list)
            {
                productList.Items.Add(new ListViewItem(new String[] { p.ItemNo, p.ItemDesc, p.PerCarton.ToString(), p.Location, p.Cost.ToString("0.00"), p.SellPrice.ToString("0.00"), p.UPC.ToString(), p.SpecialNotes }));
            }
        }

        private void ViewProduct_MouseClick(object sender, MouseEventArgs e)
        {
            RefreshView();
        }
    }
}
