using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceMaker
{
    class ProvinceTax
    {
        public String province { get; set; }
        public int gst { get; set; }
        public int pst { get; set; }

        public ProvinceTax(String province, int gst, int pst)
        {
            this.province = province;
            this.gst = gst;
            this.pst = pst;
        }


        public ProvinceTax(String province)
        {

            this.province = province;
            MySqlConnection conn = new MySqlConnection(LoginInfo.LoginCreds);
            try
            {
                conn.Open();
                MySqlCommand cmd;
                MySqlDataReader rdr;
                string sql;

                sql = "SELECT * FROM ProvinceTax WHERE Province = '" + province + "';";
                cmd = new MySqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    this.province = rdr[0].ToString();
                    this.gst = Int32.Parse(rdr[1].ToString());
                    this.pst = Int32.Parse(rdr[2].ToString());
                    //ProvinceTax temp = new ProvinceTax(rdr[0].ToString(), Int32.Parse(rdr[1].ToString()), Int32.Parse(rdr[2].ToString()));
                    //provinceTaxList.Add(temp);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            
           
        }


    }
}
