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

namespace InvoiceMaker
{
    public partial class CustomerForm : Form
    {

        bool editMode = false;
        int storeNumber;

        public CustomerForm()
        {
            InitializeComponent();

            List<ProvinceTax> provinceTaxList = ProvinceTaxDatabase.GetAllProvinces();

            Object[] arr = new Object[provinceTaxList.Count];
            for (int i = 0; i < provinceTaxList.Count; i++)
            {
                arr[i] = provinceTaxList[i].province + " - GST: " + provinceTaxList[i].gst + "%/PST: " + provinceTaxList[i].pst + "%";
            }
            provinceTax_comboBox.Items.AddRange(arr);

            setTextBoxLimits();
            
        }



        //(int storeId, String storeName, String storeDetails, String storeSpecialNotes, String emailAddress, String streetAddress, String cityAddress, String provinceAddress,
          //  String postalCodeAddress, String storeContact, String phoneNumber, String paymentTerms, String shippingInstructions, String province, String rep)


        public CustomerForm(String storeName, String storeDetails, String storeSpecialNotes, String emailAddress, String streetAddress, String cityAddress, String provinceAddress,
            String postalCodeAddress, String storeContact, String phoneNumber, String paymentTerms, String shippingInstructions, String province, String rep)
        {
            InitializeComponent();
            List<ProvinceTax> provinceTaxList = ProvinceTaxDatabase.GetAllProvinces();

            Object[] arr = new Object[provinceTaxList.Count];
            for (int i = 0; i < provinceTaxList.Count; i++)
            {
                arr[i] = provinceTaxList[i].province + " - GST: " + provinceTaxList[i].gst + "%/PST: " + provinceTaxList[i].pst + "%";
            }
            provinceTax_comboBox.Items.AddRange(arr);

            setTextBoxLimits();
            storeName_textBox.Text = storeName;
            storeDetails_textBox.Text = storeDetails;

            shippingStreet_textBox.Text = streetAddress;
            shippingCity_textBox.Text = cityAddress;
            shippingPostal_textBox.Text = postalCodeAddress;
            String zzzzzz = provinceCodeConverter(provinceAddress);
            shippingProvince_comboBox.Text = provinceCodeConverter(provinceAddress);
            storeSpecialNotes_textBox.Text = storeSpecialNotes;


            //parseStringToGroup(officeAddress, groupBox1);
            //parseStringToGroup(shippingAddress, groupBox2);
            storeContact_textBox.Text = storeContact;
            email_textBox.Text = emailAddress;
            phoneNumber_textBox.Text = phoneNumber;
            paymentTerms_textBox.Text = paymentTerms;
            shippingInstructions_textBox.Text = shippingInstructions;
            int zzz = provinceTax_comboBox.FindString(province);

            provinceTax_comboBox.Text = provinceTax_comboBox.Items[provinceTax_comboBox.FindString(province)].ToString();
            rep_textBox.Text = rep;
            editMode = true;
            storeNumber = CustomerDatabase.GetStoreID(storeName, streetAddress);
            
        }

      

        private void okButton_Click(object sender, EventArgs e)
        {
            Boolean err = false;
            
            
            if (storeName_textBox.Text == String.Empty)
            {
                label1.ForeColor = Color.Red;
                err = true;
            }
            else
            {
                label1.ForeColor = Color.Black;
            }

            if (shippingStreet_textBox.Text.Length == 0 || shippingCity_textBox.Text.Length == 0 || shippingPostal_textBox.Text.Length == 0 || shippingProvince_comboBox.Text.Length == 0)
            {
                groupBox2.ForeColor = Color.Red;
                err = true;
            }
            else
            {
                groupBox2.ForeColor = Color.Black;
            }

            if(provinceTax_comboBox.Text == String.Empty)
            {
                label18.ForeColor = Color.Red;
                err = true;
            }
            else
            {
                label18.ForeColor = Color.Black;
            }
            if(err)
            {
                return;
            }
           
            if (editMode)
            {
                CustomerDatabase.EditCustomer(storeNumber, storeName_textBox.Text, storeDetails_textBox.Text, storeSpecialNotes_textBox.Text, email_textBox.Text, shippingStreet_textBox.Text, 
                    shippingCity_textBox.Text, provinceConverter(shippingProvince_comboBox.Text), shippingPostal_textBox.Text, storeContact_textBox.Text, phoneNumber_textBox.Text, paymentTerms_textBox.Text,
                    shippingInstructions_textBox.Text, provinceTax_comboBox.Text.Split(' ')[0], rep_textBox.Text);
            }
            else
            {
                CustomerDatabase.AddCustomer(storeName_textBox.Text, storeDetails_textBox.Text, storeSpecialNotes_textBox.Text, email_textBox.Text, shippingStreet_textBox.Text,
                    shippingCity_textBox.Text, provinceConverter(shippingProvince_comboBox.Text), shippingPostal_textBox.Text, storeContact_textBox.Text, phoneNumber_textBox.Text, paymentTerms_textBox.Text,
                    shippingInstructions_textBox.Text, provinceTax_comboBox.Text.Split(' ')[0], rep_textBox.Text);
            }
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       



        private void setTextBoxLimits()
        {
            foreach (TextBox tb in this.Controls.OfType<TextBox>())
            {
                if (tb != phoneNumber_textBox)
                {
                    tb.MaxLength = 50;
                }
                else
                {
                    tb.MaxLength = 15;
                }
            }
        }
        

        private String provinceConverter(String province)
        {
            switch (province)
            {
                case "Alberta":
                    return "AB";
                case "British Columbia":
                    return "BC";
                case "Manitoba":
                    return "MB";
                case "New Brunswick":
                    return "NB";
                case "Newfoundland and Labrador":
                    return "NL";
                case "Northwest Territories":
                    return "NT";
                case "Nova Scotia":
                    return "NS";
                case "Nunavut":
                    return "NU";
                case "Ontario":
                    return "ON";
                case "Prince Edward Island":
                    return "PE";
                case "Quebec":
                    return "QC";
                case "Saskatchewan":
                    return "SK";
                case "Yukon Territories":
                    return "YT";
                default:
                    return "";
            }
        }

        private String provinceCodeConverter(String province)
        {
            switch (province)
            {
                case "AB":
                    return "Alberta";
                case "BC":
                    return "British Columbia";
                case "MB":
                    return "Manitoba";
                case "NB":
                    return "New Brunswick";
                case "NL":
                    return "Newfoundland and Labrador";
                case "NT":
                    return "Northwest Territories";
                case "NS":
                    return "Nova Scotia";
                case "NU":
                    return "Nunavut";
                case "ON":
                    return "Ontario";
                case "PE":
                    return "Prince Edward Island";
                case "QC":
                    return "Quebec";
                case "SK":
                    return "Saskatchewan";
                case "YT":
                    return "Yukon Territories";
                default:
                    return "";
            }
        }

      

       
    }
}
