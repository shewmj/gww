namespace InvoiceMaker
{
    partial class ViewCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewCustomer));
            this.CustomerView = new System.Windows.Forms.Label();
            this.customerTextBox = new System.Windows.Forms.TextBox();
            this.ModCustomer = new System.Windows.Forms.Button();
            this.CancelCustomer = new System.Windows.Forms.Button();
            this.DeleteCustomer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CustomerView
            // 
            this.CustomerView.AutoSize = true;
            this.CustomerView.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerView.Location = new System.Drawing.Point(543, 15);
            this.CustomerView.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CustomerView.Name = "CustomerView";
            this.CustomerView.Size = new System.Drawing.Size(131, 23);
            this.CustomerView.TabIndex = 1;
            this.CustomerView.Text = "Find Customer";
            this.CustomerView.Click += new System.EventHandler(this.CustomerView_Click);
            // 
            // customerTextBox
            // 
            this.customerTextBox.Location = new System.Drawing.Point(450, 47);
            this.customerTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.customerTextBox.Name = "customerTextBox";
            this.customerTextBox.Size = new System.Drawing.Size(339, 21);
            this.customerTextBox.TabIndex = 11;
            this.customerTextBox.TextChanged += new System.EventHandler(this.customerTextBox_TextChanged);
            // 
            // ModCustomer
            // 
            this.ModCustomer.Location = new System.Drawing.Point(0, 0);
            this.ModCustomer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ModCustomer.Name = "ModCustomer";
            this.ModCustomer.Size = new System.Drawing.Size(38, 12);
            this.ModCustomer.TabIndex = 14;
            // 
            // CancelCustomer
            // 
            this.CancelCustomer.Location = new System.Drawing.Point(0, 0);
            this.CancelCustomer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CancelCustomer.Name = "CancelCustomer";
            this.CancelCustomer.Size = new System.Drawing.Size(38, 12);
            this.CancelCustomer.TabIndex = 12;
            // 
            // DeleteCustomer
            // 
            this.DeleteCustomer.Location = new System.Drawing.Point(0, 0);
            this.DeleteCustomer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DeleteCustomer.Name = "DeleteCustomer";
            this.DeleteCustomer.Size = new System.Drawing.Size(38, 12);
            this.DeleteCustomer.TabIndex = 13;
            // 
            // ViewCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 458);
            this.Controls.Add(this.customerTextBox);
            this.Controls.Add(this.CancelCustomer);
            this.Controls.Add(this.DeleteCustomer);
            this.Controls.Add(this.ModCustomer);
            this.Controls.Add(this.CustomerView);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ViewCustomer";
            this.Text = "Customers";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CustomerView;
        private System.Windows.Forms.TextBox customerTextBox;
        private System.Windows.Forms.Button ModCustomer;
        private System.Windows.Forms.Button CancelCustomer;
        private System.Windows.Forms.Button DeleteCustomer;
    }
}