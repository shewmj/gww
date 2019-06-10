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
    public partial class ProvinceTaxesForm : Form
    {
        ListView provinceTaxesList = new ListView();

        public ProvinceTaxesForm()
        {
            InitializeComponent();
            provinceTaxesList.Size = new Size(200,300);
            provinceTaxesList.Location = new Point(40, 100);

            provinceTaxesList.Columns.Add("Province Tax", 100, HorizontalAlignment.Left);
            provinceTaxesList.Columns.Add("GST", 50, HorizontalAlignment.Left);
            provinceTaxesList.Columns.Add("PST", 50, HorizontalAlignment.Left);
           
            provinceTaxesList.GridLines = true;
            provinceTaxesList.Scrollable = true;
            provinceTaxesList.View = System.Windows.Forms.View.Details;
            provinceTaxesList.DoubleClick += ProvinceTaxesList_DoubleClick;

            this.Controls.Add(provinceTaxesList);

            Button addButton = new Button();
            addButton.Location = new Point(30, 410);
            addButton.Size = new Size(70, 30);
            addButton.Text = "ADD";
            addButton.Click += AddButton_Click;
            this.Controls.Add(addButton);

            Button editButton = new Button();
            editButton.Location = new Point(110, 410);
            editButton.Size = new Size(70, 30);
            editButton.Text = "EDIT";
            editButton.Click += EditButton_Click;
            this.Controls.Add(editButton);

            Button deleteButton = new Button();
            deleteButton.Location = new Point(190, 410);
            deleteButton.Size = new Size(70, 30);
            deleteButton.Text = "DELETE";
            deleteButton.Click += DeleteButton_Click;
            this.Controls.Add(deleteButton);

            RefreshView();

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (provinceTaxesList.SelectedItems.Count > 0)
            {
                var confirmResult = MessageBox.Show("Are you sure you want to Delete these item(s)?",
                                                 "Confirm Delete!!",
                                                 MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    foreach (ListViewItem l in provinceTaxesList.SelectedItems)
                    {
                        ProvinceTaxDatabase.DeleteProvinceTax(l.SubItems[0].Text);
                    }
                    RefreshView();
                }
                else
                {
                    // If 'No', do something here.
                }
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem l in provinceTaxesList.SelectedItems)
            {
                AddProvinceTaxForm addProvinceTaxForm = new AddProvinceTaxForm(l.SubItems[0].Text, Int32.Parse(l.SubItems[1].Text), Int32.Parse(l.SubItems[2].Text));
                addProvinceTaxForm.Size = new System.Drawing.Size(280, 200);
                addProvinceTaxForm.Show();
                this.Close();
            }
            
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddProvinceTaxForm addProvinceTaxForm = new AddProvinceTaxForm();
            addProvinceTaxForm.Size = new System.Drawing.Size(280, 200);
            addProvinceTaxForm.Show();
            this.Close();
        }

        private void ProvinceTaxesList_DoubleClick(object sender, EventArgs e)
        {
            AddProvinceTaxForm addProvinceTaxForm = new AddProvinceTaxForm(provinceTaxesList.SelectedItems[0].Text, Int32.Parse(provinceTaxesList.SelectedItems[0].SubItems[1].Text), Int32.Parse(provinceTaxesList.SelectedItems[0].SubItems[2].Text));
            addProvinceTaxForm.Size = new System.Drawing.Size(280, 200);
            addProvinceTaxForm.Show();
            this.Close();
        }

        private void RefreshView()
        {
            foreach (ListViewItem lvItem in provinceTaxesList.Items)
            {
                provinceTaxesList.Items.Remove(lvItem);
            }
            List<ProvinceTax> provinceList = ProvinceTaxDatabase.GetAllProvinces();
            foreach (ProvinceTax p in provinceList)
            {
                provinceTaxesList.Items.Add(new ListViewItem(new String[] { p.province, p.gst.ToString(), p.pst.ToString() }));

            }
        }
    }
}
