using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoiceMaker
{
    public partial class SelectCustomer : Form
    {
        ListView custList = new ListView();
        Button SelectCustomerButton = new Button();


        public SelectCustomer()
        {
            InitializeComponent();
            AddButtons();
            custList.Size = new Size(1250, 500);
            custList.Location = new Point(25, 100);

            custList.Columns.Add("Store Name", 150, HorizontalAlignment.Left);
            custList.Columns.Add("Store Details", -2, HorizontalAlignment.Left);
            custList.Columns.Add("Store Notes", 120, HorizontalAlignment.Left);
            custList.Columns.Add("Address", 90, HorizontalAlignment.Left);
            custList.Columns.Add("City", 90, HorizontalAlignment.Left);
            custList.Columns.Add("Prov", 40, HorizontalAlignment.Left);
            custList.Columns.Add("Postal Code", 90, HorizontalAlignment.Left);
            custList.Columns.Add("Store Contact", -2, HorizontalAlignment.Left);
            custList.Columns.Add("Email", 100, HorizontalAlignment.Left);
            custList.Columns.Add("Phone Number", 90, HorizontalAlignment.Left);
            custList.Columns.Add("Province Tax", -2, HorizontalAlignment.Left);
            custList.Columns.Add("Payment Terms", -2, HorizontalAlignment.Left);
            custList.Columns.Add("Shipping Instr", -2, HorizontalAlignment.Left);
            custList.Columns.Add("Sales Rep", -2, HorizontalAlignment.Left);

            

            custList.GridLines = true;
            custList.Scrollable = true;
            custList.View = System.Windows.Forms.View.Details;
            custList.DoubleClick += CustomerList_DoubleClick;
            custList.FullRowSelect = true;

            this.Controls.Add(custList);

            List<Customer> list = CustomerDatabase.SearchCustomersByStoreName("");
            foreach (Customer c in list)
            {
                custList.Items.Add(new ListViewItem(new String[] { c.StoreName, c.StoreDetails, c.StoreSpecialNotes, c.StreetAddress, c.CityAddress, c.ProvinceAddress, c.PostalCodeAddress,c.StoreContact,
                c.Email, c.PhoneNumber, c.Province, c.PaymentTerms, c.ShippingInstructions, c.Rep}));
            }

        }

        private void CustomerList_DoubleClick(object sender, EventArgs e)
        {
            int customerID = CustomerDatabase.GetStoreID(custList.SelectedItems[0].Text, custList.SelectedItems[0].SubItems[3].Text);
            InvoiceForm invoiceForm = new InvoiceForm(customerID);
            invoiceForm.Size = new System.Drawing.Size(900, 700);
            invoiceForm.Show();
            this.Close();
            
        }

        private void AddButtons()
        {
            // 
            // SelectCustomer
            // 
            this.SelectCustomerButton.Location = new System.Drawing.Point(550, 610);
            this.SelectCustomerButton.Name = "Select";
            this.SelectCustomerButton.Size = new System.Drawing.Size(100, 30);
            this.SelectCustomerButton.TabIndex = 6;
            this.SelectCustomerButton.Text = "Select";
            this.SelectCustomerButton.UseVisualStyleBackColor = true;
            this.SelectCustomerButton.Click += SelectCustomerButton_Click;
            this.Controls.Add(SelectCustomerButton);

        }


        private void SelectCustomerButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem l in custList.SelectedItems)
            {
                int customerID = CustomerDatabase.GetStoreID(l.SubItems[0].Text, l.SubItems[3].Text);
                InvoiceForm invoiceForm = new InvoiceForm(customerID);
                invoiceForm.Size = new System.Drawing.Size(900, 700);
                invoiceForm.Show();
                this.Close();
            }
            
        }

        private void customerTextBox_TextChanged(object sender, EventArgs e)
        {
            RefreshView();
        }

        private void RefreshView()
        {
            List<Customer> list;

            foreach (ListViewItem lvItem in custList.Items)
            {
                custList.Items.Remove(lvItem);
            }
            if (customerTextBox.Text.Length == 0)
            {
                list = CustomerDatabase.SearchCustomersByStoreName("");
            }
            else
            {
                list = CustomerDatabase.SearchCustomersByStoreName(customerTextBox.Text);
            }
            foreach (Customer c in list)
            {
                custList.Items.Add(new ListViewItem(new String[] { c.StoreName, c.StoreDetails, c.StoreSpecialNotes, c.StreetAddress, c.CityAddress, c.ProvinceAddress, c.PostalCodeAddress,c.StoreContact,
                c.Email, c.PhoneNumber, c.Province, c.PaymentTerms, c.ShippingInstructions, c.Rep}));
            }
        }
    }
}
