using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using Dapper;
//using Spire.Xls;
//using NPOI.SS.UserModel;
//using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using System.Drawing;
//using Spire.Pdf;
//using Spire.Xls.Converter;
using System.Diagnostics;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using static System.Windows.Forms.DataFormats;
//using ExcelLibrary.SpreadSheet;

//using System.Runtime.InteropServices;
//using Excel = Microsoft.Office.Interop.Excel;

namespace InvoiceMaker
{

    public class Invoice
    {

        private static int CharW = 300;
        
        public String CompanyName { get; set; }
        public String CompanyAddress { get; set; }
        public String CompanyPhoneNumber { get; set; }
        public String CompanyFax { get; set; }
        public String CompanyTollFree { get; set; }
        public String GSTNo { get; set; }

        public Customer customer { get; set; }
        public int InvoiceID { get; set; }

        public String PurchaseOrder { get; set; }
        public List<Product> Items { get; set; }
       

        private ISheet wsheet;
        
        
        public Invoice(int invoiceID)
        {
            // WholeSale Company Information
            CompanyName = "Great West Wholesale LTD";
            CompanyAddress = "1670 PANDORA ST. VANCOUVER, BC V5L 1L6";
            CompanyPhoneNumber = "604-255-9588";
            CompanyFax = "604-255-9589";
            CompanyTollFree = "1-800-901-9588";
            GSTNo = "R102186178";

            Items = new List<Product>();


            MySqlConnection conn = new MySqlConnection(LoginInfo.LoginCreds);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                MySqlDataReader rdr;
                String sql;

                sql = "SELECT * FROM Invoices WHERE InvoiceID = " + invoiceID + ";";
                cmd = new MySqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    rdr.Read();

                    InvoiceID = Int32.Parse(rdr[0].ToString());

                    customer = CustomerDatabase.SearchCustomersByID(Int32.Parse(rdr[1].ToString()));

                    PurchaseOrder = rdr[2].ToString();

                    

                    List<InvoiceContentInfo> items = InvoiceContentsDatabase.GetInvoiceContents(InvoiceID);
                    Product temp;
                    for (int i = 0; i < items.Count; i++)
                    {
                        temp = ProductDatabase.SearchProductByItemNo(items[i].ItemNo);
                        temp.SpecialNotes = items[i].SpecialNotes;
                        temp.Quantity = items[i].Quantity;
                        temp.BackOrder = items[i].Backorder;
                        temp.BackOrderSpecialNotes = items[i].BackOrderSpecialNotes;
                        Items.Add(temp);

                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();


        }

        internal void SaveToExcel()
        {


            int rows = 0;

            int tallRow = 14;
            int medRow = 12;
            

            IWorkbook wb = new XSSFWorkbook();
            IRow row;
            ICell cell;
            wsheet = wb.CreateSheet("Sheet1");
            
            IFont font;
            font = wb.CreateFont();
            font.FontHeight = 10;
            font.FontName = "Arial";
            ICellStyle DefaultStyle = wb.CreateCellStyle();
            DefaultStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;
            DefaultStyle.SetFont(font);

            font = wb.CreateFont();
            font.FontHeight = 14;
            font.FontName = "Arial";
            font.IsBold = true;
            ICellStyle TitleStyle = wb.CreateCellStyle();
            TitleStyle.SetFont(font);

            font = wb.CreateFont();
            font.FontHeight = 12;
            font.FontName = "Arial";
            font.IsBold = true;
            ICellStyle InvoiceStyle = wb.CreateCellStyle();
            InvoiceStyle.SetFont(font);

            font = wb.CreateFont();
            font.FontHeight = 8;
            font.FontName = "Arial";
            ICellStyle SmallStyle = wb.CreateCellStyle();
            SmallStyle.SetFont(font);

            font = wb.CreateFont();
            font.FontHeight = 10;
            font.FontName = "Arial";
            ICellStyle MoneyStyle = wb.CreateCellStyle();
            MoneyStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Right;
            MoneyStyle.SetFont(font);
            MoneyStyle.DataFormat = 2;

            font = wb.CreateFont();
            font.FontHeight = 10;
            font.FontName = "Arial";
            font.IsBold = true;
            ICellStyle MoneyBoldStyle = wb.CreateCellStyle();
            MoneyBoldStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Right;
            MoneyBoldStyle.SetFont(font);
            MoneyBoldStyle.DataFormat = 2;


            font = wb.CreateFont();
            font.FontHeight = 10;
            font.FontName = "Arial";
            font.IsBold = true;
            ICellStyle BoldStyle = wb.CreateCellStyle();
            BoldStyle.SetFont(font);

            font = wb.CreateFont();
            font.FontHeight = 10;
            font.FontName = "Arial";
            font.IsBold = true;
            ICellStyle RightAlignBoldStyle = wb.CreateCellStyle();
            RightAlignBoldStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Right;
            RightAlignBoldStyle.SetFont(font);

            font = wb.CreateFont();
            font.FontHeight = 10;
            font.FontName = "Arial";
            ICellStyle RightAlignStyle = wb.CreateCellStyle();
            RightAlignStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Right;
            RightAlignStyle.SetFont(font);

            wsheet.SetColumnWidth(0, CharW * 5);
            wsheet.SetColumnWidth(1, CharW * 3);
            wsheet.SetColumnWidth(2, CharW * 3);
            wsheet.SetColumnWidth(3, CharW * 8);
            wsheet.SetColumnWidth(4, CharW * 7);
            wsheet.SetColumnWidth(5, CharW * 20);
            wsheet.SetColumnWidth(6, CharW * 2 + 100);
            wsheet.SetColumnWidth(7, CharW * 2 + 100);
            wsheet.SetColumnWidth(8, CharW * 6);
            wsheet.SetColumnWidth(9, CharW * 9);
            wsheet.SetColumnWidth(10, CharW);

            wsheet.DefaultRowHeight = 250;


           
            
            row = wsheet.CreateRow(rows++);
            row.HeightInPoints = 15;
            
            cell = row.CreateCell(0);
            cell.CellStyle = TitleStyle;
            cell.SetCellValue("GREAT WEST WHOLESALE LTD");
            cell = row.CreateCell(8);
            cell.CellStyle = DefaultStyle;
            cell.SetCellValue(InvoiceID);
            cell = row.CreateCell(9);
            cell.CellStyle = SmallStyle;
            cell.SetCellValue("gst no. R102186178");

            row = wsheet.CreateRow(rows++);
            row.HeightInPoints = tallRow;
            
            cell = row.CreateCell(0);
            cell.CellStyle = BoldStyle;
            cell.SetCellValue("1670 PANDORA ST. VANCOUVER, BC V5L 1L6");
            cell = row.CreateCell(9);
            cell.CellStyle = InvoiceStyle;
            cell.SetCellValue("INVOICE");

            row = wsheet.CreateRow(rows++);
            row.HeightInPoints = medRow;
            
            cell = row.CreateCell(0);
            cell.CellStyle = DefaultStyle;
            cell.SetCellValue("604-255-9588  fax 604-255-9589  1-800-901-9588  greatwestw@gmail.com");

            rows++;
            
            row = wsheet.CreateRow(rows++);
            row.HeightInPoints = tallRow;
            
            cell = row.CreateCell(0);
            cell.CellStyle = DefaultStyle;
            cell.SetCellValue("Ship to:");
            cell = row.CreateCell(3);
            cell.CellStyle = BoldStyle;
            cell.SetCellValue(customer.StoreName);
            cell = row.CreateCell(6);
            cell.CellStyle = DefaultStyle;
            cell.SetCellValue("INVOICE NO.");
            cell = row.CreateCell(9);
            cell.CellStyle = BoldStyle;
            

            row = wsheet.CreateRow(rows++);
            row.HeightInPoints = medRow;
            
          

            cell = row.CreateCell(3);
            cell.CellStyle = DefaultStyle;
            if (customer.StoreDetails.Length != 0)
            {
                cell.SetCellValue(customer.StoreDetails);
            }
            else
            {
                cell.SetCellValue(customer.StreetAddress);
            }
            
            cell = row.CreateCell(6);
            cell.CellStyle = DefaultStyle;
            cell.SetCellValue("DATE:");

            cell = row.CreateCell(9);
            cell.CellStyle = DefaultStyle;
            //Char[] delim = { ' ' };
            //String[] date = System.DateTime.Today.ToLongDateString().Split(delim, 2);
            //String zz = date[1].ToUpper();
            cell.SetCellValue(System.DateTime.Today.ToLongDateString().ToUpper());
            
           
            row = wsheet.CreateRow(rows++);
            row.HeightInPoints = medRow;
            
            cell = row.CreateCell(3);
            cell.CellStyle = DefaultStyle;
            if (customer.StoreDetails.Length != 0)
            {
                cell.SetCellValue(customer.StreetAddress);
            }
            else
            {
                cell.SetCellValue(customer.CityAddress + ", " + customer.ProvinceAddress + " " + customer.PostalCodeAddress);
            }
            cell = row.CreateCell(6);
            cell.CellStyle = DefaultStyle;
            cell.SetCellValue("TERMS:");
            cell = row.CreateCell(9);
            cell.CellStyle = DefaultStyle;
            cell.SetCellValue(customer.PaymentTerms);

            row = wsheet.CreateRow(rows++);
            row.HeightInPoints = medRow;

            cell = row.CreateCell(3);
            cell.CellStyle = DefaultStyle;
            if (customer.StoreDetails.Length != 0)
            {
                cell.SetCellValue(customer.CityAddress + ", " + customer.ProvinceAddress + " " + customer.PostalCodeAddress);
            }
            else
            {   
                cell.SetCellValue("tel: " + customer.PhoneNumber);
            }
          
            cell = row.CreateCell(6);
            cell.CellStyle = DefaultStyle;
            cell.SetCellValue("SHIP:");
            cell = row.CreateCell(9);
            cell.CellStyle = DefaultStyle;
            cell.SetCellValue(customer.ShippingInstructions);

            row = wsheet.CreateRow(rows++);
            row.HeightInPoints = tallRow;

            cell = row.CreateCell(3);
            cell.CellStyle = DefaultStyle;
            if (customer.StoreDetails.Length != 0)
            {
                cell.SetCellValue("tel: " + customer.PhoneNumber);
            }
            else
            {
                if (customer.Rep.Length != 0)
                {
                    cell.CellStyle = BoldStyle;
                    cell.SetCellValue("rep: " + customer.Rep);
                }
                
            }

            cell = row.CreateCell(6);
            cell.CellStyle = BoldStyle;
            cell.SetCellValue("PURCHASE ORDER: PO " + PurchaseOrder);

            if (customer.StoreDetails.Length != 0)
            {
                row = wsheet.CreateRow(rows++);
                row.HeightInPoints = medRow;
                if (customer.Rep.Length != 0)
                {
                    cell = row.CreateCell(3);
                    cell.CellStyle = BoldStyle;
                    cell.SetCellValue("rep: " + customer.Rep);
                }

            }
            else
            {
                rows++;
            }
            

            row = wsheet.CreateRow(rows++);
            row.HeightInPoints = tallRow;
            cell = row.CreateCell(1);
            cell.CellStyle = InvoiceStyle;
            cell.SetCellValue(" ** " + InvoiceTemplateNoteDatabase.GetNote());

            row = wsheet.CreateRow(rows++);
            row.HeightInPoints = tallRow;
            cell = row.CreateCell(1);
            cell.CellStyle = InvoiceStyle;
            cell.SetCellValue("   " + customer.StoreSpecialNotes);

            row = wsheet.CreateRow(rows++);
            row.HeightInPoints = medRow;
            cell = row.CreateCell(0);
            cell.CellStyle = DefaultStyle;
            cell.SetCellValue("QUANTITY");
            cell = row.CreateCell(3);
            cell.CellStyle = DefaultStyle;
            cell.SetCellValue("ITEM NO.");
            cell = row.CreateCell(5);
            cell.CellStyle = DefaultStyle;
            cell.SetCellValue("DESCRIPTION");
            cell = row.CreateCell(8);
            cell.CellStyle = DefaultStyle;
            cell.SetCellValue("COST");
            cell = row.CreateCell(9);
            cell.CellStyle = DefaultStyle;
            cell.SetCellValue("AMOUNT");


            row = wsheet.CreateRow(rows++);
            row.HeightInPoints = medRow;
            
            cell = row.CreateCell(0);
            cell.CellStyle = BoldStyle;
            cell.SetCellValue("-------------------------------------------------------------------------------------------------------------------");

            int itemCount = Items.Count;
            
            /////////////////////////////////////////////////////////////////////////////////////////////////////////
            Items = Items.OrderBy(o => o.Location).ToList();
            for (int i = 0; i < itemCount; i++)
            {
                row = wsheet.CreateRow(rows++);
                row.HeightInPoints = medRow;
                    
                cell = row.CreateCell(0);
                cell.CellStyle = RightAlignStyle;
                   
                cell.SetCellValue(Items[i].Quantity);

                cell = row.CreateCell(9);
                cell.CellStyle = MoneyStyle;
                cell.SetCellFormula("ROUND(A" + rows + "*I" + rows + ",2)");


                if (Items[i].Quantity / Items[i].PerCarton >= 1)
                {
                    cell = row.CreateCell(2);
                    cell.CellStyle = DefaultStyle;
                    //cell.SetCellFormula("ROUND(" + Items[i].Quantity + "/" + Items[i].PerCarton + ",2)");
                    cell.SetCellValue(((Items[i].Quantity * 1.0) / (Items[i].PerCarton * 1.0)).ToString("0.0"));
                }
                    
                cell = row.CreateCell(3);
                cell.CellStyle = DefaultStyle;
                cell.SetCellValue(Items[i].ItemNo);
                cell = row.CreateCell(4);
                cell.CellStyle = DefaultStyle;
                cell.SetCellValue(Items[i].Location);
                cell = row.CreateCell(5);
                cell.CellStyle = DefaultStyle;
                cell.SetCellValue(Items[i].ItemDesc);
                cell = row.CreateCell(7);
                cell.CellStyle = RightAlignStyle;
                cell.SetCellValue(Items[i].PerCarton);
                cell = row.CreateCell(8);
                cell.CellStyle = MoneyStyle;
                cell.SetCellValue(Items[i].SellPrice);

                    



                if (Items[i].SpecialNotes.Length != 0)
                {
                    cell = row.CreateCell(11);
                    cell.CellStyle = DefaultStyle;
                    cell.SetCellValue(Items[i].SpecialNotes);
                }
                    
                    
            }


            row = wsheet.CreateRow(rows++);
            row.HeightInPoints = medRow;
                
            cell = row.CreateCell(9);
            cell.CellStyle = RightAlignBoldStyle;
            cell.SetCellValue("---------------");

            row = wsheet.CreateRow(rows++);
            row.HeightInPoints = medRow;
                
            cell = row.CreateCell(9);
            cell.CellStyle = MoneyBoldStyle;
            cell.SetCellFormula(String.Format("SUM(J15:J" + (rows - 2) + ")"));

            ProvinceTax pt = ProvinceTaxDatabase.GetProvinceByName(customer.Province);

            row = wsheet.CreateRow(rows++);
            row.HeightInPoints = medRow;
                
            cell = row.CreateCell(5);
            cell.CellStyle = BoldStyle;
            cell.SetCellValue("GST " + pt.gst + "%");
            cell = row.CreateCell(9);
            cell.CellStyle = MoneyBoldStyle;
            cell.SetCellFormula("ROUND(J" + (rows - 1) + "*" + (pt.gst / 100.0) + ",2)");
            //cell.SetCellFormula(String.Format("J" + (rows - 1) + " * " + (pt.gst/ 100.0)));


            if (pt.pst != 0)
            {
                row = wsheet.CreateRow(rows++);
                row.HeightInPoints = medRow;
                cell = row.CreateCell(5);
                cell.CellStyle = BoldStyle;
                cell.SetCellValue("PST " + pt.pst + "%");
                cell = row.CreateCell(9);
                cell.CellStyle = MoneyBoldStyle;
                cell.SetCellFormula("ROUND(J" + (rows - 2) + "*" + (pt.pst / 100.0) + ",2)");
                //cell.SetCellFormula(String.Format("J" + (rows - 2) + " * " + (pt.pst / 100.0)));
            }

            row = wsheet.CreateRow(rows++);
            row.HeightInPoints = medRow;
                
            cell = row.CreateCell(9);
            cell.CellStyle = RightAlignBoldStyle;
            cell.SetCellValue("---------------");

            row = wsheet.CreateRow(rows++);
            row.HeightInPoints = tallRow;
                
            cell = row.CreateCell(5);
            cell.CellStyle = BoldStyle;
            cell.SetCellValue("INVOICE TOTAL");
            cell = row.CreateCell(9);
            cell.CellStyle = MoneyBoldStyle;

            if (pt.pst != 0)
            {
                cell.SetCellFormula(String.Format("SUM(J" + (rows - 4) + ":J" + (rows - 2) + ")"));
            }
            else
            {
                cell.SetCellFormula(String.Format("SUM(J" + (rows - 3) + ":J" + (rows - 2) + ")"));
            }


            
            int rowEnd = 400;
            int lastColumn = 25;
            IRow r;
            for (int rowNum = 0; rowNum < rows; rowNum++)
            {
                if ((r = wsheet.GetRow(rowNum)) != null)
                {
                    for (int cn = 0; cn < lastColumn; cn++)
                    {
                        if ((cell = r.GetCell(cn)) == null)
                        {
                            cell = r.CreateCell(cn);
                            cell.CellStyle = DefaultStyle;
                        }
                    }       
                }
                else
                {
                    r = wsheet.CreateRow(rowNum); //getRow(rowNum);
                    r.HeightInPoints = medRow;
                    for (int cn = 0; cn < lastColumn; cn++)
                    {
                        cell = r.CreateCell(cn);
                        cell.CellStyle = DefaultStyle;

                    }
                }
                
               
            }
            
            for (int rowNum = rows; rowNum < rowEnd; rowNum++)
            {          
                r = wsheet.CreateRow(rowNum); //getRow(rowNum);
                r.HeightInPoints = medRow;
                for (int cn = 0; cn < lastColumn; cn++)
                {  
                    cell = r.CreateCell(cn);
                    cell.CellStyle = DefaultStyle;

                }
            }

            string deskPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);


            FileStream stream = new FileStream(@"" + deskPath + "\\Invoices\\Progress\\" + InvoiceID + customer.StoreName + ".xlsx", FileMode.Create, FileAccess.Write);
            wb.Write(stream);
            FileStream stream2 = new FileStream(@"" + deskPath + "\\Invoices\\Original\\" + InvoiceID + customer.StoreName + ".xlsx", FileMode.Create, FileAccess.Write);
            wb.Write(stream2);

            PrintExcel();
        }
        
        
        public void PrintExcel()
        {

            string deskPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (IsFileLocked(this.InvoiceID))
            {
                MessageBox.Show("Selected file is open somewhere else. Close the File and try again.", "Error", MessageBoxButtons.OK);
                return;
            }
            Process.Start(@"" + deskPath + "\\Invoices\\Progress\\" + InvoiceID + customer.StoreName + ".xlsx");
        }

        

        internal static bool IsFileLocked(int invoiceID)
        {
            string deskPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            FileStream stream = null;
            Invoice temp = new Invoice(invoiceID);
            try
            {
                stream = new FileStream(deskPath + "\\Invoices\\Progress\\" + invoiceID + temp.customer.StoreName + ".xlsx", FileMode.Open);
            }
            catch (IOException)
            {

                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return false;
        }

 


    }
}
