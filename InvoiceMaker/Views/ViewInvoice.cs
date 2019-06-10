using MySql.Data.MySqlClient;
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
using Dapper;

namespace InvoiceMaker
{
    public partial class ViewInvoice : Form
    {
        ListView pickingListView = new ListView();
        List<Invoice> pickingList;
       
        
        public ViewInvoice()
        {
            InitializeComponent();
            SetupLists();
            SetupMenu();
            if (pickingListView.Items.Count != 0)
            {
                 pickingListView.EnsureVisible(pickingListView.Items.Count - 1);
            }
        }

        private void viewInvoice_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Selecting OK will close the InvoiceMaker program. Select OK to exit.", "EXIT", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void SetupMenu()
        {
            ToolStripMenuItem submenu;
            var menuStrip = new MenuStrip();
            menuStrip.Location = new Point(0, 0);

            var menuExcel = new ToolStripMenuItem();
            menuStrip.Items.Add(menuExcel);
            menuExcel.Name = "Excel";
            menuExcel.Text = "Excel";
            submenu = new ToolStripMenuItem();
            submenu.Name = "Read Excel";
            submenu.Text = "Read Excel";
            submenu.Click += delegate (Object o, EventArgs e)
            {
                ReadProduct readProduct = new ReadProduct();
                readProduct.Show();
            };
            menuExcel.DropDownItems.Add(submenu);


            var menuTaxes = new ToolStripMenuItem();
            menuStrip.Items.Add(menuTaxes);
            menuTaxes.Name = "Taxes";
            menuTaxes.Text = "Taxes";
            menuTaxes.Click += delegate (Object o, EventArgs e)
            {
                ProvinceTaxesForm provinceTaxesForm = new ProvinceTaxesForm();
                provinceTaxesForm.Size = new System.Drawing.Size(300, 500);
                provinceTaxesForm.Show();
            };

            
            
            var menuProducts = new ToolStripMenuItem();
            menuStrip.Items.Add(menuProducts);
            menuProducts.Name = "Products";
            menuProducts.Text = "Products";
            submenu = new ToolStripMenuItem();
            submenu.Name = "Add";
            submenu.Text = "Add";
            submenu.Click += delegate (Object o, EventArgs e)
            {
                ProductForm productForm = new ProductForm();
                productForm.Font = new Font(productForm.Font.Name, productForm.Font.Size + 1, productForm.Font.Style);
                productForm.Show();
            };
            menuProducts.DropDownItems.Add(submenu);
            submenu = new ToolStripMenuItem();
            submenu.Name = "View";
            submenu.Text = "View";
            submenu.Click += delegate (Object o, EventArgs e)
            {
                ViewProduct viewProduct = new ViewProduct();
                viewProduct.Size = new System.Drawing.Size(1000, 700);
                viewProduct.Show();
            };
            menuProducts.DropDownItems.Add(submenu);

            var menuCustomer = new ToolStripMenuItem();
            menuStrip.Items.Add(menuCustomer);
            menuCustomer.Name = "Customers";
            menuCustomer.Text = "Customers";
            submenu = new ToolStripMenuItem();
            submenu.Name = "Add";
            submenu.Text = "Add";
            submenu.Click += delegate (Object o, EventArgs e)
            {
                CustomerForm customerForm = new CustomerForm();
                customerForm.Size = new System.Drawing.Size(460, 500);
                customerForm.Font = new Font(customerForm.Font.Name, customerForm.Font.Size + 1, customerForm.Font.Style);
                customerForm.Show();
            };
            menuCustomer.DropDownItems.Add(submenu);
            submenu = new ToolStripMenuItem();
            submenu.Name = "View";
            submenu.Text = "View";
            submenu.Click += delegate (Object o, EventArgs e)
            {
                ViewCustomer viewCustomer = new ViewCustomer();
                viewCustomer.Size = new System.Drawing.Size(1300, 700);
                viewCustomer.Show();
            };
            menuCustomer.DropDownItems.Add(submenu);

            var menuInvoice = new ToolStripMenuItem();
            menuStrip.Items.Add(menuInvoice);
            menuInvoice.Name = "CreateInvoice";
            menuInvoice.Text = "CreateInvoice";
            submenu = new ToolStripMenuItem();
            submenu.Name = "New";
            submenu.Text = "New";
            submenu.Click += delegate (Object o, EventArgs e)
            {
                SelectCustomer selectCustomer = new SelectCustomer();
                selectCustomer.Size = new System.Drawing.Size(1300, 700);
                selectCustomer.Show();
            };
            menuInvoice.DropDownItems.Add(submenu);

            var menuNotes = new ToolStripMenuItem();
            menuStrip.Items.Add(menuNotes);
            menuNotes.Name = "InvoiceNote";
            menuNotes.Text = "InvoiceNote";
            submenu = new ToolStripMenuItem();
            submenu.Name = "Update";
            submenu.Text = "Update";
            submenu.Click += delegate (Object o, EventArgs e)
            {
                InvoiceNoteForm invoiceNoteForm = new InvoiceNoteForm();
                invoiceNoteForm.Size = new System.Drawing.Size(300, 130);
                invoiceNoteForm.Show();
            };
            menuNotes.DropDownItems.Add(submenu);
            this.Controls.Add(menuStrip);
        }

       

        private void SetupLists()
        {
            Label pickingLabel = new System.Windows.Forms.Label();
            pickingLabel.AutoSize = true;
            pickingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            pickingLabel.Location = new System.Drawing.Point(210, 95);
            pickingLabel.Size = new System.Drawing.Size(238, 42);
            pickingLabel.TabIndex = 0;
            pickingLabel.Text = "INVOICES";
            this.Controls.Add(pickingLabel);

            pickingListView.Size = new Size(500, 450);
            pickingListView.Location = new Point(50, 120);

            pickingListView.Columns.Add("Local Invoice ID", -2, HorizontalAlignment.Left);
            pickingListView.Columns.Add("Customer Name", 200, HorizontalAlignment.Left);
            pickingListView.Columns.Add("Shipping Address", 200, HorizontalAlignment.Left);

            pickingListView.GridLines = true;
            pickingListView.Scrollable = true;
            pickingListView.FullRowSelect = true;
            pickingListView.View = System.Windows.Forms.View.Details;
            pickingListView.DoubleClick += PickingListView_DoubleClick;
            pickingListView.Enter += PickingListView_Enter;
            this.Controls.Add(pickingListView);
            
         
            Button refreshButton = new Button();
            refreshButton.Location = new Point(50, 60);
            refreshButton.Size = new Size(70, 40);
            refreshButton.Text = "Refresh";
            refreshButton.Click += RefreshButton_Click;
            this.Controls.Add(refreshButton);


            Button deleteButton = new Button();
            deleteButton.Location = new Point(225, 600);
            deleteButton.Size = new Size(70, 40);
            deleteButton.Text = "Delete";
            deleteButton.Click += DeleteButton_Click;
            this.Controls.Add(deleteButton);


            Button printButton = new Button();
            printButton.Location = new Point(305, 600);
            printButton.Size = new Size(60, 40);
            printButton.Text = "Print";
            printButton.Click += PrintButton_Click;
            this.Controls.Add(printButton);

            pickingList = InvoiceDatabase.GetAllInvoices();
            
            foreach (Invoice l in pickingList)
            {
                pickingListView.Items.Add(new ListViewItem(new String[] { l.InvoiceID.ToString(), l.customer.StoreName, l.customer.StreetAddress}));
            }
        }


        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RefreshView();
        }


        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (pickingListView.SelectedItems.Count > 0)
            {
                var confirmResult = MessageBox.Show("Are you sure to delete this invoice?",
                                     "Confirm Delete!",
                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    foreach (ListViewItem l in pickingListView.SelectedItems)
                    {
                        InvoiceDatabase.DeleteInvoice(Int32.Parse(l.SubItems[0].Text));
                    }
                    
                    RefreshView();
                }
                else
                {
                    RefreshView();
                }
            }
            
        }
      

        private void PrintButton_Click(object sender, EventArgs e)
        {    
            foreach (ListViewItem l in pickingListView.SelectedItems)
            {
                Invoice temp = new Invoice(Int32.Parse(l.SubItems[0].Text));
                temp.PrintExcel();
            }
        }

        
        private void PickingListView_Enter(object sender, EventArgs e)
        {
            RefreshView();
        }
        

        private void RefreshView()
        {
            foreach (ListViewItem lvItem in pickingListView.Items)
            {
                pickingListView.Items.Remove(lvItem);
            }
          
            pickingList = InvoiceDatabase.GetAllInvoices();    

            foreach (Invoice l in pickingList)
            {
                pickingListView.Items.Add(new ListViewItem(new String[] { l.InvoiceID.ToString(), l.customer.StoreName, l.customer.StreetAddress }));
            } 

            pickingListView.Columns[2].Width = 180;
            if (pickingListView.Items.Count != 0)
            {
                pickingListView.EnsureVisible(pickingListView.Items.Count - 1);
            }
        }
       

        private void PickingListView_DoubleClick(object sender, EventArgs e)
        {
            Invoice temp = new Invoice(Int32.Parse(pickingListView.SelectedItems[0].SubItems[0].Text));
            temp.PrintExcel();   
        }

        private void ViewInvoice_Load(object sender, EventArgs e)
        {

        }
    }
}
