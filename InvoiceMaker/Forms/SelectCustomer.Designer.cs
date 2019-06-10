namespace InvoiceMaker
{
    partial class SelectCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectCustomer));
            this.customerTextBox = new System.Windows.Forms.TextBox();
            this.CustomerView = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // customerTextBox
            // 
            this.customerTextBox.Location = new System.Drawing.Point(448, 51);
            this.customerTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.customerTextBox.Name = "customerTextBox";
            this.customerTextBox.Size = new System.Drawing.Size(339, 21);
            this.customerTextBox.TabIndex = 13;
            this.customerTextBox.TextChanged += new System.EventHandler(this.customerTextBox_TextChanged);
            // 
            // CustomerView
            // 
            this.CustomerView.AutoSize = true;
            this.CustomerView.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerView.Location = new System.Drawing.Point(540, 19);
            this.CustomerView.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CustomerView.Name = "CustomerView";
            this.CustomerView.Size = new System.Drawing.Size(131, 23);
            this.CustomerView.TabIndex = 12;
            this.CustomerView.Text = "Find Customer";
            // 
            // SelectCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 458);
            this.Controls.Add(this.customerTextBox);
            this.Controls.Add(this.CustomerView);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "SelectCustomer";
            this.Text = "SelectCustomer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox customerTextBox;
        private System.Windows.Forms.Label CustomerView;
    }
}