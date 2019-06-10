using System;

namespace InvoiceMaker
{
    partial class CustomerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerForm));
            this.button1 = new System.Windows.Forms.Button();
            this.storeName_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.shippingPostal_textBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.shippingCity_textBox = new System.Windows.Forms.TextBox();
            this.shippingProvince_comboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.shippingStreet_textBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.storeContact_textBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.phoneNumber_textBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.paymentTerms_textBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.shippingInstructions_textBox = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.storeDetails_textBox = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.provinceTax_comboBox = new System.Windows.Forms.ComboBox();
            this.email_textBox = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.rep_textBox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.storeSpecialNotes_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(366, 413);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 31);
            this.button1.TabIndex = 20;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.okButton_Click);
            // 
            // storeName_textBox
            // 
            this.storeName_textBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.storeName_textBox.Location = new System.Drawing.Point(35, 30);
            this.storeName_textBox.Margin = new System.Windows.Forms.Padding(2);
            this.storeName_textBox.Name = "storeName_textBox";
            this.storeName_textBox.Size = new System.Drawing.Size(292, 21);
            this.storeName_textBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Store Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.shippingPostal_textBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.shippingCity_textBox);
            this.groupBox2.Controls.Add(this.shippingProvince_comboBox);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.shippingStreet_textBox);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(30, 145);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(388, 96);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.Text = "Address";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // shippingPostal_textBox
            // 
            this.shippingPostal_textBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shippingPostal_textBox.Location = new System.Drawing.Point(274, 69);
            this.shippingPostal_textBox.Margin = new System.Windows.Forms.Padding(2);
            this.shippingPostal_textBox.Name = "shippingPostal_textBox";
            this.shippingPostal_textBox.Size = new System.Drawing.Size(82, 21);
            this.shippingPostal_textBox.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(272, 54);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Postal Code";
            // 
            // shippingCity_textBox
            // 
            this.shippingCity_textBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shippingCity_textBox.Location = new System.Drawing.Point(6, 69);
            this.shippingCity_textBox.Margin = new System.Windows.Forms.Padding(2);
            this.shippingCity_textBox.Name = "shippingCity_textBox";
            this.shippingCity_textBox.Size = new System.Drawing.Size(110, 21);
            this.shippingCity_textBox.TabIndex = 9;
            // 
            // shippingProvince_comboBox
            // 
            this.shippingProvince_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shippingProvince_comboBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shippingProvince_comboBox.FormattingEnabled = true;
            this.shippingProvince_comboBox.Items.AddRange(new object[] {
            "Alberta",
            "British Columbia",
            "Manitoba",
            "New Brunswick",
            "Newfoundland and Labrador",
            "Nova Scotia",
            "Northwest Territories",
            "Nunavut",
            "Ontario",
            "Prince Edward Island",
            "Quebec",
            "Saskatchewan",
            "Yukon Territories"});
            this.shippingProvince_comboBox.Location = new System.Drawing.Point(121, 68);
            this.shippingProvince_comboBox.Margin = new System.Windows.Forms.Padding(2);
            this.shippingProvince_comboBox.Name = "shippingProvince_comboBox";
            this.shippingProvince_comboBox.Size = new System.Drawing.Size(142, 21);
            this.shippingProvince_comboBox.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(118, 54);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Province";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 54);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "City";
            // 
            // shippingStreet_textBox
            // 
            this.shippingStreet_textBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shippingStreet_textBox.Location = new System.Drawing.Point(6, 32);
            this.shippingStreet_textBox.Margin = new System.Windows.Forms.Padding(2);
            this.shippingStreet_textBox.Name = "shippingStreet_textBox";
            this.shippingStreet_textBox.Size = new System.Drawing.Size(350, 21);
            this.shippingStreet_textBox.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 17);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Street";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(35, 250);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "Store Contact";
            // 
            // storeContact_textBox
            // 
            this.storeContact_textBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.storeContact_textBox.Location = new System.Drawing.Point(35, 265);
            this.storeContact_textBox.Margin = new System.Windows.Forms.Padding(2);
            this.storeContact_textBox.Name = "storeContact_textBox";
            this.storeContact_textBox.Size = new System.Drawing.Size(166, 21);
            this.storeContact_textBox.TabIndex = 12;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(215, 250);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 13);
            this.label13.TabIndex = 10;
            this.label13.Text = "Phone Number";
            // 
            // phoneNumber_textBox
            // 
            this.phoneNumber_textBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoneNumber_textBox.Location = new System.Drawing.Point(215, 265);
            this.phoneNumber_textBox.Margin = new System.Windows.Forms.Padding(2);
            this.phoneNumber_textBox.Name = "phoneNumber_textBox";
            this.phoneNumber_textBox.Size = new System.Drawing.Size(176, 21);
            this.phoneNumber_textBox.TabIndex = 13;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(165, 350);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(81, 13);
            this.label14.TabIndex = 14;
            this.label14.Text = "Payment Terms";
            // 
            // paymentTerms_textBox
            // 
            this.paymentTerms_textBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentTerms_textBox.Location = new System.Drawing.Point(165, 365);
            this.paymentTerms_textBox.Margin = new System.Windows.Forms.Padding(2);
            this.paymentTerms_textBox.Name = "paymentTerms_textBox";
            this.paymentTerms_textBox.Size = new System.Drawing.Size(106, 21);
            this.paymentTerms_textBox.TabIndex = 17;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(285, 350);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(107, 13);
            this.label15.TabIndex = 16;
            this.label15.Text = "Shipping Instructions";
            // 
            // shippingInstructions_textBox
            // 
            this.shippingInstructions_textBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shippingInstructions_textBox.Location = new System.Drawing.Point(285, 365);
            this.shippingInstructions_textBox.Margin = new System.Windows.Forms.Padding(2);
            this.shippingInstructions_textBox.Name = "shippingInstructions_textBox";
            this.shippingInstructions_textBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.shippingInstructions_textBox.Size = new System.Drawing.Size(106, 20);
            this.shippingInstructions_textBox.TabIndex = 18;
            this.shippingInstructions_textBox.Text = "";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(295, 413);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 31);
            this.button2.TabIndex = 19;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(35, 55);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(68, 13);
            this.label17.TabIndex = 21;
            this.label17.Text = "Store Details";
            // 
            // storeDetails_textBox
            // 
            this.storeDetails_textBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.storeDetails_textBox.Location = new System.Drawing.Point(35, 70);
            this.storeDetails_textBox.Margin = new System.Windows.Forms.Padding(2);
            this.storeDetails_textBox.Name = "storeDetails_textBox";
            this.storeDetails_textBox.Size = new System.Drawing.Size(292, 21);
            this.storeDetails_textBox.TabIndex = 1;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(215, 300);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(66, 13);
            this.label18.TabIndex = 12;
            this.label18.Text = "ProvinceTax";
            // 
            // provinceTax_comboBox
            // 
            this.provinceTax_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.provinceTax_comboBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.provinceTax_comboBox.FormattingEnabled = true;
            this.provinceTax_comboBox.Location = new System.Drawing.Point(215, 315);
            this.provinceTax_comboBox.Margin = new System.Windows.Forms.Padding(2);
            this.provinceTax_comboBox.Name = "provinceTax_comboBox";
            this.provinceTax_comboBox.Size = new System.Drawing.Size(176, 21);
            this.provinceTax_comboBox.TabIndex = 15;
            // 
            // email_textBox
            // 
            this.email_textBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email_textBox.Location = new System.Drawing.Point(35, 315);
            this.email_textBox.Margin = new System.Windows.Forms.Padding(2);
            this.email_textBox.Name = "email_textBox";
            this.email_textBox.Size = new System.Drawing.Size(168, 21);
            this.email_textBox.TabIndex = 14;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(35, 300);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(31, 13);
            this.label19.TabIndex = 23;
            this.label19.Text = "Email";
            // 
            // rep_textBox
            // 
            this.rep_textBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rep_textBox.Location = new System.Drawing.Point(35, 365);
            this.rep_textBox.Margin = new System.Windows.Forms.Padding(2);
            this.rep_textBox.Name = "rep_textBox";
            this.rep_textBox.Size = new System.Drawing.Size(118, 21);
            this.rep_textBox.TabIndex = 16;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(35, 350);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(54, 13);
            this.label16.TabIndex = 25;
            this.label16.Text = "Sales Rep";
            // 
            // storeSpecialNotes_textBox
            // 
            this.storeSpecialNotes_textBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.storeSpecialNotes_textBox.Location = new System.Drawing.Point(35, 110);
            this.storeSpecialNotes_textBox.Margin = new System.Windows.Forms.Padding(2);
            this.storeSpecialNotes_textBox.Name = "storeSpecialNotes_textBox";
            this.storeSpecialNotes_textBox.Size = new System.Drawing.Size(292, 21);
            this.storeSpecialNotes_textBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 95);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Store Special Notes";
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 458);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.storeSpecialNotes_textBox);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.rep_textBox);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.email_textBox);
            this.Controls.Add(this.provinceTax_comboBox);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.storeDetails_textBox);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.shippingInstructions_textBox);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.paymentTerms_textBox);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.phoneNumber_textBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.storeContact_textBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.storeName_textBox);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CustomerForm";
            this.Text = "New Customer";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox storeName_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox shippingPostal_textBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox shippingCity_textBox;
        private System.Windows.Forms.ComboBox shippingProvince_comboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox shippingStreet_textBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox storeContact_textBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox phoneNumber_textBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox paymentTerms_textBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.RichTextBox shippingInstructions_textBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox storeDetails_textBox;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox provinceTax_comboBox;
        private System.Windows.Forms.TextBox email_textBox;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox rep_textBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox storeSpecialNotes_textBox;
        private System.Windows.Forms.Label label2;
    }
}