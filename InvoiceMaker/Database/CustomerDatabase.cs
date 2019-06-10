using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace InvoiceMaker
{
    static class CustomerDatabase
    {

        internal static void AddCustomer(String storeName, String storeDetails, String storeSpecialNotes, String emailAddress, String streetAddress, String cityAddress, String provinceAddress, 
            String postalCodeAddress, String storeContact, String phoneNumber, String paymentTerms, String shippingInstructions, String province, String rep)
        {
            MySqlConnection conn = new MySqlConnection(LoginInfo.LoginCreds);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;

                /*
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
                  "Rep varchar(10)," +
                  "PRIMARY KEY (StoreID)," +
                  "FOREIGN KEY (Province) REFERENCES ProvinceTax(Province)" +

    */

              sql = "INSERT INTO Customers (StoreName, StoreDetails, StoreSpecialNotes, EmailAddress, StreetAddress, CityAddress, ProvinceAddress, PostalCodeAddress, " +
                    "StoreContact, PhoneNumber, PaymentTerms, ShippingInstructions, Province, Rep) " +
                    "VALUES (" +
                    "'" + storeName + "'," +
                    "'" + storeDetails + "'," +
                    "'" + storeSpecialNotes + "'," +
                    "'" + emailAddress + "'," +
                    "'" + streetAddress + "'," +
                    "'" + cityAddress + "'," +
                    "'" + provinceAddress + "'," +
                    "'" + postalCodeAddress + "'," +
                    "'" + storeContact + "'," +
                    "'" + phoneNumber + "'," +
                    "'" + paymentTerms + "'," +
                    "'" + shippingInstructions + "'," +
                    "'" + province + "'," +
                    "'" + rep + "'" +
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

     

        internal static void EditCustomer(int storeId, String storeName, String storeDetails, String storeSpecialNotes, String emailAddress, String streetAddress, String cityAddress, String provinceAddress, 
            String postalCodeAddress, String storeContact, String phoneNumber, String paymentTerms, String shippingInstructions, String province, String rep)
        {
            MySqlConnection conn = new MySqlConnection(LoginInfo.LoginCreds);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;

                sql = "UPDATE Customers " +
                    "SET StoreName = '" + storeName + "'" +
                    ",StoreDetails = '" + storeDetails + "'" +
                    ",StoreSpecialNotes = '" + storeSpecialNotes + "'" +
                    ",EmailAddress = '" + emailAddress + "'" +   
                    ",StreetAddress = '" + streetAddress + "'" +
                    ",CityAddress = '" + cityAddress + "'" +
                    ",ProvinceAddress = '" + provinceAddress + "'" +
                    ",PostalCodeAddress = '" + postalCodeAddress + "'" +
                    ",StoreContact = '" + storeContact + "'" +
                    ",PhoneNumber = '" + phoneNumber + "'" +
                    ",PaymentTerms = '" + paymentTerms + "'" +
                    ",ShippingInstructions = '" + shippingInstructions + "'" +
                    ",Province = '" + province + "'" +
                    ",Rep = '" + rep + "'" +
                    " WHERE StoreID = " + storeId +
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

      

        internal static void DeleteCustomer(int storeID)
        {
            MySqlConnection conn = new MySqlConnection(LoginInfo.LoginCreds);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;

                sql = "DELETE FROM Customers" +
                  " WHERE StoreID = " + storeID +
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

        internal static int GetStoreID(String storeName, String streetAddress)
        {
            MySqlConnection conn = new MySqlConnection(LoginInfo.LoginCreds);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                string sql;
                MySqlDataReader rdr;

                sql = "SELECT StoreID FROM Customers" +
                  " WHERE StoreName = '" + storeName + "' AND StreetAddress = '" + streetAddress + "'" +
                  ";";
                cmd = new MySqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    rdr.Read();
                    int temp = Int32.Parse(rdr[0].ToString());
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


        internal static List<Customer> SearchCustomersByStoreName(String storeName)
        {

            List<Customer> customerList = new List<Customer>();
            MySqlConnection conn = new MySqlConnection(LoginInfo.LoginCreds);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                MySqlDataReader rdr;
                string sql;

                sql = "SELECT * FROM Customers WHERE StoreName LIKE '%" + storeName + "%' ORDER BY StoreName ASC;";
                cmd = new MySqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Customer temp = new Customer(Int32.Parse(rdr[0].ToString()), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString(), rdr[5].ToString(), rdr[6].ToString(), 
                        rdr[7].ToString(), rdr[8].ToString(), rdr[9].ToString(), rdr[10].ToString(), rdr[11].ToString(), rdr[12].ToString(), rdr[13].ToString(), rdr[14].ToString());
                    customerList.Add(temp);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            
            return customerList;
        }

        internal static Customer SearchCustomersByID(int custID)
        {

            Customer customer = null;
            MySqlConnection conn = new MySqlConnection(LoginInfo.LoginCreds);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                MySqlDataReader rdr;
                string sql;

                sql = "SELECT * FROM Customers WHERE StoreID = " + custID + " ORDER BY StoreName ASC;";
                cmd = new MySqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    customer = new Customer(Int32.Parse(rdr[0].ToString()), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString(), rdr[5].ToString(), rdr[6].ToString(),
                        rdr[7].ToString(), rdr[8].ToString(), rdr[9].ToString(), rdr[10].ToString(), rdr[11].ToString(), rdr[12].ToString(), rdr[13].ToString(), rdr[14].ToString());
                    break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            
            return customer;
        }
    }
}
