using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceMaker
{
    public class Customer
    {
          
        public int StoreID { get; set; }
        public String StoreName { get; set; }
        public String StoreDetails { get; set; }
        public String StoreSpecialNotes { get; set; }
        public String Email { get; set; }
        public String StreetAddress { get; set; }
        public String CityAddress { get; set; }
        public String ProvinceAddress { get; set; }
        public String PostalCodeAddress { get; set; }
        public String StoreContact { get; set; }      
        public String PhoneNumber { get; set; }     
        public String PaymentTerms { get; set; }      
        public String ShippingInstructions { get; set; } 
        public String Province { get; set; }
        public String Rep { get; set; }

        public Customer(int storeId, String storeName, String storeDetails, String storeSpecialNotes, String emailAddress, String streetAddress, String cityAddress, String provinceAddress,
            String postalCodeAddress, String storeContact, String phoneNumber, String paymentTerms, String shippingInstructions, String province, String rep)
        {

            StoreID = storeId;
            StoreName = storeName;
            StoreDetails = storeDetails;
            StoreSpecialNotes = storeSpecialNotes;
            Email = emailAddress;
            StreetAddress = streetAddress;
            CityAddress = cityAddress;
            ProvinceAddress = provinceAddress;
            PostalCodeAddress = postalCodeAddress;
            StoreContact = storeContact;
            PhoneNumber = phoneNumber;
            PaymentTerms = paymentTerms;
            ShippingInstructions = shippingInstructions;
            Province = province;
            Rep = rep;

        }

        /*
        public Customer(int storeId, String storeName, String storeDetails, String emailAddress, String billingAddress, String shippingAddress, String storeContact, String phoneNumber,
            String paymentTerms, String shippingInstructions, String province, String rep)
        {

            StoreID = storeId;
            StoreName = storeName;
            StoreDetails = storeDetails;
            BillingAddress = billingAddress;
            ShippingAddress = shippingAddress;
            StoreContact = storeContact;
            PhoneNumber = phoneNumber;
            PaymentTerms = paymentTerms;
            ShippingInstructions = shippingInstructions;
            Email = emailAddress;
            Province = province;
            Rep = rep;

        }
        */


    }
}
