using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoiceMaker
{
    public partial class InvoiceForm : Form
    {
        Panel panel1 = new Panel();
        int i = 0; //# of current items
        bool PST = false; //pst of customer
        int customerID;
        Customer customer;
        bool finished;

        public InvoiceForm(int customerID)
        {
            InitializeComponent();
            finished = false;
            this.customerID = customerID;
            customer = CustomerDatabase.SearchCustomersByID(customerID);
            ProvinceTax provinceTax = ProvinceTaxDatabase.GetProvinceByName(customer.Province);
            if (provinceTax.pst == 0)
            {
                PST = false;
            }
            else
            {
                PST = true;
            }

            panel1.Location = new Point(30, 145);
            panel1.Size = new Size(800, 330);
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.AutoScroll = true;
            panel1.BackColor = Color.DarkGray;

            this.Controls.Add(panel1);
            AddLabels(customerID);
            AddTotalBoxes(customerID);
            AddFirstRow();

        }

        private void AddLabels(int customerID)
        {
            int x = 30;
            int y = 130;

            Customer cust = CustomerDatabase.SearchCustomersByID(customerID);

            //customer labels
            Label storeNameLabel = new Label();
            if (cust.StoreDetails.Length != 0)
            {
                storeNameLabel.Text = "Store:       " + cust.StoreName + " - " + cust.StoreDetails;
            }
            else
            {
                storeNameLabel.Text = "Store:   " + cust.StoreName;
            }
            storeNameLabel.Location = new Point(30, 10);
            storeNameLabel.AutoSize = true;
            this.Controls.Add(storeNameLabel);

            Label officeLabel = new Label();
            officeLabel.Text = "Address:  " + cust.StreetAddress + " " + cust.CityAddress + ", " + cust.Province + " " + cust.PostalCodeAddress;
            officeLabel.Location = new Point(30, 25);
            officeLabel.AutoSize = true;
            this.Controls.Add(officeLabel);

            Label shippingLabel = new Label();
            shippingLabel.Text = "Notes:      " + cust.StoreSpecialNotes;
            shippingLabel.Location = new Point(30, 40);
            shippingLabel.AutoSize = true;
            this.Controls.Add(shippingLabel);

            Label contactLabel = new Label();
            contactLabel.Text = "Contact:   " + cust.StoreContact;
            contactLabel.Location = new Point(30, 55);
            contactLabel.AutoSize = true;
            this.Controls.Add(contactLabel);

            Label emailLabel = new Label();
            emailLabel.Text = "Email:       " + cust.Email;
            emailLabel.Location = new Point(30, 70);
            emailLabel.AutoSize = true;
            this.Controls.Add(emailLabel);

            Label phoneLabel = new Label();
            phoneLabel.Text = "Phone:     " + cust.PhoneNumber;
            phoneLabel.Location = new Point(30, 85);
            phoneLabel.AutoSize = true;
            this.Controls.Add(phoneLabel);

            
            Label paymentLabel = new Label();
            paymentLabel.Text = "Payment Terms: " + cust.PaymentTerms;
            paymentLabel.Location = new Point(500, 10);
            paymentLabel.AutoSize = true;
            this.Controls.Add(paymentLabel);

            Label shippingInstructionsLabel = new Label();
            shippingInstructionsLabel.Text = "Shipping Instr.:   " + cust.ShippingInstructions;
            shippingInstructionsLabel.Location = new Point(500, 25);
            shippingInstructionsLabel.AutoSize = true;
            this.Controls.Add(shippingInstructionsLabel);


            Label purchaseOrderLabel = new Label();
            purchaseOrderLabel.Text = "PO #:";
            purchaseOrderLabel.Location = new Point(500, 40);
            purchaseOrderLabel.AutoSize = true;
            this.Controls.Add(purchaseOrderLabel);

            TextBox purchaseOrder = new TextBox();
            purchaseOrder.Location = new Point(580, 38);
            purchaseOrder.Size = new Size(100, 25);
            purchaseOrder.Name = "purchaseOrder";
            purchaseOrder.AccessibleName = "purchaseOrder";
            purchaseOrder.KeyPress += Qty_KeyPress;
            this.Controls.Add(purchaseOrder);

            //Invoice column headers
            Label qtyLabel = new Label();
            qtyLabel.Text = "Qty";
            qtyLabel.Location = new Point(x, y);
            qtyLabel.AutoSize = true;
            qtyLabel.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(qtyLabel);

            Label itemNoLabel = new Label();
            itemNoLabel.Text = "Item Number";
            itemNoLabel.Location = new Point(x + 50, y);
            itemNoLabel.AutoSize = true;
            itemNoLabel.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(itemNoLabel);

            Label locLabel = new Label();
            locLabel.Text = "Location";
            locLabel.Location = new Point(x + 170, y);
            locLabel.AutoSize = true;
            locLabel.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(locLabel);

            Label descLabel = new Label();
            descLabel.Text = "Description";
            descLabel.Location = new Point(x + 240, y);
            descLabel.AutoSize = true;
            descLabel.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(descLabel);

            Label cartonLabel = new Label();
            cartonLabel.Text = "Pack";
            cartonLabel.Location = new Point(x + 460, y);
            cartonLabel.AutoSize = true;
            cartonLabel.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(cartonLabel);

            Label costLabel = new Label();
            costLabel.Text = "Cost";
            costLabel.Location = new Point(x + 510, y);
            costLabel.AutoSize = true;
            costLabel.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(costLabel);

            Label amountLabel = new Label();
            amountLabel.Text = "Amount";
            amountLabel.Location = new Point(x + 580, y);
            amountLabel.AutoSize = true;
            amountLabel.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(amountLabel);

            Label specialNotesLabel = new Label();
            specialNotesLabel.Text = "Special Notes";
            specialNotesLabel.Location = new Point(x + 640, y);
            specialNotesLabel.AutoSize = true;
            specialNotesLabel.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(specialNotesLabel);

            Button cancelButton = new Button();
            cancelButton.Location = new Point(720, 620);
            cancelButton.Size = new Size(50, 25);
            cancelButton.Text = "Cancel";
            cancelButton.Click += CancelButton_Click;
            this.Controls.Add(cancelButton);

            Button okButton = new Button();
            okButton.Location = new Point(780, 620);
            okButton.Size = new Size(50, 25);
            okButton.Text = "OK";
            okButton.Click += OkButton_Click;
            this.Controls.Add(okButton);

        }

        private void Qty_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }
            */
        }

        private void Qty_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            Product product = ProductDatabase.SearchProductByItemNo(this.panel1.Controls["itemNumber" + t.AccessibleName].Text);
            if (product != null && this.panel1.Controls["qty" + t.AccessibleName].Text.Length > 0)
            {
                if (this.panel1.Controls["qty" + t.AccessibleName].Text.Length == 1 && this.panel1.Controls["qty" + t.AccessibleName].Text == "-")
                {
                    return;
                }
                else
                {
                    this.panel1.Controls["amount" + t.AccessibleName].Text = (Single.Parse(this.panel1.Controls["qty" + t.AccessibleName].Text) * product.SellPrice).ToString("0.00");
                }
            }
            if (Int32.Parse(t.AccessibleName) == i)
            {
                AddItemBoxes();
            }

            if (this.panel1.Controls["itemNumber" + t.AccessibleName].Text.Length == 0 && this.panel1.Controls["qty" + t.AccessibleName].Text.Length == 0)
            {
                this.panel1.Controls["loc" + t.AccessibleName].Text = "";
                this.panel1.Controls["desc" + t.AccessibleName].Text = "";
                this.panel1.Controls["carton" + t.AccessibleName].Text = "";
                this.panel1.Controls["cost" + t.AccessibleName].Text = "";
                this.panel1.Controls["amount" + t.AccessibleName].Text = "";
                this.panel1.Controls["specialNotes" + t.AccessibleName].Text = "";

            }
        }

        private void C_TextChanged(object sender, EventArgs e)
        {
            ComboBox c = (ComboBox)sender;
            Product product = ProductDatabase.SearchProductByItemNo(c.Text);
            if (product != null)
            {
                this.panel1.Controls["loc" + c.AccessibleName].Text = product.Location;
                this.panel1.Controls["desc" + c.AccessibleName].Text = product.ItemDesc;
                this.panel1.Controls["carton" + c.AccessibleName].Text = product.PerCarton.ToString();
                this.panel1.Controls["cost" + c.AccessibleName].Text = product.SellPrice.ToString("0.00");
                String temp = product.SpecialNotes;
                this.panel1.Controls["specialNotes" + c.AccessibleName].Text = product.SpecialNotes;

                if (this.panel1.Controls["qty" + c.AccessibleName].Text.Length > 0)
                {
                    if (this.panel1.Controls["qty" + c.AccessibleName].Text.Length == 1 && this.panel1.Controls["qty" + c.AccessibleName].Text == "-")
                    {
                        return;
                    }
                    else
                    {
                        this.panel1.Controls["amount" + c.AccessibleName].Text = (Single.Parse(this.panel1.Controls["qty" + c.AccessibleName].Text) * product.SellPrice).ToString("0.00");
                    }
                }
            }

            if (Int32.Parse(c.AccessibleName) == i)
            {
                AddItemBoxes();
            }

            //qty and itemNo empty
            if (this.panel1.Controls["itemNumber" + c.AccessibleName].Text.Length == 0 && this.panel1.Controls["qty" + c.AccessibleName].Text.Length == 0)
            {
                this.panel1.Controls["loc" + c.AccessibleName].Text = "";
                this.panel1.Controls["desc" + c.AccessibleName].Text = "";
                this.panel1.Controls["carton" + c.AccessibleName].Text = "";
                this.panel1.Controls["cost" + c.AccessibleName].Text = "";
                this.panel1.Controls["amount" + c.AccessibleName].Text = "";
            }
        }

        private void Desc_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{TAB}");
        }

        private void C_TextUpdated(object sender, EventArgs e)
        {
            ComboBox c = (ComboBox)sender;
            c.DroppedDown = true;

            c.Items.Clear();
            c.SelectionLength = 0;
            Cursor.Current = Cursors.Default;

            c.SelectionStart = c.Text.Length;

            List<Product> productList = ProductDatabase.SearchProductsByItemNo(c.Text);

            Object[] arr = new Object[productList.Count];
            for (int j = 0; j < productList.Count; j++)
            {
                arr[j] = productList[j].ItemNo;
            }
            c.Items.AddRange(arr);
        }





        private void OkButton_Click(object sender, EventArgs e)
        {

            bool valid = true;
            for (int j = 0; j < i; j++)
            {
                if (this.panel1.Controls["qty" + j].Text.Length == 0 & this.panel1.Controls["itemNumber" + j].Text.Length != 0)
                {
                    valid = false;
                    this.panel1.Controls["qty" + j].BackColor = Color.Red;
                }

                if (this.panel1.Controls["qty" + j].Text.Length != 0 & this.panel1.Controls["itemNumber" + j].Text.Length == 0)
                {
                    valid = false;
                    this.panel1.Controls["itemNumber" + j].BackColor = Color.Red;
                }
                if (this.panel1.Controls["qty" + j].Text.Length == 1 && this.panel1.Controls["qty" + j].Text == "-")
                {
                    valid = false;
                    this.panel1.Controls["qty" + j].BackColor = Color.Red;
                }
            }

            if (valid == true)
            {
                var confirmResult = MessageBox.Show("Are you sure this invoice is complete?",
                                     "Confirm Completion!!",
                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    Customer cust = CustomerDatabase.SearchCustomersByID(customerID);
                    int invoiceID;


                    invoiceID = InvoiceDatabase.AddInvoice(customerID, this.Controls["purchaseOrder"].Text, "");
                    

                    for (int j = 0; j < i; j++)
                    {

                        if (this.panel1.Controls["qty" + j].Text.Length != 0)
                        {

                            String itemNo = this.panel1.Controls["itemNumber" + j].Text;
                            int qty = Int32.Parse(this.panel1.Controls["qty" + j].Text);
                            String notes = this.panel1.Controls["specialNotes" + j].Text;
                            InvoiceContentsDatabase.AddInvoiceContent(invoiceID, itemNo, qty, notes);
                        }
                    }

                    Invoice invoice = new Invoice(invoiceID);
                    invoice.SaveToExcel();
                    finished = true;
                  
                    this.Close();
                }
                else
                {
                    // If 'No', do something here.
                }

            }

        }

        private void invoiceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (finished)
            {
                return;
            }
            if (MessageBox.Show("This Invoice is in progress. Select OK to exit.", "EXIT", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }


        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddTotalBoxes(int customerID)
        {
            Customer cust = CustomerDatabase.SearchCustomersByID(customerID);
            ProvinceTax provinceTax = ProvinceTaxDatabase.GetProvinceByName(cust.Province);

            Label subtotalLabel = new Label();
            subtotalLabel.Text = "Subtotal";
            subtotalLabel.Location = new Point(562, 500);
            subtotalLabel.AutoSize = true;
            this.Controls.Add(subtotalLabel);

            TextBox subtotalAmount = new TextBox();
            subtotalAmount.Location = new Point(610, 500);
            subtotalAmount.Size = new Size(50, 25);
            subtotalAmount.ReadOnly = true;
            subtotalAmount.Name = "subtotalAmount";
            subtotalAmount.AccessibleName = "subtotalAmount";
            subtotalAmount.TextChanged += SubtotalAmount_TextChanged;
            this.Controls.Add(subtotalAmount);

            Label gstLabel = new Label();
            gstLabel.Text = "GST " + provinceTax.gst + "%";
            gstLabel.Location = new Point(560, 530);
            gstLabel.Size = new Size(50, 25);
            gstLabel.TextAlign = ContentAlignment.TopRight;
            this.Controls.Add(gstLabel);

            TextBox gst = new TextBox();
            gst.Location = new Point(610, 530);
            gst.Size = new Size(50, 25);
            gst.ReadOnly = true;
            gst.Name = "gst";
            gst.AccessibleName = "gst";
            this.Controls.Add(gst);

            if (PST)
            {
                Label pstLabel = new Label();
                pstLabel.Text = "PST " + provinceTax.pst + "%";
                pstLabel.Location = new Point(560, 560);
                pstLabel.Size = new Size(50, 25);
                pstLabel.TextAlign = ContentAlignment.TopRight;
                this.Controls.Add(pstLabel);

                TextBox pst = new TextBox();
                pst.Location = new Point(610, 560);
                pst.Size = new Size(50, 25);
                pst.ReadOnly = true;
                pst.Name = "pst";
                pst.AccessibleName = "pst";
                this.Controls.Add(pst);

                Label invoiceTotalLabel = new Label();
                invoiceTotalLabel.Text = "Invoice Total";
                invoiceTotalLabel.Location = new Point(540, 590);
                invoiceTotalLabel.AutoSize = true;
                this.Controls.Add(invoiceTotalLabel);

                TextBox invoiceTotal = new TextBox();
                invoiceTotal.Location = new Point(610, 590);
                invoiceTotal.Size = new Size(50, 25);
                invoiceTotal.ReadOnly = true;
                invoiceTotal.Name = "invoiceTotal";
                invoiceTotal.AccessibleName = "invoiceTotal";
                this.Controls.Add(invoiceTotal);
            }
            else //no pst
            {
                Label invoiceTotalLabel = new Label();
                invoiceTotalLabel.Text = "Invoice Total";
                invoiceTotalLabel.Location = new Point(540, 560);
                invoiceTotalLabel.AutoSize = true;
                this.Controls.Add(invoiceTotalLabel);

                TextBox invoiceTotal = new TextBox();
                invoiceTotal.Location = new Point(610, 560);
                invoiceTotal.Size = new Size(50, 25);
                invoiceTotal.ReadOnly = true;
                invoiceTotal.Name = "invoiceTotal";
                invoiceTotal.AccessibleName = "invoiceTotal";
                this.Controls.Add(invoiceTotal);
            }
        }

        private void SubtotalAmount_TextChanged(object sender, EventArgs e)
        {
            Customer c = CustomerDatabase.SearchCustomersByID(customerID);
            ProvinceTax provinceTax = ProvinceTaxDatabase.GetProvinceByName(c.Province);
            float gstRate = (float)provinceTax.gst / 100;

            this.Controls["gst"].Text = (Single.Parse(this.Controls["subTotalAmount"].Text) * gstRate).ToString("0.00");
            this.Controls["invoiceTotal"].Text = (Single.Parse(this.Controls["subTotalAmount"].Text) * (1 + gstRate)).ToString("0.00");
            if (PST)
            {
                float pstRate = (float)provinceTax.pst / 100;
                this.Controls["pst"].Text = (Single.Parse(this.Controls["subTotalAmount"].Text) * pstRate).ToString("0.00");
                this.Controls["invoiceTotal"].Text = (Single.Parse(this.Controls["subTotalAmount"].Text) * (1 + gstRate + pstRate)).ToString("0.00");
            }
        }

        private void AddFirstRow()
        {
            TextBox qty = new TextBox();
            qty.Location = new Point(0, 0 + i * 25);
            qty.Size = new Size(30, 25);
            qty.Name = "qty" + i;
            qty.TextChanged += Qty_TextChanged;
            qty.KeyPress += Qty_KeyPress;
            qty.AccessibleName = "" + i;
            panel1.Controls.Add(qty);

            ComboBox itemNumber = new ComboBox();
            itemNumber.Location = new Point(50, 0 + i * 25);
            itemNumber.Size = new Size(100, 25);
            itemNumber.TextUpdate += C_TextUpdated;
            itemNumber.TextChanged += C_TextChanged;
            itemNumber.LostFocus += ItemNumber_LostFocus;
            itemNumber.Name = "itemNumber" + i;
            Debug.Print(itemNumber.Name);
            itemNumber.AccessibleName = "" + i;
            itemNumber.MaxDropDownItems = 10;
            panel1.Controls.Add(itemNumber);


            TextBox loc = new TextBox();
            loc.Location = new Point(170, 0 + i * 25);
            loc.Size = new Size(50, 25);
            loc.ReadOnly = true;
            loc.Enter += Desc_Enter;
            loc.Name = "loc" + i;
            loc.AccessibleName = "" + i;
            panel1.Controls.Add(loc);

            TextBox desc = new TextBox();
            desc.Location = new Point(240, 0 + i * 25);
            desc.Size = new Size(200, 25);
            desc.ReadOnly = true;
            desc.Enter += Desc_Enter;
            desc.Name = "desc" + i;
            desc.AccessibleName = "" + i;
            panel1.Controls.Add(desc);

            TextBox cartonPack = new TextBox();
            cartonPack.Location = new Point(460, 0 + i * 25);
            cartonPack.Size = new Size(30, 25);
            cartonPack.ReadOnly = true;
            cartonPack.Enter += Desc_Enter;
            cartonPack.Name = "carton" + i;
            cartonPack.AccessibleName = "" + i;
            panel1.Controls.Add(cartonPack);

            TextBox cost = new TextBox();
            cost.Location = new Point(510, 0 + i * 25);
            cost.Size = new Size(50, 25);
            cost.ReadOnly = true;
            cost.Enter += Desc_Enter;
            cost.Name = "cost" + i;
            cost.AccessibleName = "" + i;
            panel1.Controls.Add(cost);

            TextBox amount = new TextBox();
            amount.Location = new Point(580, 0 + i * 25);
            amount.Size = new Size(50, 25);
            amount.ReadOnly = true;
            amount.Enter += Desc_Enter;
            amount.TextChanged += Amount_TextChanged;
            amount.Name = "amount" + i;
            amount.AccessibleName = "" + i;
            panel1.Controls.Add(amount);

            TextBox specialNotes = new TextBox();
            specialNotes.Location = new Point(640, 0 + i * 25);
            specialNotes.Size = new Size(140, 25);
            specialNotes.Name = "specialNotes" + i;
            specialNotes.AccessibleName = "" + i;
            panel1.Controls.Add(specialNotes);

        }

        private void AddItemBoxes()
        {
            i++;

            TextBox qty = new TextBox();
            qty.Location = new Point(0, this.panel1.Controls["qty" + (i - 1)].Location.Y + 25);
            qty.Size = new Size(30, 25);
            qty.Name = "qty" + i;
            qty.TextChanged += Qty_TextChanged;
            qty.KeyPress += Qty_KeyPress;
            qty.AccessibleName = "" + i;
            panel1.Controls.Add(qty);

            ComboBox itemNumber = new ComboBox();
            itemNumber.Location = new Point(50, this.panel1.Controls["qty" + (i - 1)].Location.Y + 25);
            itemNumber.Size = new Size(100, 25);
            itemNumber.TextUpdate += C_TextUpdated;
            itemNumber.TextChanged += C_TextChanged;
            itemNumber.LostFocus += ItemNumber_LostFocus;
            itemNumber.Name = "itemNumber" + i;
            Debug.Print(itemNumber.Name);
            itemNumber.AccessibleName = "" + i;
            itemNumber.MaxDropDownItems = 10;
            panel1.Controls.Add(itemNumber);

            TextBox loc = new TextBox();
            loc.Location = new Point(170, this.panel1.Controls["qty" + (i - 1)].Location.Y + 25);
            loc.Size = new Size(50, 25);
            loc.ReadOnly = true;
            loc.Enter += Desc_Enter;
            loc.Name = "loc" + i;
            loc.AccessibleName = "" + i;
            panel1.Controls.Add(loc);

            TextBox desc = new TextBox();
            desc.Location = new Point(240, this.panel1.Controls["qty" + (i - 1)].Location.Y + 25);
            desc.Size = new Size(200, 25);
            desc.ReadOnly = true;
            desc.Enter += Desc_Enter;
            desc.Name = "desc" + i;
            desc.AccessibleName = "" + i;
            panel1.Controls.Add(desc);

            TextBox cartonPack = new TextBox();
            cartonPack.Location = new Point(460, this.panel1.Controls["qty" + (i - 1)].Location.Y + 25);
            cartonPack.Size = new Size(30, 25);
            cartonPack.ReadOnly = true;
            cartonPack.Enter += Desc_Enter;
            cartonPack.Name = "carton" + i;
            cartonPack.AccessibleName = "" + i;
            panel1.Controls.Add(cartonPack);

            TextBox cost = new TextBox();
            cost.Location = new Point(510, this.panel1.Controls["qty" + (i - 1)].Location.Y + 25);
            cost.Size = new Size(50, 25);
            cost.ReadOnly = true;
            cost.Enter += Desc_Enter;
            cost.Name = "cost" + i;
            cost.AccessibleName = "" + i;
            panel1.Controls.Add(cost);

            TextBox amount = new TextBox();
            amount.Location = new Point(580, this.panel1.Controls["qty" + (i - 1)].Location.Y + 25);
            amount.Size = new Size(50, 25);
            amount.ReadOnly = true;
            amount.Enter += Desc_Enter;
            amount.TextChanged += Amount_TextChanged;
            amount.Name = "amount" + i;
            amount.AccessibleName = "" + i;
            panel1.Controls.Add(amount);

            TextBox specialNotes = new TextBox();
            specialNotes.Location = new Point(640, this.panel1.Controls["qty" + (i - 1)].Location.Y + 25);
            specialNotes.Size = new Size(140, 25);
            specialNotes.Name = "specialNotes" + i;
            specialNotes.AccessibleName = "" + i;
            panel1.Controls.Add(specialNotes);

            panel1.VerticalScroll.Value = panel1.VerticalScroll.Maximum;

        }

        private void ItemNumber_LostFocus(object sender, EventArgs e)
        {
            ComboBox c = (ComboBox)sender;
            if (c.Items.Count == 0)
            {
                return;
            }
            Product product = ProductDatabase.SearchProductByItemNo(c.Text);
            if (product != null)
            {
                this.panel1.Controls["loc" + c.AccessibleName].Text = product.Location;
                this.panel1.Controls["desc" + c.AccessibleName].Text = product.ItemDesc;
                this.panel1.Controls["carton" + c.AccessibleName].Text = product.PerCarton.ToString();
                this.panel1.Controls["cost" + c.AccessibleName].Text = product.SellPrice.ToString("0.00");
                this.panel1.Controls["specialNotes" + c.AccessibleName].Text = product.SpecialNotes;

                if (this.panel1.Controls["qty" + c.AccessibleName].Text.Length > 0)
                {
                    if (this.panel1.Controls["qty" + c.AccessibleName].Text.Length == 1 && this.panel1.Controls["qty" + c.AccessibleName].Text == "-")
                    {
                        return;
                    }
                    else
                    {
                        this.panel1.Controls["amount" + c.AccessibleName].Text = (Single.Parse(this.panel1.Controls["qty" + c.AccessibleName].Text) * product.SellPrice).ToString("0.00");
                    }
                }
            }

            if (Int32.Parse(c.AccessibleName) == i)
            {
                AddItemBoxes();
            }

            //qty and itemNo empty
            if (this.panel1.Controls["itemNumber" + c.AccessibleName].Text.Length == 0 && this.panel1.Controls["qty" + c.AccessibleName].Text.Length == 0)
            {
                this.panel1.Controls["loc" + c.AccessibleName].Text = "";
                this.panel1.Controls["desc" + c.AccessibleName].Text = "";
                this.panel1.Controls["carton" + c.AccessibleName].Text = "";
                this.panel1.Controls["cost" + c.AccessibleName].Text = "";
                this.panel1.Controls["amount" + c.AccessibleName].Text = "";
            }
        }

        
        private void Amount_TextChanged(object sender, EventArgs e)
        {
            float total = 0;
            for (int j = 0; j < i; j++)
            {
                if (this.panel1.Controls["amount" + j].Text.Length != 0)
                {
                    total += Single.Parse(this.panel1.Controls["amount" + j].Text);
                }
            }

            this.Controls["subtotalAmount"].Text = total.ToString("0.00");
        }
    }
}
