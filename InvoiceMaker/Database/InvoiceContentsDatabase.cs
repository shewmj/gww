using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace InvoiceMaker
{
    static class InvoiceContentsDatabase
    {

        internal static void AddInvoiceContent(int invoiceID, String itemNo, int quantity, String specialNotes) 
        {
            MySqlConnection conn = new MySqlConnection(LoginInfo.LoginCreds);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;

                sql = "INSERT INTO InvoiceContents (InvoiceID, ItemNo, Quantity, SpecialNotes) VALUES (" +
                    invoiceID + "," +
                    "'" + itemNo + "'," + 
                    quantity + "," +
                    "'" + specialNotes + "'" +
                    ");";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done Inserting Details.");
        }



        internal static void EditInvoiceContent(int entryID, int invoiceID, String itemNo, int quantity, String specialNotes)
        {
            MySqlConnection conn = new MySqlConnection(LoginInfo.LoginCreds);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;

                sql = "UPDATE InvoiceContents " +
                  "SET ItemNo = '" + itemNo +
                  "',Quantity = " + quantity +
                  ",InvoiceID = " + invoiceID +
                  ",SpecialNotes = '" + specialNotes +
                  "' WHERE EntryID = " + entryID +
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



        internal static void DeleteInvoiceContent(int entryID)
        {
            MySqlConnection conn = new MySqlConnection(LoginInfo.LoginCreds);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;

                sql = "DELETE FROM InvoiceContents" +
                  " WHERE EntryID = " + entryID +
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




        internal static int GetEntryID(int invoiceID, String itemNo)
        {
            MySqlConnection conn = new MySqlConnection(LoginInfo.LoginCreds);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;
                MySqlDataReader rdr;

                sql = "SELECT EntryID FROM InvoiceContents" +
                  " WHERE InvoiceID = " + invoiceID + " AND ItemNo = '" + itemNo + 
                  "';";
                cmd = new MySqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();


                if (rdr.HasRows)
                {
                    rdr.Read();
                    int temp =  Int32.Parse(rdr[0].ToString());
                    conn.Close();
                    rdr.Close();
                    return temp;
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
             
            return 0;

        }



        internal static List<InvoiceContentInfo> GetInvoiceContents(int invoiceID)
        {
            MySqlConnection conn = new MySqlConnection(LoginInfo.LoginCreds);
            List<InvoiceContentInfo> items = new List<InvoiceContentInfo>();
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;
                MySqlDataReader rdr;

                sql = "SELECT * FROM InvoiceContents" +
                  " WHERE InvoiceID = " + invoiceID +
                  " ORDER BY itemNo ASC;";
                cmd = new MySqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();
                InvoiceContentInfo temp;


                while (rdr.Read())
                {
                    temp = new InvoiceContentInfo(rdr[2].ToString(), Int32.Parse(rdr[3].ToString()), Int32.Parse(rdr[4].ToString()), rdr[5].ToString(), rdr[6].ToString());
                    items.Add(temp);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
             
            
            return items;
       
        }


        internal static void UpdateBackorder(int entryID, int backorder)
        {
            MySqlConnection conn = new MySqlConnection(LoginInfo.LoginCreds);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;

                sql = "UPDATE InvoiceContents " +
                  "SET Backorder = " + backorder +
                  " WHERE EntryID = " + entryID +
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

        internal static void UpdateBackorderSpecialNotes(int entryID, String specialNotes)
        {
            MySqlConnection conn = new MySqlConnection(LoginInfo.LoginCreds);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;

                sql = "UPDATE InvoiceContents " +
                  "SET BackorderSpecialNotes = '" + specialNotes + "'" +
                  " WHERE EntryID = " + entryID +
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

        internal static List<InvoiceContentInfo> GetBackorderedItems(int invoiceID)
        {
            MySqlConnection conn = new MySqlConnection(LoginInfo.LoginCreds);
            List<InvoiceContentInfo> items = new List<InvoiceContentInfo>();
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;
                MySqlDataReader rdr;

                sql = "SELECT * FROM InvoiceContents" +
                  " WHERE InvoiceID = " + invoiceID +
                  " AND Backorder > 0" +
                  " ORDER BY itemNo ASC;";
                cmd = new MySqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();
                InvoiceContentInfo temp;


                while (rdr.Read())
                {
                    temp = new InvoiceContentInfo(rdr[2].ToString(), Int32.Parse(rdr[3].ToString()), Int32.Parse(rdr[4].ToString()), rdr[5].ToString(), rdr[6].ToString());
                    items.Add(temp);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
             

            return items;

        }





    }
}
