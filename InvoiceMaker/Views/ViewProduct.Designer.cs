namespace InvoiceMaker
{
    partial class ViewProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewProduct));
            this.ProductView = new System.Windows.Forms.Label();
            this.CancelProduct = new System.Windows.Forms.Button();
            this.DeleteProduct = new System.Windows.Forms.Button();
            this.ModProduct = new System.Windows.Forms.Button();
            this.productTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ProductView
            // 
            this.ProductView.AutoSize = true;
            this.ProductView.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductView.Location = new System.Drawing.Point(438, 13);
            this.ProductView.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ProductView.Name = "ProductView";
            this.ProductView.Size = new System.Drawing.Size(124, 23);
            this.ProductView.TabIndex = 1;
            this.ProductView.Text = "Find Products";
            // 
            // CancelProduct
            // 
            this.CancelProduct.Location = new System.Drawing.Point(0, 0);
            this.CancelProduct.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CancelProduct.Name = "CancelProduct";
            this.CancelProduct.Size = new System.Drawing.Size(38, 12);
            this.CancelProduct.TabIndex = 11;
            // 
            // DeleteProduct
            // 
            this.DeleteProduct.Location = new System.Drawing.Point(0, 0);
            this.DeleteProduct.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DeleteProduct.Name = "DeleteProduct";
            this.DeleteProduct.Size = new System.Drawing.Size(38, 12);
            this.DeleteProduct.TabIndex = 12;
            // 
            // ModProduct
            // 
            this.ModProduct.Location = new System.Drawing.Point(0, 0);
            this.ModProduct.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ModProduct.Name = "ModProduct";
            this.ModProduct.Size = new System.Drawing.Size(38, 12);
            this.ModProduct.TabIndex = 13;
            // 
            // productTextBox
            // 
            this.productTextBox.Location = new System.Drawing.Point(346, 45);
            this.productTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.productTextBox.Name = "productTextBox";
            this.productTextBox.Size = new System.Drawing.Size(339, 21);
            this.productTextBox.TabIndex = 10;
            this.productTextBox.TextChanged += new System.EventHandler(this.productTextBox_TextChanged);
            // 
            // ViewProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 458);
            this.Controls.Add(this.productTextBox);
            this.Controls.Add(this.CancelProduct);
            this.Controls.Add(this.DeleteProduct);
            this.Controls.Add(this.ModProduct);
            this.Controls.Add(this.ProductView);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ViewProduct";
            this.Text = "Products";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ViewProduct_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ProductView;
        private System.Windows.Forms.Button CancelProduct;
        private System.Windows.Forms.Button DeleteProduct;
        private System.Windows.Forms.Button ModProduct;
        private System.Windows.Forms.TextBox productTextBox;
    }
}