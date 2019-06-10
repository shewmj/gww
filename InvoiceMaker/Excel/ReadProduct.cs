using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelLibrary.SpreadSheet;

namespace InvoiceMaker
{
    public partial class ReadProduct : Form
    {
        internal List<String> errmsg;
        public ReadProduct()
        {
            InitializeComponent();
            listBox1.HorizontalScrollbar = true;
            save_button.Enabled = false;
        }

        private void CancelRead_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BrowseExcelProduct_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Excel Files|*.xls";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Workbook wb = null;
                textBox1.Text = openFileDialog1.FileName;
                try
                {
                    wb = Workbook.Load(openFileDialog1.FileName);
                }
                catch(IOException)
                {
                    MessageBox.Show("Error: Excel file is currently open. Close the file and try again"
                        , "File Open Error", MessageBoxButtons.OK);
                    return;
                }
                ExcelReadWindow excel = new ExcelReadWindow(wb);
                excel.ShowDialog();
                errmsg = excel.errors;

                if (errmsg.Count > 0)
                {
                    errmsg.Insert(0, "Total number of row errors: " + errmsg.Count);
                    listBox1.DataSource = errmsg;
                    save_button.Enabled = true;
                }
                else
                {
                    listBox1.DataSource = null;
                    save_button.Enabled = false;
                }

            }
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "txt";
            saveDialog.Filter = "txt files (*.txt)| *.txt";
            saveDialog.FileName = Path.GetFileNameWithoutExtension(textBox1.Text) + "_Log.txt";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                String logfile = saveDialog.FileName;
                using (StreamWriter fs = new StreamWriter(logfile))
                {
                    foreach (String str in listBox1.Items)
                    {
                        fs.WriteLine(str + '\n');
                    }
                }
            }
        }
    }
}
