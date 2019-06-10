using System;
using MySql.Data.MySqlClient;

namespace InvoiceMaker
{
    static class Database
    {

        internal static void DropTables()
        {
            MySqlConnection conn = new MySqlConnection(LoginInfo.LoginCreds);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;

                sql = "DROP TABLE IF EXISTS InvoiceTemplateNote;";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                
                sql = "DROP TABLE IF EXISTS InvoiceContents;";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = "DROP TABLE IF EXISTS Invoices;";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = "DROP TABLE IF EXISTS Customers;";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = "DROP TABLE IF EXISTS Products;";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = "DROP TABLE IF EXISTS ProvinceTax;";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
        }

        internal static void DropCustomers()
        {
            MySqlConnection conn = new MySqlConnection(LoginInfo.LoginCreds);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;

                sql = "DROP TABLE IF EXISTS Customers;";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
        }




        internal static void CreateTables()
        {
            MySqlConnection conn = new MySqlConnection(LoginInfo.LoginCreds);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;


                sql = "CREATE TABLE IF NOT EXISTS InvoiceTemplateNote (" +
                  "NoteID int NOT NULL AUTO_INCREMENT," +
                  "Note varchar(100) NOT NULL," +
                  "PRIMARY KEY (NoteID)" +
                  ");";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                try
                {
                    sql = "INSERT INTO InvoiceTemplateNote VALUES (" +
                   1 + "," +
                   "''" +
                   ");";
                    cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException e)
                {
                    //its fine
                }
               


                sql = "CREATE TABLE IF NOT EXISTS ProvinceTax (" +
                  "Province varchar(3) NOT NULL," +
                  "PST int NOT NULL," +
                  "GST int NOT NULL," +
                  "PRIMARY KEY (Province)" +
                  ");";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();


                sql = "CREATE TABLE IF NOT EXISTS Customers (" +
                    "StoreID int NOT NULL AUTO_INCREMENT," +
                    "StoreName varchar(50) NOT NULL," +
                    "StoreDetails varchar(50)," +
                    "StoreSpecialNotes varchar(50)," +
                    "EmailAddress varchar(50)," +
                    "StreetAddress varchar(50)," +
                    "CityAddress varchar(50)," +
                    "ProvinceAddress varchar(50)," +
                    "PostalCodeAddress varchar(50)," +
                    "StoreContact varchar(50)," +
                    "PhoneNumber varchar(15)," +
                    "PaymentTerms varchar(50)," +
                    "ShippingInstructions varchar(50)," +
                    "Province varchar(3) NOT NULL," +
                    "Rep varchar(30)," +
                    "PRIMARY KEY (StoreID)," +
                    "FOREIGN KEY (Province) REFERENCES ProvinceTax(Province)" +
                    ");";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();


                sql = "CREATE TABLE IF NOT EXISTS Products (" +
                    "ItemNo varchar(20) NOT NULL," +
                    "ItemDesc varchar(100) NOT NULL," +
                    "PerCarton int NOT NULL," +
                    "Location varchar(20) NOT NULL," +
                    "Cost decimal(10,2) NOT NULL," +
                    "SellPrice decimal(10,2) NOT NULL," +
                    "UPC bigint," +
                    "SpecialNotes varchar(100)," +
                    "PRIMARY KEY (ItemNo)" +
                    ");";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();


                sql = "CREATE TABLE IF NOT EXISTS Invoices (" +
                   "InvoiceID int NOT NULL AUTO_INCREMENT," +
                   "StoreID int NOT NULL," +
                   "PurchaseOrder varchar(20)," +
                   "InvoiceNo varchar(10)," +
                   "PRIMARY KEY (InvoiceID)," +
                   "FOREIGN KEY (StoreID) REFERENCES Customers(StoreID) ON DELETE CASCADE" +
                   ");";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();


                sql = "CREATE TABLE IF NOT EXISTS InvoiceContents (" +
                   "EntryID bigint NOT NULL AUTO_INCREMENT," +
                   "InvoiceID int NOT NULL," +
                   "ItemNo varchar(20) NOT NULL," +
                   "Quantity int NOT NULL," +
                   "Backorder int DEFAULT 0," +
                   "SpecialNotes varchar(40)," +
                   "BackorderSpecialNotes varchar(40)," +
                   "PRIMARY KEY (EntryID)," +
                   "FOREIGN KEY (InvoiceID) REFERENCES Invoices(InvoiceID) ON DELETE CASCADE," +
                   "FOREIGN KEY (ItemNo) REFERENCES Products(ItemNo) ON DELETE CASCADE" +
                   ");";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();


        }

       
    }
}
