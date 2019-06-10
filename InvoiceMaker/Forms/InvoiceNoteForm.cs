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
    public partial class InvoiceNoteForm : Form
    {
        TextBox InvoiceNoteTextBox = new TextBox();

        public InvoiceNoteForm()
        {
            InitializeComponent();

            Label invoiceNoteLabel = new Label();
            invoiceNoteLabel.Text = "Invoice Note";
            invoiceNoteLabel.Location = new Point(10, 10);
            invoiceNoteLabel.AutoSize = true;
            this.Controls.Add(invoiceNoteLabel);

            InvoiceNoteTextBox.Text = InvoiceTemplateNoteDatabase.GetNote();
            InvoiceNoteTextBox.Location = new Point(10, 25);
            InvoiceNoteTextBox.Size = new Size(260, 50);
            this.Controls.Add(InvoiceNoteTextBox);

            Button okButton = new Button();
            okButton.Location = new Point(10, 55);
            okButton.Size = new Size(50, 25);
            okButton.Text = "OK";
            okButton.Click += OkButton_Click;
            this.Controls.Add(okButton);

        }

        
        private void OkButton_Click(object sender, EventArgs e)
        {
            InvoiceTemplateNoteDatabase.EditNote(InvoiceNoteTextBox.Text);
            this.Close();
        }

        
    }
}
