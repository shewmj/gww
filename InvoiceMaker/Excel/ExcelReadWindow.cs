using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelLibrary.SpreadSheet;

namespace InvoiceMaker
{
    public partial class ExcelReadWindow : Form
    {
        
        Workbook ex;
        internal List<String> errors;
        public ExcelReadWindow(Workbook excelFile)
        {
            
            InitializeComponent();
            ex = excelFile;
            ProductDatabase.DeleteAllProducts();
            errors = new List<String>();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {  
            Product prod = new Product("", "", 0, "", 0, 0, 0);
            int tempCart;
            Int64 tempUPC;
            float tempCost, tempPrice;
            //Workbook ex = Workbook.Load(file);
            Worksheet worksheet = ex.Worksheets[0];
            int maxRow = worksheet.Cells.Rows.Count;
            double readProgress = 100d / maxRow;
            for (int row = 0; row < maxRow; ++row)
            {
                if(backgroundWorker1.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                String errmsg = String.Empty;
                
                if(worksheet.Cells[row, 1].Value != null && worksheet.Cells[row, 1]. Value.ToString().Length < 20)
                {
                    prod.ItemNo = worksheet.Cells[row, 1].Value.ToString();
                }
                else
                {
                    errmsg += (worksheet.Cells[row, 1].Value != null ? "Item number too long: " + worksheet.Cells[row, 1].Value
                        : "No Item Number detected") + " / ";
                }


                if (worksheet.Cells[row, 3].Value != null && worksheet.Cells[row, 3].Value.ToString().Length <20)
                {
                    prod.Location = worksheet.Cells[row, 3].Value.ToString();
                }
                else
                {
                    errmsg += (worksheet.Cells[row, 3].Value != null ? "Item Location too long: " + worksheet.Cells[row, 3].Value
                        : "No Item Location detected") + " / ";
                }
                
                if(worksheet.Cells[row, 4].Value != null && worksheet.Cells[row, 4].Value.ToString().Length < 100)
                {
                    prod.ItemDesc = worksheet.Cells[row, 4].Value.ToString();
                }
                else
                {
                    errmsg += (worksheet.Cells[row, 4].Value != null ? "Item Description too long: " + worksheet.Cells[row, 4].Value
                        : "No Item Description detected") + " / ";
                }


                if (worksheet.Cells[row, 5].Value != null && Int32.TryParse(worksheet.Cells[row, 5].Value.ToString(), out tempCart))
                {
                    prod.PerCarton = tempCart;
                }
                else
                {
                    //errmsg += (worksheet.Cells[row, 4].Value != null ? "Invalid Carton: " + worksheet.Cells[row, 4].Value
                    //    : "No Carton detected") + " / ";
                    prod.PerCarton = 1;
                }

                prod.Cost = 0;
                /*
                if (worksheet.Cells[row, 11].Value != null && Single.TryParse(worksheet.Cells[row, 11].Value.ToString(), out tempCost))
                {
                    prod.Cost = tempCost;
                }
                else
                {
                    errmsg += (worksheet.Cells[row, 11].Value != null ? "Invalid Cost: " + worksheet.Cells[row, 11].Value
                        : "No Cost detected") + " / ";
                }
                */

                if (worksheet.Cells[row, 13].Value != null && Single.TryParse(worksheet.Cells[row, 13].Value.ToString(), out tempPrice))
                {
                    prod.SellPrice = tempPrice;
                }
                else
                {
                    errmsg += (worksheet.Cells[row, 13].Value != null ? "Invalid Price: " + worksheet.Cells[row, 13].Value
                        : "No Price detected") + " / ";
                }

                if (worksheet.Cells[row, 10].Value != null && Int64.TryParse(worksheet.Cells[row, 10].Value.ToString(), out tempUPC))
                {
                    prod.UPC = tempUPC;
                }
                else
                {
                    prod.UPC = 0;
                }

                if(worksheet.Cells[row, 15].Value != null && worksheet.Cells[row, 15].Value.ToString().Length < 100)
                {
                    prod.SpecialNotes = worksheet.Cells[row, 15].Value.ToString();
                }
                else
                {
                    prod.SpecialNotes = String.Empty;
                }

                if(errmsg.Length != 0)
                {
                    errmsg = errmsg.Insert(0, "Error on spreadsheet row " + (row + 1) + ": ");
                    errors.Add(errmsg);
                    continue;
                }
                Product prodInDB = ProductDatabase.SearchProductByItemNo(prod.ItemNo);
                if (prodInDB == null)
                {
                    prod.ItemDesc = InsertEscape(prod.ItemDesc);
                    ProductDatabase.AddProduct(prod.ItemNo, prod.ItemDesc, prod.PerCarton, prod.Location, prod.Cost, prod.SellPrice, prod.UPC, prod.SpecialNotes);
                }
                else
                {
                    prod.ItemDesc = InsertEscape(prod.ItemDesc);
                    ProductDatabase.EditProduct(prod.ItemNo, prod.ItemNo, prodInDB.ItemDesc, prod.PerCarton, prod.Location, prod.Cost, prod.SellPrice, prod.UPC, prod.SpecialNotes);
                    /*
                    if (prodInDB.ItemDesc == prod.ItemDesc)
                    {
                        prod.ItemDesc = InsertEscape(prod.ItemDesc);
                        ProductDatabase.EditProduct(prod.ItemNo, prod.ItemNo, prod.ItemDesc, prod.PerCarton, prod.Location, prod.Cost, prod.SellPrice, prod.UPC);
                    }
                    else
                    {
                        HandleItemNoConflict(prod);
                    }*/
                }
                backgroundWorker1.ReportProgress((int)(readProgress * row));
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Value = 100;
            this.Close();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private String InsertEscape(String desc)
        {
            for (int index = 0; index < desc.Length; ++index)
            {
                if (desc.ElementAt<char>(index) == '\'')
                {
                    desc = desc.Insert(index, "'");
                    index++;
                }
            }
            return desc;
        }

        private void HandleItemNoConflict(Product prodToAdd)
        {
            char append = 'a';
            String tempItemNo = prodToAdd.ItemNo + append++;
         
            List<Product> prods = ProductDatabase.SearchProductsByItemNoOneWildCard(prodToAdd.ItemNo);
            for(int i = 0; i < prods.Count; i++)
            {
                if(prods[i].ItemNo == tempItemNo )
                {
                    if (prods[i].ItemDesc == prodToAdd.ItemDesc)
                    {
                        prodToAdd.ItemNo = tempItemNo;
                        prodToAdd.ItemDesc = InsertEscape(prodToAdd.ItemDesc);
                        ProductDatabase.EditProduct(prodToAdd.ItemNo, prodToAdd.ItemNo, prodToAdd.ItemDesc, prodToAdd.PerCarton, prodToAdd.Location, prodToAdd.Cost, prodToAdd.SellPrice, prodToAdd.UPC);
                        return;
                    }
                    else
                    {
                        tempItemNo = prodToAdd.ItemNo + append++;
                    }
                }
            }
            prodToAdd.ItemNo = tempItemNo;
            prodToAdd.ItemDesc = InsertEscape(prodToAdd.ItemDesc);
            ProductDatabase.AddProduct(prodToAdd.ItemNo, prodToAdd.ItemDesc, prodToAdd.PerCarton, prodToAdd.Location, prodToAdd.Cost, prodToAdd.SellPrice, prodToAdd.UPC);
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            if(backgroundWorker1.WorkerSupportsCancellation == true)
            {
                backgroundWorker1.CancelAsync();
            }
        }
    }
}
