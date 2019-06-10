using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace InvoiceMaker
{
    static class Program
    {

        [STAThread]
        static void Main()
        {

            string subPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Invoices";
            string subPath1 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Invoices\\Progress";
            string subPath2 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Invoices\\Original";

            //Console.WriteLine(subPath);

            System.IO.Directory.CreateDirectory(subPath);
            System.IO.Directory.CreateDirectory(subPath1);
            System.IO.Directory.CreateDirectory(subPath2);


            Database.CreateTables();

            NSeed();







            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ViewInvoice viewInvoice = new ViewInvoice();
            viewInvoice.Size = new System.Drawing.Size(600, 700);
            Application.Run(viewInvoice);






        }

        

        private static void NSeed()
        {

            Database.DropTables();
            Database.CreateTables();


           

            int num = 10;


            SeedTaxes(num);
            SeedCustomers(num);
            SeedToys(num);
            SeedInvoices(num);

            InvoiceTemplateNoteDatabase.AddNote("Template Note");
            



            

        }


        private static void SeedTaxes(int num)
        {
            for (int i = 1; i < num; i++)
            {
                ProvinceTaxDatabase.AddProvinceTax("TA" + i, i, i);
            }
           
        }

        private static void SeedCustomers(int num)
        {

            for (int i = 1; i < num; i++)
            {
                CustomerDatabase.AddCustomer("ExBusiness" + i, "Details" + i, "SpecialNotes" + i, "email" + i + "@gmail.com", "address" + i, "city" + i, "PR", "PostCo",
                    "contact" + i, "6041111111", "terms" + i, "shipping" + i, "TA" + i, "rep" + i);
            }

        }

        private static void SeedToys(int num)
        {

            for (int i = 1; i < num; i++)
            {
                ProductDatabase.AddProduct("A" + i, "desc" + i, i, "A" + i, i, i, i);
            }
            for (int i = 1; i < num; i++)
            {
                ProductDatabase.AddProduct("B" + i, "desc" + i, i, "B" + i, i, i, i);
            }

        }


        private static void SeedInvoices(int num)
        {
            int invoiceID = 1;

            //make invoices for 5 customers
            for (int i = 1; i < num; i++)
            {

                //make 5 invoice per customer
                for (int j = 1; j < 5; j++)
                {
                    InvoiceDatabase.AddInvoice(invoiceID, i, "order" + j, "invoice" + j);

                    //make num items in each invoice
                    for (int m = 1; m < num; m++)
                    {
                        InvoiceContentsDatabase.AddInvoiceContent(invoiceID, "A" + m, m, "notes");
                    }


                    Invoice inv = new Invoice(invoiceID);
                    inv.SaveToExcel();
                    invoiceID++;



                }
                
            }
            
        }


        

    }

}
