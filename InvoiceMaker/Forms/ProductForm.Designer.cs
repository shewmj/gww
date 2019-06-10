namespace InvoiceMaker
{
    partial class ProductForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductForm));
            this.label1 = new System.Windows.Forms.Label();
            this.itemNumber_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.itemDescription_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cartonPack_textBox = new System.Windows.Forms.TextBox();
            this.warehouseLoc_textBox = new System.Windows.Forms.TextBox();
            this.sellingPrice_textBox = new System.Windows.Forms.TextBox();
            this.upc_textBox = new System.Windows.Forms.TextBox();
            this.cancel_button = new System.Windows.Forms.Button();
            this.submit_button = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.specNote_textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item Number";
            // 
            // itemNumber_textBox
            // 
            this.itemNumber_textBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemNumber_textBox.Location = new System.Drawing.Point(34, 45);
            this.itemNumber_textBox.Margin = new System.Windows.Forms.Padding(2);
            this.itemNumber_textBox.Name = "itemNumber_textBox";
            this.itemNumber_textBox.Size = new System.Drawing.Size(90, 21);
            this.itemNumber_textBox.TabIndex = 1;
            this.itemNumber_textBox.TextChanged += new System.EventHandler(this.itemNumber_textBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Item Description";
            // 
            // itemDescription_textBox
            // 
            this.itemDescription_textBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemDescription_textBox.Location = new System.Drawing.Point(34, 96);
            this.itemDescription_textBox.Margin = new System.Windows.Forms.Padding(2);
            this.itemDescription_textBox.Name = "itemDescription_textBox";
            this.itemDescription_textBox.Size = new System.Drawing.Size(330, 21);
            this.itemDescription_textBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 136);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Carton Pack";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(164, 136);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Warehouse Location";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(166, 178);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Selling Price";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(32, 178);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "UPC";
            // 
            // cartonPack_textBox
            // 
            this.cartonPack_textBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cartonPack_textBox.Location = new System.Drawing.Point(34, 152);
            this.cartonPack_textBox.Margin = new System.Windows.Forms.Padding(2);
            this.cartonPack_textBox.Name = "cartonPack_textBox";
            this.cartonPack_textBox.Size = new System.Drawing.Size(52, 21);
            this.cartonPack_textBox.TabIndex = 9;
            // 
            // warehouseLoc_textBox
            // 
            this.warehouseLoc_textBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warehouseLoc_textBox.Location = new System.Drawing.Point(166, 152);
            this.warehouseLoc_textBox.Margin = new System.Windows.Forms.Padding(2);
            this.warehouseLoc_textBox.Name = "warehouseLoc_textBox";
            this.warehouseLoc_textBox.Size = new System.Drawing.Size(52, 21);
            this.warehouseLoc_textBox.TabIndex = 10;
            // 
            // sellingPrice_textBox
            // 
            this.sellingPrice_textBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sellingPrice_textBox.Location = new System.Drawing.Point(168, 195);
            this.sellingPrice_textBox.Margin = new System.Windows.Forms.Padding(2);
            this.sellingPrice_textBox.Name = "sellingPrice_textBox";
            this.sellingPrice_textBox.Size = new System.Drawing.Size(52, 21);
            this.sellingPrice_textBox.TabIndex = 12;
            // 
            // upc_textBox
            // 
            this.upc_textBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upc_textBox.Location = new System.Drawing.Point(33, 195);
            this.upc_textBox.Margin = new System.Windows.Forms.Padding(2);
            this.upc_textBox.Name = "upc_textBox";
            this.upc_textBox.Size = new System.Drawing.Size(82, 21);
            this.upc_textBox.TabIndex = 13;
            // 
            // cancel_button
            // 
            this.cancel_button.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel_button.Location = new System.Drawing.Point(222, 314);
            this.cancel_button.Margin = new System.Windows.Forms.Padding(2);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(57, 29);
            this.cancel_button.TabIndex = 14;
            this.cancel_button.Text = "Cancel";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // submit_button
            // 
            this.submit_button.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submit_button.Location = new System.Drawing.Point(289, 314);
            this.submit_button.Margin = new System.Windows.Forms.Padding(2);
            this.submit_button.Name = "submit_button";
            this.submit_button.Size = new System.Drawing.Size(58, 29);
            this.submit_button.TabIndex = 15;
            this.submit_button.Text = "Submit";
            this.submit_button.UseVisualStyleBackColor = true;
            this.submit_button.Click += new System.EventHandler(this.submit_button_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(166, 225);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Special Notes";
            // 
            // specNote_textBox
            // 
            this.specNote_textBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.specNote_textBox.Location = new System.Drawing.Point(168, 242);
            this.specNote_textBox.Margin = new System.Windows.Forms.Padding(2);
            this.specNote_textBox.Name = "specNote_textBox";
            this.specNote_textBox.Size = new System.Drawing.Size(82, 21);
            this.specNote_textBox.TabIndex = 14;
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 348);
            this.Controls.Add(this.specNote_textBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.submit_button);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.upc_textBox);
            this.Controls.Add(this.sellingPrice_textBox);
            this.Controls.Add(this.warehouseLoc_textBox);
            this.Controls.Add(this.cartonPack_textBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.itemDescription_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.itemNumber_textBox);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ProductForm";
            this.Text = "ProductForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox itemNumber_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox itemDescription_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox cartonPack_textBox;
        private System.Windows.Forms.TextBox warehouseLoc_textBox;
        private System.Windows.Forms.TextBox sellingPrice_textBox;
        private System.Windows.Forms.TextBox upc_textBox;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.Button submit_button;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox specNote_textBox;
    }
}