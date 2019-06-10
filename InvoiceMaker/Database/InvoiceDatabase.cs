using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace InvoiceMaker
{
    static class InvoiceDatabase
    {
        internal static int AddInvoice(int storeID, String purchaseOrder, String invoiceNo)
        {
            MySqlConnection conn = new MySqlConnection(LoginInfo.LoginCreds);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                MySqlDataReader rdr;
                string sql;


                sql = "SELECT COUNT(InvoiceID) " +
                    "FROM Invoices;";
                cmd = new MySqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();
                rdr.Read();

                if (Int32.Parse(rdr[0].ToString()) != 0)
                {

                    rdr.Close();
                    sql = "INSERT INTO Invoices (StoreID, PurchaseOrder, InvoiceNo) VALUES (" +
                        storeID + "," +
                        "'" + purchaseOrder + "'," +
                        "'" + invoiceNo + "'" +
                        ");";
                    cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();

                    
                    sql = "SELECT MAX(InvoiceID) " +
                        "FROM Invoices;";
                    cmd = new MySqlCommand(sql, conn);
                    rdr = cmd.ExecuteReader();

                    rdr.Read();
                    int temp = Int32.Parse(rdr[0].ToString());
                    conn.Close();
                    rdr.Close();
                    return temp;
                }
                else
                {
                    rdr.Close();
                    AddInvoice(65, storeID, purchaseOrder, invoiceNo);
                    return 65;
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close(); 
            
            return 0;
        }


        internal static void AddInvoice(int invoiceID, int storeID, String purchaseOrder, String invoiceNo)
        {
            MySqlConnection conn = new MySqlConnection(LoginInfo.LoginCreds);
            try
            {
                conn.Open();
                MySqlCommand cmd;
               
                string sql;

                sql = "INSERT INTO Invoices VALUES (" +
                    invoiceID + "," +
                    storeID + "," +
                    "'" + purchaseOrder + "'," +
                    "'" + invoiceNo + "'" +
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


        internal static List<Invoice> GetAllInvoices()
        {

            List<Invoice> invoices = new List<Invoice>();
            MySqlConnection conn = new MySqlConnection(LoginInfo.LoginCreds);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                MySqlDataReader rdr;
                string sql;

                sql = "SELECT InvoiceID FROM Invoices ORDER BY InvoiceID ASC;";
                cmd = new MySqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Invoice temp = new Invoice(Int32.Parse(rdr[0].ToString()));
                    invoices.Add(temp);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            
            return invoices;
        }

        internal static List<Invoice> SearchInvoicesByInvoiceNo(String invoiceNo)
        {

            List<Invoice> invoices = new List<Invoice>();
            MySqlConnection conn = new MySqlConnection(LoginInfo.LoginCreds);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                MySqlDataReader rdr;
                string sql;

                sql = "SELECT InvoiceID FROM Invoices WHERE InvoiceNo LIKE '" + invoiceNo + "%';";
                cmd = new MySqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //Invoice temp = new Invoice(Int32.Parse(rdr[0].ToString()));
                    //invoices.Add(temp);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            

            return invoices;
        }


        internal static void DeleteInvoice(int invoiceID)
        {
            MySqlConnection conn = new MySqlConnection(LoginInfo.LoginCreds);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;

                sql = "DELETE FROM Invoices " +
                   " WHERE InvoiceID = " + invoiceID +
                   ";";
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
