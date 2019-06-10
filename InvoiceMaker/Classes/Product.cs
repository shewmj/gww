using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InvoiceMaker
{
    public class Product
    {
        // Unique identifier for product
        internal String ItemNo { get; set; }
        internal String ItemDesc { get; set; }
        // Items come in packs of cartons
        // TODO: Validation CANNOT BE ZERO
        internal int PerCarton { get; set; }
        // Location in GWW Warehouse
        // TODO: Determine if it is a fixed amount of locations
        internal String Location { get; set; }
        // Cost for GWW
        // DO NOT GIVE THIS INFO IN INVOICE
        internal float Cost { get; set; }
        // Price for GWW Customer
        internal float SellPrice { get; set; }
        // Barcode; Sometimes information not available
        internal Int64 UPC { get; set; }

        //invoiceContent info
        internal int Quantity { get; set; }
        internal String SpecialNotes { get; set; }
        internal int BackOrder { get; set; }
        internal String BackOrderSpecialNotes { get; set; }

        public Product(string itemNo, string itemDesc, int perCarton, string location, float cost, float sellPrice, Int64 upc, String specialNotes)
        {
            ItemNo = itemNo;
            ItemDesc = itemDesc;
            PerCarton = perCarton;
            Location = location;
            Cost = cost;
            SellPrice = sellPrice;
            UPC = upc;
            SpecialNotes = specialNotes;

        }
        

        public Product(string itemNo, string itemDesc, int perCarton, string location, float cost, float sellPrice, Int64 upc)

        {
            ItemNo = itemNo;
            ItemDesc = itemDesc;
            PerCarton = perCarton;
            Location = location;
            Cost = cost;
            SellPrice = sellPrice;
            UPC = upc;
        }

        // Missing UPC
        public Product(string itemNo, string itemDesc, int perCarton, string location, float cost, float sellPrice)
        {
            ItemNo = itemNo;
            ItemDesc = itemDesc;
            PerCarton = perCarton;
            Location = location;
            Cost = cost;
            SellPrice = sellPrice;
            UPC = 0;
        }       
    }
}
