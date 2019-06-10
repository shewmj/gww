using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceMaker
{
    static class InvoiceTemplateNoteDatabase
    {
        
        internal static void AddNote(String Note)
        {
            MySqlConnection conn = new MySqlConnection(LoginInfo.LoginCreds);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;

                sql = "INSERT INTO InvoiceTemplateNote (Note) VALUES (" +
                    "'" + Note + "'" +
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



        internal static void EditNote(String Note)
        {
            MySqlConnection conn = new MySqlConnection(LoginInfo.LoginCreds);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;
                MySqlDataReader rdr;


                sql = "UPDATE InvoiceTemplateNote " +
                    "SET Note = '" + Note + "'" +
                    " WHERE NoteID = " + 1 +
                    ";";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

         

                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
        }


        internal static String GetNote()
        {

            String note = String.Empty;

            MySqlConnection conn = new MySqlConnection(LoginInfo.LoginCreds);
            try
            {

                conn.Open();
                MySqlCommand cmd;
                MySqlDataReader rdr;
                string sql;

                sql = "SELECT * FROM InvoiceTemplateNote WHERE NoteID = " + 1 + ";";
                cmd = new MySqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    note = rdr[1].ToString();
                }





                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();

            return note;



        }






    }
}
