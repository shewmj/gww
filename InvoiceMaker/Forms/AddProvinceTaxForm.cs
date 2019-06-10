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
    public partial class AddProvinceTaxForm : Form
    {
        TextBox provinceTax = new TextBox();
        TextBox gstTax = new TextBox();
        TextBox pstTax = new TextBox();
        bool editMode = false;


        public AddProvinceTaxForm()
        {
            InitializeComponent();
            AddBoxes();
            editMode = false;
        }

        public AddProvinceTaxForm(String provinceTax, int gst, int pst)
        {
            AddBoxes();
            this.provinceTax.Text = provinceTax;
            this.gstTax.Text = gst.ToString();
            this.pstTax.Text = pst.ToString();

            this.provinceTax.ReadOnly = true;
            editMode = true;
        }

        private void AddBoxes()
        {
            Label provinceTaxLabel = new Label();
            provinceTaxLabel.Text = "Province Tax";
            provinceTaxLabel.Location = new Point(30, 50);
            provinceTaxLabel.AutoSize = true;
            this.Controls.Add(provinceTaxLabel);

            provinceTax.Location = new Point(30, 70);
            provinceTax.Size = provinceTaxLabel.Size;
            this.Controls.Add(provinceTax);

            Label gstLabel = new Label();
            gstLabel.Text = "GST (%)";
            gstLabel.Location = new Point(120, 50);
            gstLabel.AutoSize = true;
            this.Controls.Add(gstLabel);

            gstTax.Location = new Point(120, 70);
            gstTax.Size = new Size(50, 25);
            this.Controls.Add(gstTax);

            Label pstLabel = new Label();
            pstLabel.Text = "PST (%)";
            pstLabel.Location = new Point(190, 50);
            pstLabel.AutoSize = true;
            this.Controls.Add(pstLabel);

            pstTax.Location = new Point(190, 70);
            pstTax.Size = new Size(50, 25);
            this.Controls.Add(pstTax);

            Button cancelButton = new Button();
            cancelButton.Location = new Point(130, 120);
            cancelButton.Size = new Size(50, 25);
            cancelButton.Text = "Cancel";
            cancelButton.Click += CancelButton_Click;
            this.Controls.Add(cancelButton);

            Button okButton = new Button();
            okButton.Location = new Point(190, 120);
            okButton.Size = new Size(50, 25);
            okButton.Text = "OK";
            okButton.Click += OkButton_Click;
            this.Controls.Add(okButton);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            int pst = 0;
            if(pstTax.Text.Length == 0)
            {
                pst = 0;
            }
            else
            {
                pst = Int32.Parse(pstTax.Text);
            }
            ProvinceTaxDatabase.AddProvinceTax(provinceTax.Text, Int32.Parse(gstTax.Text), pst);
            if(editMode)
            {
                ProvinceTaxDatabase.EditProvinceTax(provinceTax.Text, Int32.Parse(gstTax.Text), pst);
            }
            this.Close();
            ProvinceTaxesForm provinceTaxesForm = new ProvinceTaxesForm();
            provinceTaxesForm.Size = new System.Drawing.Size(300, 500);
            provinceTaxesForm.Show();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
